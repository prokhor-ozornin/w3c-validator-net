using System.Text;

namespace W3CValidator.Markup;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IMarkupValidationRequest"/>.</para>
/// </summary>
/// <seealso cref="IMarkupValidationRequest"/>
public static class IMarkupValidationRequestExtensions
{
  /// <summary>
  ///   <para>Specifies the character encoding to use when parsing the document.</para>
  /// </summary>
  /// <param name="request">Validation request instance.</param>
  /// <param name="encoding">Character encoding.</param>
  /// <returns>Back reference to the provided validation <paramref name="request"/>.</returns>
  public static IMarkupValidationRequest Encoding(this IMarkupValidationRequest request, Encoding encoding) => request.Encoding(encoding?.WebName);
}