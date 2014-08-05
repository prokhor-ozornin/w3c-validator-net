using System.Collections.Generic;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Logical group of validation errors.</para>
  /// </summary>
  public interface IErrorsList
  {
    /// <summary>
    ///   <para>Total number of validation errors.</para>
    /// </summary>
    int Count { get; }

    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    IEnumerable<IIssue> Errors { get; }
  }
}