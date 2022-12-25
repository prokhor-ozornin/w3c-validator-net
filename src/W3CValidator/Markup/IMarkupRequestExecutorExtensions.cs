using W3CValidator.Markup;

namespace W3CValidator.Css;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IMarkupRequestExecutor"/>.</para>
/// </summary>
/// <seealso cref="IMarkupRequestExecutor"/>
public static class IMarkupRequestExecutorExtensions
{
  /// <summary>
  ///   <para>Validates markup of a document which is specified by its URL address, using W3C markup validation web service.</para>
  /// </summary>
  /// <param name="executor">Markup validator instance.</param>
  /// <param name="result">Markup validation result instance.</param>
  /// <param name="url">URL address of document to be validated.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if request was successful and <paramref name="result"/> output parameter contains validation results, or <c>false</c> if request failed and <paramref name="result"/> is a <c>null</c> reference.</returns>
  public static bool Url(this IMarkupRequestExecutor executor, out IMarkupValidationResult? result, Uri url, CancellationToken cancellation = default)
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