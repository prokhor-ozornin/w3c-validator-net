using System;
using System.Collections.Generic;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ICssValidator"/>.</para>
  /// </summary>
  /// <seealso cref="ICssValidator"/>
  public static class ICssValidatorExtensions
  {
    /// <summary>
    ///   <para>Makes a remote call to W3C CSS validation web service, using provided set of request parameters.</para>
    /// </summary>
    /// <param name="validator">CSS validator instance.</param>
    /// <param name="parameters">Map of parameters names/values for the request (public properties of object).</param>
    /// <returns>CSS validation result instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="validator"/> or <paramref name="parameters"/> is a <c>null</c> reference.</exception>
    /// <exception cref="CssValidationException">If any error occured during the validation process.</exception>
    public static ICssValidationResult Call(this ICssValidator validator, object parameters)
    {
      Assertion.NotNull(validator);
      Assertion.NotNull(parameters);

      return validator.Call(parameters.PropertiesMap());
    }

    /// <summary>
    ///   <para>Validates given fragment of CSS code, using W3C CSS validation web service.</para>
    /// </summary>
    /// <param name="validator">CSS validator instance.</param>
    /// <param name="document">CSS code fragment to be validated.</param>
    /// <param name="request">Delegate to configure additional parameters of request.</param>
    /// <returns>CSS validation result instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="validator"/> or <paramref name="document"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="document"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="CssValidationException">If any error occured during the validation process.</exception>
    public static ICssValidationResult Document(this ICssValidator validator, string document, Action<ICssValidationRequest> request = null)
    {
      Assertion.NotNull(validator);
      Assertion.NotEmpty(document);

      var parameters = new Dictionary<string, object> { { "text", document } };

      if (request != null)
      {
        var css = new CssValidationRequest();
        request(css);
        parameters.Add(css.Parameters);
      }

      return validator.Call(parameters);
    }

    /// <summary>
    ///   <para>Validates given fragment of CSS code, using W3C CSS validation web service.</para>
    /// </summary>
    /// <param name="validator">CSS validator instance.</param>
    /// <param name="document">CSS code fragment to be validated.</param>
    /// <param name="result">CSS validation result instance.</param>
    /// <param name="request">Delegate to configure additional parameters of request.</param>
    /// <returns><c>true</c> if request was successful and <paramref name="result"/> output parameter contains validation results, or <c>false</c> if request failed and <paramref name="result"/> is a <c>null</c> reference.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="validator"/> or <paramref name="document"/></exception>
    /// <exception cref="ArgumentException">If <paramref name="document"/> is <see cref="string.Empty"/> string.</exception>
    public static bool Document(this ICssValidator validator, string document, out ICssValidationResult result, Action<ICssValidationRequest> request = null)
    {
      Assertion.NotNull(validator);
      Assertion.NotEmpty(document);

      try
      {
        result = validator.Document(document, request);
        return true;
      }
      catch
      {
        result = null;
        return false;
      }
    }

    /// <summary>
    ///   <para>Validates CSS document, specified by its URL address, using W3C CSS validation web service.</para>
    /// </summary>
    /// <param name="validator">CSS validator instance.</param>
    /// <param name="url">URL address of document to be validated.</param>
    /// <param name="request">Delegate to configure additional parameters of request.</param>
    /// <returns>CSS validation result instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="validator"/> or <paramref name="url"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="url"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="CssValidationException">If any error occured during the validation process.</exception>
    public static ICssValidationResult Url(this ICssValidator validator, string url, Action<ICssValidationRequest> request = null)
    {
      Assertion.NotNull(validator);
      Assertion.NotEmpty(url);

      var parameters = new Dictionary<string, object> { { "uri", url } };

      if (request != null)
      {
        var css = new CssValidationRequest();
        request(css);
        parameters.Add(css.Parameters);
      }

      return validator.Call(parameters);
    }

    /// <summary>
    ///   <para>Validates CSS document, specified by its URL address, using W3C CSS validation web service.</para>
    /// </summary>
    /// <param name="validator">CSS validator instance.</param>
    /// <param name="url">URL address of document to be validated.</param>
    /// <param name="result">CSS validation result instance.</param>
    /// <param name="request">Delegate to configure additional parameters of request.</param>
    /// <returns><c>true</c> if request was successful and <paramref name="result"/> output parameter contains validation results, or <c>false</c> if request failed and <paramref name="result"/> is a <c>null</c> reference.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="validator"/> or <paramref name="url"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="url"/> is <see cref="string.Empty"/> string.</exception>
    public static bool Url(this ICssValidator validator, string url, out ICssValidationResult result, Action<ICssValidationRequest> request = null)
    {
      Assertion.NotNull(validator);
      Assertion.NotEmpty(url);

      try
      {
        result = validator.Url(url, request);
        return true;
      }
      catch
      {
        result = null;
        return false;
      }
    }
  }
}