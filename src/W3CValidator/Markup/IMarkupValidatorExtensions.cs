using W3CValidator.Css;

namespace W3CValidator.Markup;

/// <summary>
///   <para>A set of extension methods for the <see cref="IMarkupValidator"/> interface.</para>
/// </summary>
/// <seealso cref="IMarkupValidator"/>
public static class IMarkupValidatorExtensions
{
  /// <param name="validator"></param>
  extension(IMarkupValidator validator)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="validator"/> is <see langword="null"/>.</exception>
    public IMarkupRequestExecutor Request(Action<IMarkupValidationRequest> action = null)
    {
      if (validator is null) throw new ArgumentNullException(nameof(validator));

      var request = new MarkupValidationRequest();

      action?.Invoke(request);

      return validator.Request(request);
    }
  }
}