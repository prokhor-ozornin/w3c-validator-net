using System.Xml.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Represents a warning of CSS document's validation.</para>
  /// </summary>
  [XmlType("warning")]
  public sealed class Warning : IWarning
  {
    /// <summary>
    ///   <para>Context of warning (surrounding text).</para>
    /// </summary>
    [XmlElement("context")]
    public string ContextOriginal { get; set; }

    /// <summary>
    ///   <para>Context of warning (surrounding text).</para>
    /// </summary>
    [XmlIgnore]
    public string Context
    {
      get { return this.ContextOriginal == null ? null : this.ContextOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>The level of the warning, only the ones whose level is under or equal to the value specified in the request will be displayed.</para>
    /// </summary>
    [XmlElement("level")]
    public int Level { get; set; }

    /// <summary>
    ///   <para>Within the source code of the validated document, refers to the line where the warning was detected.</para>
    /// </summary>
    [XmlElement("line")]
    public int Line { get; set; }

    /// <summary>
    ///   <para>The actual warning message.</para>
    /// </summary>
    [XmlElement("message")]
    public string MessageOriginal { get; set; }

    /// <summary>
    ///   <para>The actual warning message.</para>
    /// </summary>
    [XmlIgnore]
    public string Message
    {
      get { return this.MessageOriginal == null ? null : this.MessageOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Warning"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Warning"/>.</returns>
    public override string ToString()
    {
      return "{0}:{1} {2}".FormatSelf(this.Line, this.Level, this.Message);
    }
  }
}