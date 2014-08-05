using System;
using System.Text;
using Catharsis.Commons;

namespace W3CValidator.Markup
{
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
    /// <exception cref="ArgumentNullException">If either <paramref name="request"/> or <paramref name="encoding"/> is a <c>null</c> reference.</exception>
    public static IMarkupValidationRequest Encoding(this IMarkupValidationRequest request, Encoding encoding)
    {
      Assertion.NotNull(request);
      Assertion.NotNull(encoding);

      return request.Encoding(encoding.ToString());
    }
  }
}