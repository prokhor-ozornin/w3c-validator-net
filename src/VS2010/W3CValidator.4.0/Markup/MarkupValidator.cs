using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace W3CValidator.Markup
{
  internal sealed class MarkupValidator : IMarkupValidator
  {
    private const string EndpointUrl = "http://validator.w3.org/check";

    public IMarkupValidationResult Call(IDictionary<string, object> parameters)
    {
      Assertion.NotNull(parameters);

      if (!parameters.Any())
      {
        throw new MarkupValidationException("No request parameters were specified");
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
            reader.ReadToFollowing("markupvalidationresponse", "http://www.w3.org/2005/10/markup-validator");
            var result = new XmlSerializer(typeof(MarkupValidationResult)).Deserialize(reader).To<MarkupValidationResult>();
            reader.Close();
            return result;
          }
        }
      }
      catch (Exception exception)
      {
        throw new MarkupValidationException(@"Cannot validate markup of document or document fragment at endpoint URL ""{0}""".FormatInvariant(EndpointUrl), exception);
      }
    }
  }
}