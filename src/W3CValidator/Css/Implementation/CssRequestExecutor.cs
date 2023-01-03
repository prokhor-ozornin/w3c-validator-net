using Catharsis.Commons;

namespace W3CValidator.Css;

internal sealed class CssRequestExecutor : ICssRequestExecutor
{
  private bool disposed;

  private Uri EndpointUrl { get; } = "http://jigsaw.w3.org/css-validator/validator".ToUri();
  private ICssValidationRequest Request { get; }
  private HttpClient HttpClient { get; } = new();

  public CssRequestExecutor(ICssValidationRequest request) => Request = request;

  public async Task<ICssValidationResult> DocumentAsync(string document, CancellationToken cancellation = default)
  {
    var parameters = new Dictionary<string, object> {{"text", document}};

    if (Request != null)
    {
      parameters.AddRange(Request.Parameters);
    }

    return await Call(parameters, cancellation).ConfigureAwait(false);
  }

  public async Task<ICssValidationResult> UrlAsync(Uri url, CancellationToken cancellation = default)
  {
    var parameters = new Dictionary<string, object> {{"uri", url}};

    if (Request != null)
    {
      parameters.AddRange(Request.Parameters);
    }

    return await Call(parameters, cancellation).ConfigureAwait(false);
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

  private async Task<ICssValidationResult> Call(IReadOnlyDictionary<string, object> parameters, CancellationToken cancellation = default)
  {
    if (!parameters.Any())
    {
      throw new CssException("No request parameters were specified");
    }

    try
    {
      var uri = EndpointUrl.ToUriBuilder().WithQuery(("output", "soap12")).WithQuery(parameters).Uri;

      using var reader = (await HttpClient.ToStreamAsync(uri, cancellation).ConfigureAwait(false)).ToXmlReader();

      reader.ReadToFollowing("cssvalidationresponse", "http://www.w3.org/2005/07/css-validator");

      return reader.DeserializeAsXml<CssValidationResult.Info>().ToResult();
    }
    catch (Exception exception)
    {
      throw new CssException($"Cannot validate CSS document or CSS fragment at endpoint URL \"{EndpointUrl}\"", exception);
    }
  }
}