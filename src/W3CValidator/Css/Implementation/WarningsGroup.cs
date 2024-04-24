namespace W3CValidator.Css;

using System.Runtime.Serialization;

/// <summary>
///   <para>Logical group of validation warnings.</para>
/// </summary>
[CollectionDataContract(Name = "warnings", ItemName = "warninglist")]
public sealed class WarningsGroup : IWarningsGroup
{
  /// <summary>
  ///   <para>URI address of validated document or fragment.</para>
  /// </summary>
  [DataMember(Name = "uri", IsRequired = true)]
  public string Uri { get; set; }

  /// <summary>
  ///   <para>Collection of validation warnings .</para>
  /// </summary>
  [DataMember(Name = "warning", IsRequired = true)]
  public IList<IWarning> WarningsList { get; init; } = [];

  /// <summary>
  ///   <para></para>
  /// </summary>
  public IEnumerable<IWarning> Warnings => WarningsList;

  /// <summary>
  ///   <para></para>
  /// </summary>
  public WarningsGroup()
  {
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="uri"></param>
  /// <param name="warnings"></param>
  public WarningsGroup(string uri, IEnumerable<IWarning> warnings)
  {
    Uri = uri;
    WarningsList = warnings?.ToList() ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="uri"></param>
  /// <param name="warnings"></param>
  public WarningsGroup(string uri, params IWarning[] warnings) : this(uri, warnings as IEnumerable<IWarning>)
  {
  }

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="WarningsGroup"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="WarningsGroup"/>.</returns>
  public override string ToString() => Uri ?? string.Empty;
}