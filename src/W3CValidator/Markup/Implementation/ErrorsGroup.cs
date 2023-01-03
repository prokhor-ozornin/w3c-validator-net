using System.Runtime.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Markup;

/// <summary>
///   <para>Logical group of validation errors.</para>
/// </summary>
public sealed class ErrorsGroup : IErrorsGroup
{
  /// <summary>
  ///   <para>URI address of validated document or fragment.</para>
  /// </summary>
  public int? Count { get; }

  /// <summary>
  ///   <para>Collection of validation errors.</para>
  /// </summary>
  public IEnumerable<IIssue> Errors { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="count"></param>
  /// <param name="errors"></param>
  public ErrorsGroup(int? count = null, IEnumerable<IIssue> errors = null)
  {
    Count = count;
    Errors = errors ?? new List<IIssue>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public ErrorsGroup(Info info)
  {
    Count = info.Count;
    Errors = info.Errors?.Select(info => info.Result()) ?? Enumerable.Empty<IIssue>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public ErrorsGroup(object info) : this(new Info().SetState(info))
  {
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "errors")]
  public sealed record Info : IResultable<IErrorsGroup>
  {
    /// <summary>
    ///   <para>URI address of validated document or fragment.</para>
    /// </summary>
    [DataMember(Name = "errorcount", IsRequired = true)]
    public int? Count { get; init; }

    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    [DataMember(Name = "errorlist", IsRequired = true)]
    public ErrorsCollection Errors { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IErrorsGroup Result() => new ErrorsGroup(this);
  }
}