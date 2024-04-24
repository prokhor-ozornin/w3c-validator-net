using System.Runtime.Serialization;

namespace W3CValidator.Css;

/// <summary>
///   <para>Represents a warning of CSS document's validation.</para>
/// </summary>
[DataContract(Name = "warning")]
public sealed class Warning : IWarning
{
  /// <summary>
  ///   <para>The actual warning message.</para>
  /// </summary>
  [DataMember(Name = "message", IsRequired = true)]
  public string Message { get; set; }

  /// <summary>
  ///   <para>The level of the warning's severity.</para>
  /// </summary>
  [DataMember(Name = "level", IsRequired = true)]
  public int? Level { get; set; }

  /// <summary>
  ///   <para>Within the source code of the validated document, refers to the line where the warning was detected.</para>
  /// </summary>
  [DataMember(Name = "line", IsRequired = true)]
  public int? Line { get; set; }

  /// <summary>
  ///   <para>Context of warning (surrounding text).</para>
  /// </summary>
  [DataMember(Name = "context", IsRequired = true)]
  public string Context { get; set; }

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Warning"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Warning"/>.</returns>
  public override string ToString() => $"{Line}:{Level} {Message}";
}