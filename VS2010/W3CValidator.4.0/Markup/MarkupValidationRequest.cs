using Catharsis.Commons;

namespace W3CValidator.Markup
{
  internal sealed class MarkupValidationRequest : ValidationRequest, IMarkupValidationRequest
  {
    public IMarkupValidationRequest Doctype(string doctype)
    {
      Assertion.NotEmpty(doctype);

      this.Parameters["doctype"] = doctype;
      return this;
    }

    public IMarkupValidationRequest Encoding(string encoding)
    {
      Assertion.NotEmpty(encoding);

      this.Parameters["charset"] = encoding;
      return this;
    }
  }
}