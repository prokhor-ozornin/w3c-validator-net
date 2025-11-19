namespace W3CValidator.Css;

/// <summary>
///   <para>A set of extension methods for the <see cref="ICssRequestExecutor"/> interface.</para>
/// </summary>
/// <seealso cref="ICssRequestExecutor"/>
public static class ICssRequestExecutorExtensions
{
  /// <param name="executor"></param>
  extension(ICssRequestExecutor executor)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="document"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="executor"/> or <paramref name="document"/> is <see langword="null"/>.</exception>
    public ICssValidationResult Document(string document)
    {
      if (executor is null) throw new ArgumentNullException(nameof(executor));
      if (document is null) throw new ArgumentNullException(nameof(document));

      return executor.DocumentAsync(document).Result;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="executor"/> or <paramref name="url"/> is <see langword="null"/>.</exception>
    public ICssValidationResult Url(Uri url)
    {
      if (executor is null) throw new ArgumentNullException(nameof(executor));
      if (url is null) throw new ArgumentNullException(nameof(url));

      return executor.UrlAsync(url).Result;
    }
  }
}