﻿using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace W3CValidator.Css;

/// <summary>
///   <para>Representation of response from W3C CSS validation web service that contains detailed information concerning validation results.</para>
/// </summary>
[DataContract(Name = "cssvalidationresponse", Namespace = "http://www.w3.org/2005/07/css-validator")]
[KnownType(typeof(Issues))]
public sealed class CssValidationResult : ICssValidationResult
{
  /// <summary>
  ///   <para>The address of the document validated.</para>
  /// </summary>
  [DataMember(Name = "uri", IsRequired = true)]
  public string Uri { get; set; }

  /// <summary>
  ///   <para>Whether or not the document validated passed or not formal validation.</para>
  /// </summary>
  [DataMember(Name = "validity", IsRequired = true)]
  public bool? Valid { get; set; }

  /// <summary>
  ///   <para>The actual date of the validation.</para>
  /// </summary>
  [DataMember(Name = "date", IsRequired = true)]
  public DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Location of the service which provided the validation result.</para>
  /// </summary>
  [DataMember(Name = "checkedby", IsRequired = true)]
  public string CheckedBy { get; set; }

  /// <summary>
  ///   <para>The CSS level (or profile) in use during the validation.</para>
  /// </summary>
  [DataMember(Name = "csslevel", IsRequired = true)]
  public string CssLevel { get; set; }

  /// <summary>
  ///   <para>Collection of errors and warnings encountered through the validation process.</para>
  /// </summary>
  [DataMember(Name = "result", IsRequired = true)]
  public IIssues Issues { get; init; } = new Issues();

  /// <summary>
  ///   <para>Compares the current <see cref="ICssValidationResult"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ICssValidationResult"/> to compare with this instance.</param>
  public int CompareTo(ICssValidationResult other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="ICssValidationResult"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public bool Equals(ICssValidationResult other) => this.Equality(other, nameof(Uri));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as ICssValidationResult);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Uri));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="CssValidationResult"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="CssValidationResult"/>.</returns>
  public override string ToString() => Uri ?? string.Empty;
}