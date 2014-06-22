using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Logical group of validation warnings.</para>
  /// </summary>
  [XmlType("warnings")]
  public sealed class WarningsList : IWarningsList
  {
    /// <summary>
    ///   <para>Total number of validation warnings.</para>
    /// </summary>
    [XmlElement("warningcount")]
    public int Count { get; set; }

    /// <summary>
    ///   <para>Collection of validation warnings.</para>
    /// </summary>
    [XmlIgnore]
    public IEnumerable<IIssue> Warnings
    {
      get { return this.WarningsCollection.Cast<IIssue>(); }
    }

    /// <summary>
    ///   <para>Collection of validation warnings.</para>
    /// </summary>
    [XmlArray("warninglist")]
    [XmlArrayItem("warning")]
    public List<Issue> WarningsCollection { get; set; }

    /// <summary>
    ///   <para>Creates new group of validation warnings.</para>
    /// </summary>
    public WarningsList()
    {
      this.WarningsCollection = new List<Issue>();
    }
  }
}