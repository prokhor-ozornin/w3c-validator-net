namespace W3CValidator.Css;

/// <summary>
///   <para>A set of extension methods for the <see cref="ICssValidator"/> interface.</para>
/// </summary>
/// <seealso cref="ICssValidator"/>
public static class ICssValidatorExtensions
{
  /// <param name="validator"></param>
  extension(ICssValidator validator)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="validator"/> is <see langword="null"/>.</exception>
    public ICssRequestExecutor Request(Action<ICssValidationRequest> action = null)
    {
      if (validator is null) throw new ArgumentNullException(nameof(validator));

      var request = new CssValidationRequest();

      action?.Invoke(request);

      return validator.Request(request);
    }
  }
}