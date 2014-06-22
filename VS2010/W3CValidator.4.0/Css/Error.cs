using System.Xml.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Represents an error of CSS document's validation.</para>
  /// </summary>
  [XmlType("error")]
  public sealed class Error : IError
  {
    /// <summary>
    ///   <para>Context of error (surrounding text).</para>
    /// </summary>
    [XmlElement("context")]
    public string ContextOriginal { get; set; }

    /// <summary>
    ///   <para>Context of error (surrounding text).</para>
    /// </summary>
    [XmlIgnore]
    public string Context
    {
      get { return this.ContextOriginal == null ? null : this.ContextOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>Within the source code of the validated document, refers to the line where the error was detected.</para>
    /// </summary>
    [XmlElement("line")]
    public int Line { get; set; }

    /// <summary>
    ///   <para>The actual error message.</para>
    /// </summary>
    [XmlElement("message")]
    public string MessageOriginal { get; set; }

    /// <summary>
    ///   <para>The actual error message.</para>
    /// </summary>
    [XmlIgnore]
    public string Message
    {
      get { return this.MessageOriginal == null ? null : this.MessageOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>Erroneous property name.</para>
    /// </summary>
    [XmlElement("property")]
    public string PropertyOriginal { get; set; }

    /// <summary>
    ///   <para>Erroneous property name.</para>
    /// </summary>
    [XmlIgnore]
    public string Property
    {
      get { return this.PropertyOriginal == null ? null : this.PropertyOriginal.Trim(); }
    }
    
    /// <summary>
    ///   <para>String that was skipped, if any.</para>
    /// </summary>
    [XmlElement("skippedstring")]
    public string SkippedStringOriginal { get; set; }

    /// <summary>
    ///   <para>String that was skipped, if any.</para>
    /// </summary>
    [XmlIgnore]
    public string SkippedString
    {
      get { return this.SkippedStringOriginal == null ? null : this.SkippedStringOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>Subtype of error's type.</para>
    /// </summary>
    [XmlElement("errorsubtype")]
    public string SubtypeOriginal { get; set; }

    /// <summary>
    ///   <para>Subtype of error's type.</para>
    /// </summary>
    [XmlIgnore]
    public string Subtype
    {
      get { return this.SubtypeOriginal == null ? null : this.SubtypeOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>Base type of error.</para>
    /// </summary>
    [XmlElement("errortype")]
    public string TypeOriginal { get; set; }

    /// <summary>
    ///   <para>Base type of error.</para>
    /// </summary>
    [XmlIgnore]
    public string Type
    {
      get { return this.TypeOriginal == null ? null : this.TypeOriginal.Trim(); }
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Error"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Error"/>.</returns>
    public override string ToString()
    {
      return "{0}:{1}".FormatSelf(this.Line, this.Message);
    }
  }
}