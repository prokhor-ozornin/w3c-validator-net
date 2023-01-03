using System.Runtime.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Markup;

/// <summary>
///   <para>Logical group of validation warnings.</para>
/// </summary>
public sealed class WarningsGroup : IWarningsGroup
{
  /// <summary>
  ///   <para>URI address of validated document or fragment.</para>
  /// </summary>
  public int? Count { get; }

  /// <summary>
  ///   <para>Collection of validation errors.</para>
  /// </summary>
  public IEnumerable<IIssue> Warnings { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="count"></param>
  /// <param name="warnings"></param>
  public WarningsGroup(int? count = null, IEnumerable<IIssue> warnings = null)
  {
    Count = count;
    Warnings = warnings ?? new List<IIssue>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public WarningsGroup(Info info)
  {
    Count = info.Count;
    Warnings = info.Warnings?.Select(info => info.ToResult()) ?? Enumerable.Empty<IIssue>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public WarningsGroup(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "warnings")]
  public sealed record Info : IResultable<IWarningsGroup>
  {
    /// <summary>
    ///   <para>URI address of validated document or fragment.</para>
    /// </summary>
    [DataMember(Name = "warningcount", IsRequired = true)]
    public int? Count { get; init; }

    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    [DataMember(Name = "warninglist", IsRequired = true)]
    public WarningsCollection Warnings { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IWarningsGroup ToResult() => new WarningsGroup(this);
  }
}