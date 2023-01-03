using System.Runtime.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Css;

/// <summary>
///   <para>Represents a warning of CSS document's validation.</para>
/// </summary>
public sealed class Warning : IWarning
{
  /// <summary>
  ///   <para>The actual warning message.</para>
  /// </summary>
  public string Message { get; }

  /// <summary>
  ///   <para>The level of the warning's severity.</para>
  /// </summary>
  public int? Level { get; }

  /// <summary>
  ///   <para>Within the source code of the validated document, refers to the line where the warning was detected.</para>
  /// </summary>
  public int? Line { get; }

  /// <summary>
  ///   <para>Context of warning (surrounding text).</para>
  /// </summary>
  public string Context { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="message"></param>
  /// <param name="level"></param>
  /// <param name="line"></param>
  /// <param name="context"></param>
  public Warning(string message = null, int? level = null, int? line = null, string context = null)
  {
    Message = message;
    Level = level;
    Line = line;
    Context = context;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Warning(Info info)
  {
    Message = info.Message;
    Level = info.Level;
    Line = info.Line;
    Context = info.Context;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Warning(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Warning"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Warning"/>.</returns>
  public override string ToString() => $"{Line}:{Level} {Message}";

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "warning")]
  public sealed record Info : IResultable<IWarning>
  {
    /// <summary>
    ///   <para>The actual warning message.</para>
    /// </summary>
    [DataMember(Name = "message", IsRequired = true)]
    public string Message { get; init; }

    /// <summary>
    ///   <para>The level of the warning, only the ones whose level is under or equal to the value specified in the request will be displayed.</para>
    /// </summary>
    [DataMember(Name = "level", IsRequired = true)]
    public int? Level { get; init; }

    /// <summary>
    ///   <para>Within the source code of the validated document, refers to the line where the warning was detected.</para>
    /// </summary>
    [DataMember(Name = "line", IsRequired = true)]
    public int? Line { get; init; }

    /// <summary>
    ///   <para>Context of warning (surrounding text).</para>
    /// </summary>
    [DataMember(Name = "context", IsRequired = true)]
    public string Context { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IWarning Result() => new Warning(this);
  }
}