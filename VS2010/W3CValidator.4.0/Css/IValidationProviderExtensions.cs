using System;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IValidationProvider"/>.</para>
  /// </summary>
  /// <seealso cref="IValidationProvider"/>
  public static class IValidationProviderExtensions
  {
    private static readonly ICssValidator css = new CssValidator();

    /// <summary>
    ///   <para>Returns instance of CSS validator to perform validation of CSS documents through W3C web service.</para>
    /// </summary>
    /// <param name="provider">Validation provider instance.</param>
    /// <returns>CSS validator.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="provider"/> is a <c>null</c> reference.</exception>
    public static ICssValidator Css(this IValidationProvider provider)
    {
      Assertion.NotNull(provider);

      return css;
    }
  }
}