using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="CssValidator"/>.</para>
  /// </summary>
  public sealed class CssValidatorTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidator.Call(IDictionary{string, object})"/></para>
    /// </summary>
    [Fact]
    public void Call_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new CssValidator().Call((IDictionary<string, object>) null));

      var validator = new CssValidator();

      try
      {
        validator.Call(new Dictionary<string, object>());
        throw new InvalidOperationException();
      }
      catch (CssValidationException exception)
      {
        Assert.Equal("No request parameters were specified", exception.Message);
        Assert.Null(exception.InnerException);
      }

      try
      {
        validator.Call(new Dictionary<string, object> { { "invalid", string.Empty } });
        throw new InvalidOperationException();
      }
      catch (CssValidationException exception)
      {
        Assert.Equal(@"Cannot validate CSS document or CSS fragment at endpoint URL ""http://jigsaw.w3.org/css-validator/validator""", exception.Message);
        Assert.True(exception.InnerException is WebException);
      }

      Assert.Equal("http://jigsaw.w3.org/css-validator/", validator.Call(new Dictionary<string, object> { { "text", "text" } }).CheckedBy);
    }
  }
}