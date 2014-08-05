using System.Collections.Generic;

namespace W3CValidator
{
  /// <summary>
  ///   <para>Abstract base implementation of <see cref="IValidationRequest"/> contract.</para>
  /// </summary>
  public abstract class ValidationRequest : IValidationRequest
  {
    private readonly IDictionary<string, object> parameters = new Dictionary<string, object>();

    /// <summary>
    ///   <para>Map of parameters (names/values) for the request.</para>
    /// </summary>
    public IDictionary<string, object> Parameters
    {
      get { return this.parameters; }
    }
  }
}