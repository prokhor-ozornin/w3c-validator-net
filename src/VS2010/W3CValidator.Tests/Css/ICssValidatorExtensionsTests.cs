using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ICssValidatorExtensions"/>.</para>
  /// </summary>
  public sealed class ICssValidatorExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ICssValidatorExtensions.Call(ICssValidator, object)"/> method.</para>
    /// </summary>
    [Fact]
    public void Call_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ICssValidatorExtensions.Call(null, new object()));
      Assert.Throws<ArgumentNullException>(() => new CssValidator().Call((object) null));

      var validator = new CssValidator();

      try
      {
        validator.Call(new { });
        throw new InvalidOperationException();
      }
      catch (CssValidationException exception)
      {
        Assert.Equal("No request parameters were specified", exception.Message);
        Assert.Null(exception.InnerException);
      }

      try
      {
        validator.Call(new { invalid = string.Empty });
        throw new InvalidOperationException();
      }
      catch (CssValidationException exception)
      {
        Assert.Equal(@"Cannot validate CSS document or CSS fragment at endpoint URL ""http://jigsaw.w3.org/css-validator/validator""", exception.Message);
        Assert.True(exception.InnerException is WebException);
      }

      Assert.Equal("http://jigsaw.w3.org/css-validator/", validator.Call(new { text = "text" }).CheckedBy);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ICssValidatorExtensions.Document(ICssValidator, string, Action{ICssValidationRequest})"/> method.</para>
    /// </summary>
    [Fact]
    public void Document_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ICssValidatorExtensions.Document(null, "text"));
      Assert.Throws<ArgumentNullException>(() => new CssValidator().Document(null));
      Assert.Throws<ArgumentException>(() => new CssValidator().Document(string.Empty));

      var validator = new CssValidator();

      var stylesheet = "text";

      var result = validator.Document(stylesheet);
      Assert.False(result.Valid);
      Assert.Equal("file://localhost/TextArea", result.Uri);
      Assert.Equal("http://jigsaw.w3.org/css-validator/", result.CheckedBy);
      Assert.Equal("css3", result.CssLevel);
      Assert.True(result.Date > DateTime.MinValue);

      var errorsGroup = result.Issues.ErrorsGroups.Single();
      Assert.Equal("file://localhost/TextArea", errorsGroup.Uri);
      var error = errorsGroup.Errors.Single();
      Assert.Equal(1, error.Line);
      Assert.Equal("parse-error", error.Type);
      Assert.Equal("text", error.Context);
      Assert.Equal("unrecognized", error.Subtype);
      Assert.Equal("[empty string]", error.SkippedString);
      Assert.Equal("Parse Error", error.Message);
      Assert.False(result.Issues.WarningsGroups.Any());


      stylesheet = Assembly.GetExecutingAssembly().GetManifestResourceStream("W3CValidator.Css.Stylesheet.css").Text(true);
      result = validator.Document(stylesheet, request => request.Profile(CssProfile.Css2).Language("ru").Warnings(WarningsLevel.Important));
      Assert.Equal("file://localhost/TextArea", result.Uri);
      Assert.Equal("http://jigsaw.w3.org/css-validator/", result.CheckedBy);
      Assert.Equal("css2", result.CssLevel);
      Assert.True(result.Date > DateTime.MinValue);
      Assert.False(result.Valid);
      errorsGroup = result.Issues.ErrorsGroups.Single();
      Assert.Equal("file://localhost/TextArea", errorsGroup.Uri);
      Assert.Equal(10, errorsGroup.Errors.Count());
      error = errorsGroup.Errors.ElementAt(6);
      Assert.Equal(184, error.Line);
      Assert.Equal("parse-error", error.Type);
      Assert.Equal(".button", error.Context);
      Assert.Equal("skippedString", error.Subtype);
      Assert.Equal(")", error.SkippedString);
      Assert.Equal("rgba(0,0,0,0.5) не может быть использовано с данной версией CSS css2", error.Message);
      var warningsGroup = result.Issues.WarningsGroups.Single();
      Assert.Equal("file://localhost/TextArea", warningsGroup.Uri);
      Assert.Equal(9, warningsGroup.Warnings.Count());
      var warning = warningsGroup.Warnings.First();
      Assert.Equal(38, warning.Line);
      Assert.Equal(0, warning.Level);
      Assert.Equal("Свойство -moz-inline-stack - неизвестное расширение поставщика", warning.Message);
      Assert.Null(warning.Context);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ICssValidatorExtensions.Url(ICssValidator, string, Action{ICssValidationRequest})"/> method.</para>
    /// </summary>
    [Fact]
    public void Url_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ICssValidatorExtensions.Url(null, "url"));
      Assert.Throws<ArgumentNullException>(() => new CssValidator().Url(null));
      Assert.Throws<ArgumentException>(() => new CssValidator().Url(string.Empty));

      var url = "http://www.w3.org/2008/site/css/minimum";
      var validator = new CssValidator();
      
      var result = validator.Url(url);
      Assert.Equal(url, result.Uri);
      Assert.Equal("http://jigsaw.w3.org/css-validator/", result.CheckedBy);
      Assert.Equal("css3", result.CssLevel);
      Assert.True(result.Date > DateTime.MinValue);
      Assert.True(result.Valid);
      Assert.False(result.Issues.ErrorsGroups.Any());

      var warningsGroup = result.Issues.WarningsGroups.Single();
      Assert.Equal("http://www.w3.org/2008/site/css/minimum.css", warningsGroup.Uri);
      Assert.Equal(11, warningsGroup.Warnings.Count());
      var warning = warningsGroup.Warnings.First();
      Assert.Null(warning.Context);
      Assert.Equal(0, warning.Level);
      Assert.Equal(38, warning.Line);
      Assert.Equal("Property -moz-inline-stack is an unknown vendor extension", warning.Message);
    }
  }
}