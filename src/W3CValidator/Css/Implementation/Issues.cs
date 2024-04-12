using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace W3CValidator.Css;

/// <summary>
///   <para>List of errors and warnings encountered during the validation process.</para>
/// </summary>
public sealed class Issues : IIssues
{
  /// <summary>
  ///   <para>Collection of validation errors groups.</para>
  /// </summary>
  public IEnumerable<IErrorsGroup> ErrorsGroups { get; }

  /// <summary>
  ///   <para>Collection of validation errors groups.</para>
  /// </summary>
  public IEnumerable<IWarningsGroup> WarningsGroups { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="errorsGroup"></param>
  /// <param name="warningsGroup"></param>
  public Issues(IEnumerable<IErrorsGroup> errorsGroup = null, IEnumerable<IWarningsGroup> warningsGroup = null)
  {
    ErrorsGroups = errorsGroup ?? [];
    WarningsGroups = warningsGroup ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Issues(Info info)
  {
    ErrorsGroups = (info.Errors ?? []).Select(info => info.ToResult());
    WarningsGroups = (info.Warnings ?? []).Select(info => info.ToResult());
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public Issues(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "result")]
  public sealed record Info : IResultable<IIssues>
  {
    /// <summary>
    ///   <para>Collection of validation errors groups.</para>
    /// </summary>
    public List<ErrorsGroup.Info> Errors { get; init; }

    /// <summary>
    ///   <para>Collection of validation errors groups.</para>
    /// </summary>
    public List<WarningsGroup.Info> Warnings { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IIssues ToResult() => new Issues(this);
  }
}