using W3CValidator.Css;

namespace W3CValidator.Markup;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IMarkupValidator"/>.</para>
/// </summary>
/// <seealso cref="IMarkupValidator"/>
public static class IMarkupValidatorExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="validator"></param>
  /// <param name="action"></param>
  /// <returns></returns>
  public static IMarkupRequestExecutor Request(this IMarkupValidator validator, Action<IMarkupValidationRequest> action = null)
  {
    var request = new MarkupValidationRequest();

    action?.Invoke(request);

    return validator.Request(request);
  }
}