using System.Collections.Generic;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>List of issues (errors/warnings) encountered during the validation process.</para>
  /// </summary>
  public interface IIssuesList
  {
    /// <summary>
    ///   <para>Collection of validation errors groups.</para>
    /// </summary>
    IEnumerable<IErrorsList> ErrorsGroups { get; }

    /// <summary>
    ///   <para>Collection of validation warnings groups.</para>
    /// </summary>
    IEnumerable<IWarningsList> WarningsGroups { get; }
  }
}