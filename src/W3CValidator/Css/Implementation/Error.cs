using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace W3CValidator.Css;

/// <summary>
///   <para>Represents an error of CSS document's validation.</para>
/// </summary>
public sealed class Error : IError
{
  /// <summary>
  ///   <para>The actual error message.</para>
  /// </summary>
  public string Message { get; }

  /// <summary>
  ///   <para>Base type of error.</para>
  /// </summary>
  public string Type { get; }

  /// <summary>
  ///   <para>Subtype of error's type.</para>
  /// </summary>
  public string Subtype { get; }

  /// <summary>
  ///   <para>Erroneous property name.</para>
  /// </summary>
  public string Property { get; }

  /// <summary>
  ///   <para>Within the source code of the validated document, refers to the line where the error was detected.</para>
  /// </summary>
  public int? Line { get; }

  /// <summary>
  ///   <para>Context of error (surrounding text).</para>
  /// </summary>
  public string Context { get; }

  /// <summary>
  ///   <para>String that was skipped, if any.</para>
  /// </summary>
  public string SkippedString { get; }

  /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
  public Error(string message = null, string type = null, string subtype = null, string property = null, int? line = null, string context = null, string skippedString = null)
  {
    Message = message;
    Type = type;
    Subtype = subtype;
    Property = property;
    Line = line;
    Context = context;
    SkippedString = skippedString;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Error(Info info)
  {
    Message = info.Message;
    Type = info.Type;
    Subtype = info.Subtype;
    Property = info.Property;
    Line = info.Line;
    Context = info.Context;
    SkippedString = info.SkippedString;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Error(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Error"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Error"/>.</returns>
  public override string ToString() => !Message.IsUnset() ? Line is not null? $"{Line}:{Message}" : Message : string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "error")]
  public sealed record Info : IResultable<IError>
  {
    /// <summary>
    ///   <para>The actual error message.</para>
    /// </summary>
    [DataMember(Name = "message", IsRequired = true)]
    public string Message { get; init; }

    /// <summary>
    ///   <para>Base type of error.</para>
    /// </summary>
    [DataMember(Name = "errortype", IsRequired = true)]
    public string Type { get; init; }

    /// <summary>
    ///   <para>Subtype of error's type.</para>
    /// </summary>
    [DataMember(Name = "errorsubtype", IsRequired = true)]
    public string Subtype { get; init; }

    /// <summary>
    ///   <para>Erroneous property name.</para>
    /// </summary>
    [DataMember(Name = "property", IsRequired = true)]
    public string Property { get; init; }

    /// <summary>
    ///   <para>Within the source code of the validated document, refers to the line where the error was detected.</para>
    /// </summary>
    [DataMember(Name = "line", IsRequired = true)]
    public int? Line { get; init; }

    /// <summary>
    ///   <para>Context of error (surrounding text).</para>
    /// </summary>
    [DataMember(Name = "context", IsRequired = true)]
    public string Context { get; init; }

    /// <summary>
    ///   <para>String that was skipped, if any.</para>
    /// </summary>
    [DataMember(Name = "skippedstring", IsRequired = true)]
    public string SkippedString { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IError ToResult() => new Error(this);
  }
}