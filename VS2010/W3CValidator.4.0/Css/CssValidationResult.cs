using System;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Representation of response from W3C CSS validation web service that contains detailed information concerning validation results.</para>
  /// </summary>
  [XmlType("cssvalidationresponse")]
  [XmlRoot(Namespace = "http://www.w3.org/2005/07/css-validator")]
  public sealed class CssValidationResult : IComparable<ICssValidationResult>, IEquatable<ICssValidationResult>, ICssValidationResult
  {
    /// <summary>
    ///   <para>Location of the service which provided the validation result.</para>
    /// </summary>
    [XmlElement("checkedby")]
    public string CheckedBy { get; set; }

    /// <summary>
    ///   <para>The CSS level (or profile) in use during the validation.</para>
    /// </summary>
    [XmlElement("csslevel")]
    public string CssLevel { get; set; }

    /// <summary>
    ///   <para>The actual date of the validation.</para>
    /// </summary>
    [XmlElement("date")]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Collection of errors and warnings encountered through the validation process.</para>
    /// </summary>
    [XmlElement("result")]
    public IssuesList IssuesList { get; set; }

    /// <summary>
    ///   <para>Collection of errors and warnings encountered through the validation process.</para>
    /// </summary>
    [XmlIgnore]
    public IIssuesList Issues
    {
      get { return this.IssuesList; }
    }

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
    ///   <para>Creates new instance of validation result.</para>
    /// </summary>
    public CssValidationResult()
    {
      this.Date = DateTime.UtcNow;
      this.IssuesList = new IssuesList();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="ICssValidationResult"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="ICssValidationResult"/> to compare with this instance.</param>
    public int CompareTo(ICssValidationResult other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="ICssValidationResult"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(ICssValidationResult other)
    {
      return this.Equality(other, result => result.Uri);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as ICssValidationResult);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(result => result.Uri);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="CssValidationResult"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="CssValidationResult"/>.</returns>
    public override string ToString()
    {
      return this.Uri;
    }
  }
}