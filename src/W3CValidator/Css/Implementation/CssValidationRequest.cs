namespace W3CValidator.Css;

internal sealed class CssValidationRequest : ValidationRequest, ICssValidationRequest
{
  public ICssValidationRequest Language(string? language)
  {
    Parameters["lang"] = language;

    return this;
  }

  public ICssValidationRequest Medium(string? medium)
  {
    Parameters["usermedium"] = medium;

    return this;
  }

  public ICssValidationRequest Profile(string? profile)
  {
    Parameters["profile"] = profile;

    return this;
  }

  public ICssValidationRequest Warnings(int? warnings)
  {
    Parameters["warning"] = warnings;

    return this;
  }
}