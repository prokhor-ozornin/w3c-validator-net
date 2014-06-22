using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Logical group of validation errors.</para>
  /// </summary>
  [XmlType("errorlist")]
  public sealed class ErrorsList : IEquatable<ErrorsList>, IErrorsList
  {
    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    [XmlIgnore]
    public IEnumerable<IError> Errors
    {
      get { return this.ErrorsCollection.Cast<IError>(); }
    }

    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    [XmlElement("error")]
    public List<Error> ErrorsCollection { get; set; }

    /// <summary>
    ///   <para>URI address of validated document or fragment.</para>
    /// </summary>
    [XmlElement("uri")]
    public string Uri { get; set; }

    /// <summary>
    ///   <para>Creates new group of validation errors.</para>
    /// </summary>
    public ErrorsList()
    {
      this.ErrorsCollection = new List<Error>();
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="ErrorsList"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(ErrorsList other)
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
      return this.Equals(other as ErrorsList);
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
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="ErrorsList"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="ErrorsList"/>.</returns>
    public override string ToString()
    {
      return this.Uri;
    }
  }
}