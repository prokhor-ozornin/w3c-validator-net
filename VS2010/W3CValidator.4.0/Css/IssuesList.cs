using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>List of errors and warnings encountered during the validation process.</para>
  /// </summary>
  [XmlType("result")]
  public sealed class IssuesList : IIssuesList
  {
    /// <summary>
    ///   <para>Collection of validation errors groups.</para>
    /// </summary>
    [XmlIgnore]
    public IEnumerable<IErrorsList> ErrorsGroups
    {
      get { return this.ErrorsGroupsCollection.Cast<IErrorsList>(); }
    }

    /// <summary>
    ///   <para>Collection of validation errors groups.</para>
    /// </summary>
    [XmlArray("errors")]
    [XmlArrayItem("errorlist")]
    public List<ErrorsList> ErrorsGroupsCollection { get; set; }

    /// <summary>
    ///   <para>Collection of validation errors groups.</para>
    /// </summary>
    [XmlIgnore]
    public IEnumerable<IWarningsList> WarningsGroups
    {
      get { return this.WarningsGroupsCollection.Cast<IWarningsList>(); }
    }

    /// <summary>
    ///   <para>Collection of validation errors groups.</para>
    /// </summary>
    [XmlArray("warnings")]
    [XmlArrayItem("warninglist")]
    public List<WarningsList> WarningsGroupsCollection { get; set; }

    /// <summary>
    ///   <para>Creates new list of validation issues.</para>
    /// </summary>
    public IssuesList()
    {
      this.ErrorsGroupsCollection = new List<ErrorsList>();
      this.WarningsGroupsCollection = new List<WarningsList>();
    }
  }
}