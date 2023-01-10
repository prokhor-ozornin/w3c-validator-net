using Catharsis.Extensions;

namespace W3CValidator;

/// <summary>
///   <para>Abstract base implementation of <see cref="IValidationRequest"/> contract.</para>
/// </summary>
public abstract class ValidationRequest : IValidationRequest
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  private readonly Dictionary<string, object> parameters = new();

  /// <summary>
  ///   <para>Map of parameters (names/values) for the request.</para>
  /// </summary>
  public IReadOnlyDictionary<string, object> Parameters => parameters;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="name"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  public IValidationRequest WithParameter(string name, object value)
  {
    if (name is null) throw new ArgumentNullException(nameof(name));
    if (name.IsEmpty()) throw new ArgumentException(nameof(name));

    parameters[name] = value;

    return this;
  }
}