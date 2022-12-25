namespace W3CValidator.Css;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ICssValidator"/>.</para>
/// </summary>
/// <seealso cref="ICssValidator"/>
public static class ICssValidatorExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="validator"></param>
  /// <param name="action"></param>
  /// <returns></returns>
  public static ICssRequestExecutor Request(this ICssValidator validator, Action<ICssValidationRequest>? action = null)
  {
    var request = new CssValidationRequest();

    action?.Invoke(request);

    return validator.Request(request);
  }
}