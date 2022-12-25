using Catharsis.Commons;
using W3CValidator.Markup;

namespace W3CValidator.Css;

internal sealed class MarkupRequestExecutor : IMarkupRequestExecutor
{
  private bool disposed;

  private Uri EndpointUrl { get; }= "http://validator.w3.org/check".ToUri();
  private IMarkupValidationRequest? Request { get; }
  private HttpClient HttpClient { get; } = new();

  public MarkupRequestExecutor(IMarkupValidationRequest? request)
  {
    Request = request;
    HttpClient.DefaultRequestHeaders.Add("User-Agent", "W3CValidator.NET client library");
  }

  public async Task<IMarkupValidationResult> Url(Uri url, CancellationToken cancellation = default)
  {
    var parameters = new Dictionary<string, object?> {{"uri", url}};

    if (Request != null)
    {
      parameters.AddAll(Request.Parameters);
    }

    return await Call(parameters, cancellation);
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  private void Dispose(bool disposing)
  {
    if (!disposing || disposed)
    {
      return;
    }

    HttpClient.Dispose();

    disposed = true;
  }

  private async Task<IMarkupValidationResult> Call(IDictionary<string, object?> parameters, CancellationToken cancellation = default)
  {
    if (!parameters.Any())
    {
      throw new MarkupException("No request parameters were specified");
    }

    try
    {
      var uri = EndpointUrl.ToUriBuilder().WithQuery(("output", "soap12")).WithQuery(parameters).Uri;

      using var reader = (await HttpClient.ToStream(uri, cancellation)).ToXmlReader();

      reader.ReadToFollowing("markupvalidationresponse", "http://www.w3.org/2005/10/markup-validator");

      return reader.AsXml<MarkupValidationResult.Info>(new[] { typeof(MarkupValidationResult) })!.Result();
    }
    catch (Exception exception)
    {
      throw new MarkupException($@"Cannot validate markup of document or document fragment at endpoint URL ""{EndpointUrl}""", exception);
    }
  }
}