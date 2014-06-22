using System;
using System.Globalization;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ICssValidationRequest"/>.</para>
  /// </summary>
  /// <seealso cref="ICssValidationRequest"/>
  public static class ICssValidationRequestExtensions
  {
    /// <summary>
    ///   <para>Specifies language locale/culture to be used for description of validation issues.</para>
    /// </summary>
    /// <param name="request">Validation request instance.</param>
    /// <param name="culture">Text culture.</param>
    /// <returns>Back reference to the provided validation <paramref name="request"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="request"/> or <paramref name="culture"/> is a <c>null</c> reference.</exception>
    public static ICssValidationRequest Language(this ICssValidationRequest request, CultureInfo culture)
    {
      Assertion.NotNull(request);
      Assertion.NotNull(culture);

      return request.Language(culture.TwoLetterISOLanguageName);
    }

    /// <summary>
    ///   <para>Specifies CSS medium to use in validation process.</para>
    /// </summary>
    /// <param name="request">Validation request instance.</param>
    /// <param name="medium">CSS medium.</param>
    /// <returns>Back reference to the provided validation <paramref name="request"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is a <c>null</c> reference.</exception>
    public static ICssValidationRequest Medium(this ICssValidationRequest request, CssMedium medium)
    {
      Assertion.NotNull(request);

      return request.Medium(Enum.GetName(typeof(CssMedium), medium).ToLowerInvariant());
    }

    /// <summary>
    ///   <para>Specifies CSS standard version (profile) to be used in validation process.</para>
    /// </summary>
    /// <param name="request">Validation request instance.</param>
    /// <param name="profile">CSS profile.</param>
    /// <returns>Back reference to the provided validation <paramref name="request"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is a <c>null</c> reference.</exception>
    public static ICssValidationRequest Profile(this ICssValidationRequest request, CssProfile profile)
    {
      Assertion.NotNull(request);

      return request.Profile(Enum.GetName(typeof(CssProfile), profile).ToLowerInvariant());
    }

    /// <summary>
    ///   <para>Specifies level of warnings to be included. Only the ones whose level is under or equal to the value specified in the request will be displayed.</para>
    /// </summary>
    /// <param name="request">Validation request instance.</param>
    /// <param name="level">Level of warnings severity.</param>
    /// <returns>Back reference to the provided validation <paramref name="request"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is a <c>null</c> reference.</exception>
    public static ICssValidationRequest Warnings(this ICssValidationRequest request, WarningsLevel level)
    {
      Assertion.NotNull(request);

      return request.Warnings((int) level);
    }
  }
}