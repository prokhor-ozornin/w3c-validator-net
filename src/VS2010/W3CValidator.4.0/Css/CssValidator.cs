using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Css
{
  internal sealed class CssValidator : ICssValidator
  {
    private const string EndpointUrl = "http://jigsaw.w3.org/css-validator/validator";

    public ICssValidationResult Call(IDictionary<string, object> parameters)
    {
      Assertion.NotNull(parameters);

      if (!parameters.Any())
      {
        throw new CssValidationException("No request parameters were specified");
      }

      try
      {
        using (var web = new WebClient())
        {
          web.QueryString["output"] = "soap12";
          foreach (var parameter in parameters)
          {
            web.QueryString[parameter.Key] = parameter.Value.ToStringInvariant().UrlEncode();
          }
          web.Headers["User-agent"] = "W3CValidator.NET client library";

          using (var response = web.OpenRead(EndpointUrl))
          {
            var reader = response.XmlReader(true);
            reader.ReadToFollowing("cssvalidationresponse", "http://www.w3.org/2005/07/css-validator");
            var result = new XmlSerializer(typeof(CssValidationResult)).Deserialize(reader).To<CssValidationResult>();
            reader.Close();
            return result;
          }
        }
      }
      catch (Exception exception)
      {
        throw new CssValidationException(@"Cannot validate CSS document or CSS fragment at endpoint URL ""{0}""".FormatInvariant(EndpointUrl), exception);
      }
    }
  }
}