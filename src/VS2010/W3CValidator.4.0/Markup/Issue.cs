using System.Xml.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Represents an issue (error/warning) of document's markup validation.</para>
  /// </summary>
  public sealed class Issue : IIssue
  {
    /// <summary>
    ///   <para>Within the source code of the validated document, refers to the column of the line where the issue was detected.</para>
    /// </summary>
    [XmlElement("col")]
    public int Column { get; set; }

    /// <summary>
    ///   <para>Explanation for the issue. Given as HTML fragment within CDATA block.</para>
    /// </summary>
    [XmlElement("explanation")]
    public string ExplanationOriginal { get; set; }

    /// <summary>
    ///   <para>Explanation for the issue. Given as HTML fragment within CDATA block.</para>
    /// </summary>
    [XmlIgnore]
    public string Explanation
    {
      get { return this.ExplanationOriginal == null ? null : this.ExplanationOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>Within the source code of the validated document, refers to the line where the issue was detected.</para>
    /// </summary>
    [XmlElement("line")]
    public int Line { get; set; }

    /// <summary>
    ///   <para>The actual issue message.</para>
    /// </summary>
    [XmlElement("message")]
    public string MessageOriginal { get; set; }

    /// <summary>
    ///   <para>The actual issue message.</para>
    /// </summary>
    [XmlIgnore]
    public string Message
    {
      get { return this.MessageOriginal == null ? null : this.MessageOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>The number/identifier of the issue, as addressed internally by the validator.</para>
    /// </summary>
    [XmlElement("messageid")]
    public string MessageId { get; set; }

    /// <summary>
    ///   <para>Snippet of the source where the issue was found. Given as HTML fragment within CDATA block.</para>
    /// </summary>
    [XmlElement("source")]
    public string SourceOriginal { get; set; }

    /// <summary>
    ///   <para>Snippet of the source where the issue was found. Given as HTML fragment within CDATA block.</para>
    /// </summary>
    [XmlIgnore]
    public string Source
    {
      get { return this.SourceOriginal == null ? null : this.SourceOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Issue"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Issue"/>.</returns>
    public override string ToString()
    {
      return "{0}:{1} {2}".FormatSelf(this.Line, this.Column, this.Message);
    }
  }
}