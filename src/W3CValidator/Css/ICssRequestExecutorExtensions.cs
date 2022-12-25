namespace W3CValidator.Css;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ICssRequestExecutor"/>.</para>
/// </summary>
/// <seealso cref="ICssRequestExecutor"/>
public static class ICssRequestExecutorExtensions
{
  /// <summary>
  ///   <para>Validates given fragment of CSS code, using W3C CSS validation web service.</para>
  /// </summary>
  /// <param name="executor">CSS executor instance.</param>
  /// <param name="result">CSS validation result instance.</param>
  /// <param name="document">CSS code fragment to be validated.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if request was successful and <paramref name="result"/> output parameter contains validation results, or <c>false</c> if request failed and <paramref name="result"/> is a <c>null</c> reference.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="executor"/> or <paramref name="document"/> is <langword>null</langword>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="document"/> is <see cref="string.Empty"/>.</exception>
  public static bool Document(this ICssRequestExecutor executor, out ICssValidationResult? result, string document, CancellationToken cancellation = default)
  {
    try
    {
      result = executor.Document(document, cancellation).Result;
      return true;
    }
    catch
    {
      result = null;
      return false;
    }
  }

  /// <summary>
  ///   <para>Validates CSS document, specified by its URL address, using W3C CSS validation web service.</para>
  /// </summary>
  /// <param name="executor">CSS executor instance.</param>
  /// <param name="result">CSS validation result instance.</param>
  /// <param name="url">URL address of document to be validated.</param>
  /// <param name="cancellation"></param>
  /// <exception cref="ArgumentNullException"></exception>
  /// <returns><c>true</c> if request was successful and <paramref name="result"/> output parameter contains validation results, or <c>false</c> if request failed and <paramref name="result"/> is a <c>null</c> reference.</returns>
  public static bool Url(this ICssRequestExecutor executor, out ICssValidationResult? result, Uri url, CancellationToken cancellation = default)
  {
    try
    {
      result = executor.Url(url, cancellation).Result;
      return true;
    }
    catch
    {
      result = null;
      return false;
    }
  }
}