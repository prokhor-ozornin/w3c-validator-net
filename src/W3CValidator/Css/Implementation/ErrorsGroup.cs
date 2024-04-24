using System.Runtime.Serialization;

namespace W3CValidator.Css;

/// <summary>
///   <para>Logical group of validation errors.</para>
/// </summary>
[CollectionDataContract(Name = "errors", ItemName = "errorlist")]
public sealed class ErrorsGroup : IErrorsGroup
{
  /// <summary>
  ///   <para>URI address of validated document or fragment.</para>
  /// </summary>
  [DataMember(Name = "uri", IsRequired = true)]
  public string Uri { get; set; }

  /// <summary>
  ///   <para>Collection of validation errors.</para>
  /// </summary>
  [DataMember(Name = "error", IsRequired = true)]
  public IList<IError> ErrorsList { get; init; } = [];

  /// <summary>
  ///   <para></para>
  /// </summary>
  public IEnumerable<IError> Errors => ErrorsList;

  /// <summary>
  ///   <para></para>
  /// </summary>
  public ErrorsGroup()
  {
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="uri"></param>
  /// <param name="errors"></param>
  public ErrorsGroup(string uri, IEnumerable<IError> errors)
  {
    Uri = uri;
    ErrorsList = errors?.ToList() ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="uri"></param>
  /// <param name="errors"></param>
  public ErrorsGroup(string uri, params IError[] errors) : this(uri, errors as IEnumerable<IError>)
  {
  }
  
  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="ErrorsGroup"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="ErrorsGroup"/>.</returns>
  public override string ToString() => Uri ?? string.Empty;
}