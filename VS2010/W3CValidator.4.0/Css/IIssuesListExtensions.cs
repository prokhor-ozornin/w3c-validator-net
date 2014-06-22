using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IIssuesList"/>.</para>
  /// </summary>
  /// <seealso cref="IIssuesList"/>
  public static class IIssuesListExtensions
  {
    /// <summary>
    ///   <para>Returns a sequence of all validation errors, combining those from individual groups.</para>
    /// </summary>
    /// <param name="issues">Source list of validation issues.</param>
    /// <returns>Sequence of validation errors from the list of issues.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="issues"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<IError> Errors(this IIssuesList issues)
    {
      Assertion.NotNull(issues);

      return issues.ErrorsGroups.SelectMany(group => group.Errors);
    }

    /// <summary>
    ///   <para>Returns a sequence of all validation warnings, combining those from individual groups.</para>
    /// </summary>
    /// <param name="issues">Source list of validation issues.</param>
    /// <returns>Sequence of validation warnings from the list of issues.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="issues"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<IWarning> Warnings(this IIssuesList issues)
    {
      Assertion.NotNull(issues);

      return issues.WarningsGroups.SelectMany(group => group.Warnings);
    }
  }
}