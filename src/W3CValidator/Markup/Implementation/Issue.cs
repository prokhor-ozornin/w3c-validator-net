using System.Runtime.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Markup;

/// <summary>
///   <para>Represents an issue (error/warning) of document's markup validation.</para>
/// </summary>
public sealed class Issue : IIssue
{
  /// <summary>
  ///   <para>The number/identifier of the issue, as addressed internally by the validator.</para>
  /// </summary>
  public string MessageId { get; }

  /// <summary>
  ///   <para>The actual issue message.</para>
  /// </summary>
  public string Message { get; }

  /// <summary>
  ///   <para>Within the source code of the validated document, refers to the line where the issue was detected.</para>
  /// </summary>
  public int? Line { get; }

  /// <summary>
  ///   <para>Within the source code of the validated document, refers to the column of the line where the issue was detected.</para>
  /// </summary>
  public int? Column { get; }

  /// <summary>
  ///   <para>Snippet of the source where the issue was found. Given as HTML fragment within CDATA block.</para>
  /// </summary>
  public string Source { get; }

  /// <summary>
  ///   <para>Explanation for the issue. Given as HTML fragment within CDATA block.</para>
  /// </summary>
  public string Explanation { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="messageId"></param>
  /// <param name="message"></param>
  /// <param name="line"></param>
  /// <param name="column"></param>
  /// <param name="source"></param>
  /// <param name="explanation"></param>
  public Issue(string messageId = null, string message = null, int? line = null, int? column = null, string source = null, string explanation = null)
  {
    MessageId = messageId;
    Message = message;
    Line = line;
    Column = column;
    Source = source;
    Explanation = explanation;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Issue(Info info)
  {
    MessageId = info.MessageId;
    Message = info.Message;
    Line = info.Line;
    Column = info.Column;
    Source = info.Source;
    Explanation = info.Explanation;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Issue(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Issue"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="Issue"/>.</returns>
  public override string ToString() => $"{Line}:{Column} {Message}";

  /// <summary>
  ///   <para></para>
  /// </summary>
  public sealed record Info : IResultable<IIssue>
  {
    /// <summary>
    ///   <para>The number/identifier of the issue, as addressed internally by the validator.</para>
    /// </summary>
    [DataMember(Name = "messageid", IsRequired = true)]
    public string MessageId { get; init; }

    /// <summary>
    ///   <para>The actual issue message.</para>
    /// </summary>
    [DataMember(Name = "message", IsRequired = true)]
    public string Message { get; init; }

    /// <summary>
    ///   <para>Within the source code of the validated document, refers to the line where the issue was detected.</para>
    /// </summary>
    [DataMember(Name = "line", IsRequired = true)]
    public int? Line { get; init; }

    /// <summary>
    ///   <para>Within the source code of the validated document, refers to the column of the line where the issue was detected.</para>
    /// </summary>
    [DataMember(Name = "col", IsRequired = true)]
    public int? Column { get; init; }

    /// <summary>
    ///   <para>Snippet of the source where the issue was found. Given as HTML fragment within CDATA block.</para>
    /// </summary>
    [DataMember(Name = "source", IsRequired = true)]
    public string Source { get; init; }

    /// <summary>
    ///   <para>Explanation for the issue. Given as HTML fragment within CDATA block.</para>
    /// </summary>
    [DataMember(Name = "explanation", IsRequired = true)]
    public string Explanation { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IIssue ToResult() => new Issue(this);
  }
}