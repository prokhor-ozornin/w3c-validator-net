using System.Collections.Generic;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Logical group of validation errors.</para>
  /// </summary>
  public interface IErrorsList
  {
    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    IEnumerable<IError> Errors { get; }

    /// <summary>
    ///   <para>URI address of validated document or fragment.</para>
    /// </summary>
    string Uri { get; }
  }
}