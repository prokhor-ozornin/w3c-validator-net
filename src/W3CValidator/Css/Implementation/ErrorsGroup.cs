using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace W3CValidator.Css;

/// <summary>
///   <para>Logical group of validation errors.</para>
/// </summary>
public sealed class ErrorsGroup : IErrorsGroup
{
  /// <summary>
  ///   <para>URI address of validated document or fragment.</para>
  /// </summary>
  public string Uri { get; }

  /// <summary>
  ///   <para>Collection of validation errors.</para>
  /// </summary>
  public IEnumerable<IError> Errors { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="uri"></param>
  /// <param name="errors"></param>
  public ErrorsGroup(string uri = null, IEnumerable<IError> errors = null)
  {
    Uri = uri;
    Errors = errors ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public ErrorsGroup(Info info)
  {
    Uri = info.Uri;
    Errors = info.Errors ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public ErrorsGroup(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="ErrorsGroup"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="ErrorsGroup"/>.</returns>
  public override string ToString() => Uri ?? string.Empty;

  /// <summary>
  ///   <para></para>
  /// </summary>
  [CollectionDataContract(Name = "errors", ItemName = "errorlist")]
  public sealed record Info : IResultable<IErrorsGroup>
  {
    /// <summary>
    ///   <para>URI address of validated document or fragment.</para>
    /// </summary>
    [DataMember(Name = "uri", IsRequired = true)]
    public string Uri { get; init; }

    /// <summary>
    ///   <para>Collection of validation errors.</para>
    /// </summary>
    [DataMember(Name = "error", IsRequired = true)]
    public List<Error> Errors { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IErrorsGroup ToResult() => new ErrorsGroup(this);
  }
}