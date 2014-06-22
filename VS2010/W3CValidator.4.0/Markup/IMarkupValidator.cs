using System;
using System.Collections.Generic;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Represents a markup validator for hypertext documents or code fragments that makes use of W3C validation web service.</para>
  /// </summary>
  /// <seealso cref="http://validator.w3.org/docs/api.html"/>
  public interface IMarkupValidator
  {
    /// <summary>
    ///   <para>Makes a remote call to W3C markup validation web service, using provided set of request parameters.</para>
    /// </summary>
    /// <param name="parameters">Map of parameters names/values for the request.</param>
    /// <returns>Markup validation result instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="parameters"/> is a <c>null</c> reference.</exception>
    /// <exception cref="MarkupValidationException">If any error occured during the validation process.</exception>
    IMarkupValidationResult Call(IDictionary<string, object> parameters);
  }
}