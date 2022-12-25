namespace W3CValidator.Markup;

internal sealed class MarkupValidationRequest : ValidationRequest, IMarkupValidationRequest
{
  public IMarkupValidationRequest Doctype(string? doctype)
  {
    Parameters["doctype"] = doctype;

    return this;
  }

  public IMarkupValidationRequest Encoding(string? encoding)
  {
    Parameters["charset"] = encoding;

    return this;
  }
}