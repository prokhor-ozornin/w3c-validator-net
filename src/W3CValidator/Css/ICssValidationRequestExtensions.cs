using System.Globalization;
using Catharsis.Extensions;

namespace W3CValidator.Css;

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
  public static ICssValidationRequest Language(this ICssValidationRequest request, CultureInfo culture) => request.Language(culture?.TwoLetterISOLanguageName);

  /// <summary>
  ///   <para>Specifies CSS medium to use in validation process.</para>
  /// </summary>
  /// <param name="request">Validation request instance.</param>
  /// <param name="medium">CSS medium.</param>
  /// <returns>Back reference to the provided validation <paramref name="request"/>.</returns>
  public static ICssValidationRequest Medium(this ICssValidationRequest request, CssMedium? medium) => request.Medium(medium?.ToInvariantString());

  /// <summary>
  ///   <para>Specifies CSS standard version (profile) to be used in validation process.</para>
  /// </summary>
  /// <param name="request">Validation request instance.</param>
  /// <param name="profile">CSS profile.</param>
  /// <returns>Back reference to the provided validation <paramref name="request"/>.</returns>
  public static ICssValidationRequest Profile(this ICssValidationRequest request, CssProfile? profile) => request.Profile(profile?.ToString().ToLowerInvariant());

  /// <summary>
  ///   <para>Specifies level of warnings to be included. Only the ones whose level is under or equal to the value specified in the request will be displayed.</para>
  /// </summary>
  /// <param name="request">Validation request instance.</param>
  /// <param name="level">Level of warnings severity.</param>
  /// <returns>Back reference to the provided validation <paramref name="request"/>.</returns>
  public static ICssValidationRequest Warnings(this ICssValidationRequest request, WarningsLevel? level) => request.Warnings((int?) level);
}