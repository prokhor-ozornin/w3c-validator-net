using System;
using System.Linq;
using System.Net;
using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IMarkupValidatorExtensions"/>.</para>
  /// </summary>
  public sealed class IMarkupValidatorExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IMarkupValidatorExtensions.Call(IMarkupValidator, object)"/> method.</para>
    /// </summary>
    [Fact]
    public void Call_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IMarkupValidatorExtensions.Call(null, new object()));
      Assert.Throws<ArgumentNullException>(() => new MarkupValidator().Call((object)null));

      var validator = new MarkupValidator();

      try
      {
        validator.Call(new { });
        throw new InvalidOperationException();
      }
      catch (MarkupValidationException exception)
      {
        Assert.Equal("No request parameters were specified", exception.Message);
        Assert.Null(exception.InnerException);
      }

      Assert.Equal("http://validator.w3.org/", validator.Call(new { uri = "http://www.w3.org" }).CheckedBy);
    }
    
    /// <summary>
    ///   <para>Performs testing of <see cref="IMarkupValidatorExtensions.Url(IMarkupValidator, string, Action{IMarkupValidationRequest})"/> method.</para>
    /// </summary>
    [Fact]
    public void Url_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IMarkupValidatorExtensions.Url(null, "url"));
      Assert.Throws<ArgumentNullException>(() => new MarkupValidator().Url(null));
      Assert.Throws<ArgumentException>(() => new MarkupValidator().Url(string.Empty));

      var validator = new MarkupValidator();

      var url = "http://www.w3.org/";

      var result = validator.Url(url);
      Assert.True(result.Valid);
      Assert.Equal(url, result.Uri);
      Assert.Equal("http://validator.w3.org/", result.CheckedBy);
      Assert.True(result.Date > DateTime.MinValue);
      Assert.Equal("-//W3C//DTD XHTML 1.0 Strict//EN", result.Doctype);
      Assert.Equal("utf-8", result.Encoding);
      Assert.Equal(0, result.ErrorsList.Count);
      Assert.False(result.ErrorsList.Errors.Any());
      Assert.Equal(0, result.WarningsList.Count);
      Assert.False(result.WarningsList.Warnings.Any());
    }
  }
}