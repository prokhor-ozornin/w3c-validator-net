using System.Text;

namespace W3CValidator.Markup;

/// <summary>
///   <para>A set of extension methods for the <see cref="IMarkupValidationRequest"/> interface.</para>
/// </summary>
/// <seealso cref="IMarkupValidationRequest"/>
public static class IMarkupValidationRequestExtensions
{
  /// <param name="request">Validation request instance.</param>
  extension(IMarkupValidationRequest request)
  {
    /// <summary>
    ///   <para>Specifies the character encoding to use when parsing the document.</para>
    /// </summary>
    /// <param name="encoding">Character encoding.</param>
    /// <returns>Back reference to the provided validation <paramref name="request"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="request"/> is <see langword="null"/>.</exception>
    public IMarkupValidationRequest Encoding(Encoding encoding) => request is not null ? request.Encoding(encoding?.WebName) : throw new ArgumentNullException(nameof(request));
  }
}