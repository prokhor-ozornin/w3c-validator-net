namespace W3CValidator.Css;

using System.Runtime.Serialization;
using Catharsis.Commons;

/// <summary>
///   <para>Logical group of validation warnings.</para>
/// </summary>
public sealed class WarningsGroup : IWarningsGroup
{
  /// <summary>
  ///   <para>URI address of validated document or fragment.</para>
  /// </summary>
  public string Uri { get; }

  /// <summary>
  ///   <para>Collection of validation warnings .</para>
  /// </summary>
  public IEnumerable<IWarning> Warnings { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="uri"></param>
  /// <param name="warnings"></param>
  public WarningsGroup(string uri = null, IEnumerable<IWarning> warnings = null)
  {
    Uri = uri;
    Warnings = warnings ?? new List<IWarning>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public WarningsGroup(Info info)
  {
    Uri = info.Uri;
    Warnings = info.Warnings ?? new List<Warning>();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public WarningsGroup(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="WarningsGroup"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="WarningsGroup"/>.</returns>
  public override string ToString() => Uri ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [CollectionDataContract(Name = "warnings", ItemName = "warninglist")]
  public sealed record Info : IResultable<IWarningsGroup>
  {
    /// <summary>
    ///   <para>URI address of validated document or fragment.</para>
    /// </summary>
    [DataMember(Name = "uri", IsRequired = true)]
    public string Uri { get; init; }

    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    [DataMember(Name = "warning", IsRequired = true)]
    public List<Warning> Warnings { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IWarningsGroup ToResult() => new WarningsGroup(this);
  }
}