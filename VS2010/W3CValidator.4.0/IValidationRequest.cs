using System.Collections.Generic;

namespace W3CValidator
{
  /// <summary>
  ///   <para>Represents a custom request for any W3C validation service.</para>
  /// </summary>
  public interface IValidationRequest
  {
    /// <summary>
    ///   <para>Map of parameters (names/values) for the request.</para>
    /// </summary>
    IDictionary<string, object> Parameters { get; }
  }
}