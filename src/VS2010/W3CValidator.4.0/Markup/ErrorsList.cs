using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Logical group of validation errors.</para>
  /// </summary>
  [XmlType("errors")]
  public sealed class ErrorsList : IErrorsList
  {
    /// <summary>
    ///   <para>Total number of validation errors.</para>
    /// </summary>
    [XmlElement("errorcount")]
    public int Count { get; set; }

    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    [XmlIgnore]
    public IEnumerable<IIssue> Errors
    {
      get { return this.ErrorsCollection.Cast<IIssue>(); }
    }

    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    [XmlArray("errorlist")]
    [XmlArrayItem("error")]
    public List<Issue> ErrorsCollection { get; set; }

    /// <summary>
    ///   <para>Creates new group of validation errors.</para>
    /// </summary>
    public ErrorsList()
    {
      this.ErrorsCollection = new List<Issue>();
    }
  }
}