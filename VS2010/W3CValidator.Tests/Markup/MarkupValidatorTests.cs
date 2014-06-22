using System;
using System.Collections.Generic;
using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="MarkupValidator"/>.</para>
  /// </summary>
  public sealed class MarkupValidatorTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidator.Call(IDictionary{string, object})"/> method.</para>
    /// </summary>
    [Fact]
    public void Call_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new MarkupValidator().Call((IDictionary<string, object>) null));

      var validator = new MarkupValidator();

      try
      {
        validator.Call(new Dictionary<string, object>());
        throw new InvalidOperationException();
      }
      catch (MarkupValidationException exception)
      {
        Assert.Equal("No request parameters were specified", exception.Message);
        Assert.Null(exception.InnerException);
      }

      Assert.Equal("http://validator.w3.org/", validator.Call(new Dictionary<string, object> { { "uri", "http://www.w3.org" } }).CheckedBy);
    }
  }
}