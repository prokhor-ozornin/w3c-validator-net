using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Logical group of validation warnings.</para>
  /// </summary>
  [XmlType("warninglist")]
  public sealed class WarningsList : IEquatable<IWarningsList>, IWarningsList
  {
    /// <summary>
    ///   <para>Collection of validation warnings.</para>
    /// </summary>
    [XmlIgnore]
    public IEnumerable<IWarning> Warnings
    {
      get { return this.WarningsCollection.Cast<IWarning>(); }
    }

    /// <summary>
    ///   <para>Collection of validation warnings.</para>
    /// </summary>
    [XmlElement("warning")]
    public List<Warning> WarningsCollection { get; set; }

    /// <summary>
    ///   <para>URI address of validated document or fragment.</para>
    /// </summary>
    [XmlElement("uri")]
    public string Uri { get; set; }

    /// <summary>
    ///   <para>Creates new group of validation warnings.</para>
    /// </summary>
    public WarningsList()
    {
      this.WarningsCollection = new List<Warning>();
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="IWarningsList"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(IWarningsList other)
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
      return this.Equals(other as IWarningsList);
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
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="WarningsList"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="WarningsList"/>.</returns>
    public override string ToString()
    {
      return this.Uri;
    }
  }
}