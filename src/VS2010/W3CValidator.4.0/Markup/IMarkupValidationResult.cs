using System;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Representation of response from W3C Markup validation web service that contains detailed information concerning validation results.</para>
  /// </summary>
  public interface IMarkupValidationResult
  {
    /// <summary>
    ///   <para>Location of the service which provided the validation result.</para>
    /// </summary>
    string CheckedBy { get; }

    /// <summary>
    ///   <para>The actual date of the validation.</para>
    /// </summary>
    DateTime Date { get; }

    /// <summary>
    ///   <para>Detected (or forced) Document Type for the validated document.</para>
    /// </summary>
    string Doctype { get; }

    /// <summary>
    ///   <para>Detected (or forced) Character Encoding for the validated document.</para>
    /// </summary>
    string Encoding { get; }

    /// <summary>
    ///   <para>Collection of errors encountered through the validation process.</para>
    /// </summary>
    IErrorsList ErrorsList { get; }

    /// <summary>
    ///   <para>The address of the document validated.</para>
    /// </summary>
    string Uri { get; }

    /// <summary>
    ///   <para>Whether or not the document validated passed or not formal validation.</para>
    /// </summary>
    bool Valid { get; }

    /// <summary>
    ///   <para>Collection of warnings encountered through the validation process.</para>
    /// </summary>
    IWarningsList WarningsList { get; }
  }
}