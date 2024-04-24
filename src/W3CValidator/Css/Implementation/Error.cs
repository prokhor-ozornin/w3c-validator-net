using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace W3CValidator.Css;

/// <summary>
///   <para>Represents an error of CSS document's validation.</para>
/// </summary>
[DataContract(Name = "error")]
public sealed class Error : IError
{
  /// <summary>
  ///   <para>The actual error message.</para>
  /// </summary>
  [DataMember(Name = "message", IsRequired = true)]
  public string Message { get; set; }

  /// <summary>
  ///   <para>Base type of error.</para>
  /// </summary>
  [DataMember(Name = "errortype", IsRequired = true)]
  public string Type { get; set; }

  /// <summary>
  ///   <para>Subtype of error's type.</para>
  /// </summary>
  [DataMember(Name = "errorsubtype", IsRequired = true)]
  public string Subtype { get; set; }

  /// <summary>
  ///   <para>Erroneous property name.</para>
  /// </summary>
  [DataMember(Name = "property", IsRequired = true)]
  public string Property { get; set; }

  /// <summary>
  ///   <para>Within the source code of the validated document, refers to the line where the error was detected.</para>
  /// </summary>
  [DataMember(Name = "line", IsRequired = true)]
  public int? Line { get; set; }

  /// <summary>
  ///   <para>Context of error (surrounding text).</para>
  /// </summary>
  [DataMember(Name = "context", IsRequired = true)]
  public string Context { get; set; }

  /// <summary>
  ///   <para>String that was skipped, if any.</para>
  /// </summary>
  [DataMember(Name = "skippedstring", IsRequired = true)]
  public string SkippedString { get; set; }

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Error"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Error"/>.</returns>
  public override string ToString() => !Message.IsUnset() ? Line is not null? $"{Line}:{Message}" : Message : string.Empty;
}