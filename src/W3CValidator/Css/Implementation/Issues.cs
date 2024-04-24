using System.Runtime.Serialization;

namespace W3CValidator.Css;

/// <summary>
///   <para>List of errors and warnings encountered during the validation process.</para>
/// </summary>
[DataContract(Name = "result")]
public sealed class Issues : IIssues
{
  /// <summary>
  ///   <para>Collection of validation errors groups.</para>
  /// </summary>
  public IList<IErrorsGroup> ErrorsGroupsList { get; init; } = [];

  /// <summary>
  ///   <para>Collection of validation errors groups.</para>
  /// </summary>
  public IList<IWarningsGroup> WarningsGroupsList { get; init; } = [];

  /// <summary>
  ///   <para></para>
  /// </summary>
  public IEnumerable<IErrorsGroup> ErrorsGroups => ErrorsGroupsList;
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  public IEnumerable<IWarningsGroup> WarningsGroups => WarningsGroupsList;
}