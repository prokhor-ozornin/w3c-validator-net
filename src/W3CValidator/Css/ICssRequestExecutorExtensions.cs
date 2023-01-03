namespace W3CValidator.Css;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ICssRequestExecutor"/>.</para>
/// </summary>
/// <seealso cref="ICssRequestExecutor"/>
public static class ICssRequestExecutorExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="executor"></param>
  /// <param name="document"></param>
  /// <returns></returns>
  public static ICssValidationResult Document(this ICssRequestExecutor executor, string document) => executor.DocumentAsync(document).Result;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="executor"></param>
  /// <param name="url"></param>
  /// <returns></returns>
  public static ICssValidationResult Url(this ICssRequestExecutor executor, Uri url) => executor.UrlAsync(url).Result;
}