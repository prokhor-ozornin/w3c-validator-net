using System;
using System.Collections.Generic;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Represents a validator for CSS documents or code fragments that makes use of W3C validation web service.</para>
  /// </summary>
  /// <seealso cref="http://jigsaw.w3.org/css-validator/api.html"/>
  public interface ICssValidator
  {
    /// <summary>
    ///   <para>Makes a remote call to W3C CSS validation web service, using provided set of request parameters.</para>
    /// </summary>
    /// <param name="parameters">Map of parameters names/values for the request.</param>
    /// <returns>CSS validation result instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="parameters"/> is a <c>null</c> reference.</exception>
    /// <exception cref="CssValidationException">If any error occured during the validation process.</exception>
    ICssValidationResult Call(IDictionary<string, object> parameters);
  }
}