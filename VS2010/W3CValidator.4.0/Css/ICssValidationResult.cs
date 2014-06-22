using System;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Representation of response from W3C CSS validation web service that contains detailed information concerning validation results.</para>
  /// </summary>
  public interface ICssValidationResult
  {
    /// <summary>
    ///   <para>Location of the service which provided the validation result.</para>
    /// </summary>
    string CheckedBy { get; }

    /// <summary>
    ///   <para>The CSS level (or profile) in use during the validation.</para>
    /// </summary>
    string CssLevel { get; }

    /// <summary>
    ///   <para>The actual date of the validation.</para>
    /// </summary>
    DateTime Date { get; }

    /// <summary>
    ///   <para>Collection of errors and warnings encountered through the validation process.</para>
    /// </summary>
    IIssuesList Issues { get; }

    /// <summary>
    ///   <para>The address of the document validated.</para>
    /// </summary>
    string Uri { get; }

    /// <summary>
    ///   <para>Whether or not the document validated passed or not formal validation.</para>
    /// </summary>
    bool Valid { get; }
  }
}