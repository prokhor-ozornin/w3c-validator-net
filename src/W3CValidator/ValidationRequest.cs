namespace W3CValidator;

/// <summary>
///   <para>Abstract base implementation of <see cref="IValidationRequest"/> contract.</para>
/// </summary>
public abstract class ValidationRequest : IValidationRequest
{
  /// <summary>
  ///   <para>Map of parameters (names/values) for the request.</para>
  /// </summary>
  public IDictionary<string, object?> Parameters { get; } = new Dictionary<string, object?>();
}