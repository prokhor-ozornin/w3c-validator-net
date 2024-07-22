namespace W3CValidator.Css;

/// <summary>
///   <para>A set of extension methods for the <see cref="ICssRequestExecutor"/> interface.</para>
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
  public static ICssValidationResult Document(this ICssRequestExecutor executor, string document)
  {
    if (executor is null) throw new ArgumentNullException(nameof(executor));
    if (document is null) throw new ArgumentNullException(nameof(document));

    return executor.DocumentAsync(document).Result;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="executor"></param>
  /// <param name="url"></param>
  /// <returns></returns>
  public static ICssValidationResult Url(this ICssRequestExecutor executor, Uri url)
  {
    if (executor is null) throw new ArgumentNullException(nameof(executor));
    if (url is null) throw new ArgumentNullException(nameof(url));

    return executor.UrlAsync(url).Result;
  }
}