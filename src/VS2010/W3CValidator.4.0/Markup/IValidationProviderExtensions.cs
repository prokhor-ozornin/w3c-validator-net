using System;
using Catharsis.Commons;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IValidationProvider"/>.</para>
  /// </summary>
  /// <seealso cref="IValidationProvider"/>
  public static class IValidationProviderExtensions
  {
    private static readonly IMarkupValidator markup = new MarkupValidator();

    /// <summary>
    ///   <para>Returns instance of markup validator to perform validation of hypertext documents through W3C web service.</para>
    /// </summary>
    /// <param name="provider">Validation provider instance.</param>
    /// <returns>Markup validator.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="provider"/> is a <c>null</c> reference.</exception>
    public static IMarkupValidator Markup(this IValidationProvider provider)
    {
      Assertion.NotNull(provider);

      return markup;
    }
  }
}