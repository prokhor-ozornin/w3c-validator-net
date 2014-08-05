using Catharsis.Commons;

namespace W3CValidator.Css
{
  internal sealed class CssValidationRequest : ValidationRequest, ICssValidationRequest
  {
    public ICssValidationRequest Language(string language)
    {
      Assertion.NotEmpty(language);

      this.Parameters["lang"] = language;
      return this;
    }

    public ICssValidationRequest Medium(string medium)
    {
      Assertion.NotEmpty(medium);

      this.Parameters["usermedium"] = medium;
      return this;
    }

    public ICssValidationRequest Profile(string profile)
    {
      Assertion.NotEmpty(profile);

      this.Parameters["profile"] = profile;
      return this;
    }

    public ICssValidationRequest Warnings(int warnings)
    {
      this.Parameters["warning"] = warnings;
      return this;
    }
  }
}