namespace W3CValidator
{
  /// <summary>
  ///   <para>Entry point to access W3C validation services.</para>
  /// </summary>
  public static class Validator
  {
    private static IValidationProvider provider = new ValidationProvider();

    /// <summary>
    ///   <para>Returns validation provider instance to perform validating operations.</para>
    /// </summary>
    public static IValidationProvider Validate
    {
      get { return provider; }
    }

    private sealed class ValidationProvider : IValidationProvider
    {
    }
  }
}