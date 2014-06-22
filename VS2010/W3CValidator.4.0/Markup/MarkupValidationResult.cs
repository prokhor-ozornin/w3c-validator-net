using System;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Representation of response from W3C Markup validation web service that contains detailed information concerning validation results.</para>
  /// </summary>
  [XmlType("markupvalidationresponse")]
  [XmlRoot(Namespace = "http://www.w3.org/2005/10/markup-validator")]
  public sealed class MarkupValidationResult : IComparable<MarkupValidationResult>, IEquatable<MarkupValidationResult>, IMarkupValidationResult
  {
    /// <summary>
    ///   <para>Location of the service which provided the validation result.</para>
    /// </summary>
    [XmlElement("checkedby")]
    public string CheckedBy { get; set; }

    /// <summary>
    ///   <para>The actual date of the validation.</para>
    /// </summary>
    [XmlIgnore]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Detected (or forced) Document Type for the validated document.</para>
    /// </summary>
    [XmlElement("doctype")]
    public string Doctype { get; set; }

    /// <summary>
    ///   <para>Detected (or forced) Character Encoding for the validated document.</para>
    /// </summary>
    [XmlElement("charset")]
    public string Encoding { get; set; }

    /// <summary>
    ///   <para>Collection of errors encountered through the validation process.</para>
    /// </summary>
    [XmlIgnore]
    public IErrorsList ErrorsList
    {
      get { return this.Errors; }
    }

    /// <summary>
    ///   <para>Collection of errors encountered through the validation process.</para>
    /// </summary>
    [XmlElement("errors")]
    public ErrorsList Errors { get; set; }

    /// <summary>
    ///   <para>The address of the document validated.</para>
    /// </summary>
    [XmlElement("uri")]
    public string Uri { get; set; }

    /// <summary>
    ///   <para>Whether or not the document validated passed or not formal validation.</para>
    /// </summary>
    [XmlElement("validity")]
    public bool Valid { get; set; }

    /// <summary>
    ///   <para>Collection of warnings encountered through the validation process.</para>
    /// </summary>
    [XmlIgnore]
    public IWarningsList WarningsList
    {
      get { return this.Warnings; }
    }

    /// <summary>
    ///   <para>Collection of warnings encountered through the validation process.</para>
    /// </summary>
    [XmlElement("warnings")]
    public WarningsList Warnings { get; set; }

    /// <summary>
    ///   <para>Creates new validation result.</para>
    /// </summary>
    public MarkupValidationResult()
    {
      this.Errors = new ErrorsList();
      this.Warnings = new WarningsList();
      this.Date = DateTime.UtcNow;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="MarkupValidationResult"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="MarkupValidationResult"/> to compare with this instance.</param>
    public int CompareTo(MarkupValidationResult other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="MarkupValidationResult"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(MarkupValidationResult other)
    {
      return this.Equality(other, x => x.Uri);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as MarkupValidationResult);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(x => x.Uri);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="MarkupValidationResult"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="MarkupValidationResult"/>.</returns>
    public override string ToString()
    {
      return this.Uri;
    }
  }
}