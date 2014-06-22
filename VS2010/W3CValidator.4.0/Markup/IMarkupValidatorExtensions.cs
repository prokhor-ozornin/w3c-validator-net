using System;
using System.Collections.Generic;
using Catharsis.Commons;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IMarkupValidator"/>.</para>
  /// </summary>
  /// <seealso cref="IMarkupValidator"/>
  public static class IMarkupValidatorExtensions
  {
    /// <summary>
    ///   <para>Makes a remote call to W3C markup validation web service, using provided set of request parameters.</para>
    /// </summary>
    /// <param name="validator">Markup validator instance.</param>
    /// <param name="parameters">Map of parameters names/values for the request (public properties of object).</param>
    /// <returns>Markup validation result instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="validator"/> or <paramref name="parameters"/> is a <c>null</c> reference.</exception>
    /// <exception cref="MarkupValidationException"></exception>
    public static IMarkupValidationResult Call(this IMarkupValidator validator, object parameters)
    {
      Assertion.NotNull(validator);
      Assertion.NotNull(parameters);

      return validator.Call(parameters.PropertiesMap());
    }

    /// <summary>
    ///   <para>Validates markup of a document which is specified by its URL address, using W3C markup validation web service.</para>
    /// </summary>
    /// <param name="validator">Markup validator instance.</param>
    /// <param name="url">URL address of document to be validated.</param>
    /// <param name="request">Delegate to configure additional parameters of request.</param>
    /// <returns>Markup validation result instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="validator"/> or <paramref name="url"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="url"/> is <see cref="string.Empty"/> string.</exception>
    public static IMarkupValidationResult Url(this IMarkupValidator validator, string url, Action<IMarkupValidationRequest> request = null)
    {
      Assertion.NotNull(validator);
      Assertion.NotEmpty(url);

      var parameters = new Dictionary<string, object> { { "uri", url } };

      if (request != null)
      {
        var markup = new MarkupValidationRequest();
        request(markup);
        parameters.Add(markup.Parameters);
      }

      return validator.Call(parameters);
    }

    /// <summary>
    ///   <para>Validates markup of a document which is specified by its URL address, using W3C markup validation web service.</para>
    /// </summary>
    /// <param name="validator">Markup validator instance.</param>
    /// <param name="url">URL address of document to be validated.</param>
    /// <param name="result">Markup validation result instance.</param>
    /// <param name="request">Delegate to configure additional parameters of request.</param>
    /// <returns><c>true</c> if request was successful and <paramref name="result"/> output parameter contains validation results, or <c>false</c> if request failed and <paramref name="result"/> is a <c>null</c> reference.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="validator"/> or <paramref name="url"/> </exception>
    public static bool Url(this IMarkupValidator validator, string url, out IMarkupValidationResult result, Action<IMarkupValidationRequest> request = null)
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