﻿using W3CValidator.Markup;

namespace W3CValidator.Css;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IMarkupRequestExecutor"/>.</para>
/// </summary>
/// <seealso cref="IMarkupRequestExecutor"/>
public static class IMarkupRequestExecutorExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="executor"></param>
  /// <param name="url"></param>
  /// <returns></returns>
  public static IMarkupValidationResult Url(this IMarkupRequestExecutor executor, Uri url) => executor.UrlAsync(url).Result;
}