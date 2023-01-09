namespace W3CValidator.Css;

/// <summary>
///   <para></para>
/// </summary>
public interface ICssRequestExecutor : IDisposable
{
  /// <summary>
  ///   <para>Validates given fragment of CSS code, using W3C CSS validation web service.</para>
  /// </summary>
  /// <param name="document">CSS code fragment to be validated.</param>
  /// <param name="cancellation"></param>
  /// <returns>CSS validation result instance.</returns>
  /// <exception cref="CssException">If any error occurred during the validation process.</exception>
  Task<ICssValidationResult> DocumentAsync(string document, CancellationToken cancellation = default);

  /// <summary>
  ///   <para>Validates CSS document, specified by its URL address, using W3C CSS validation web service.</para>
  /// </summary>
  /// <param name="url">URL address of document to be validated.</param>
  /// <param name="cancellation"></param>
  /// <returns>CSS validation result instance.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="CssException">If any error occurred during the validation process.</exception>
  Task<ICssValidationResult> UrlAsync(Uri url, CancellationToken cancellation = default);
}