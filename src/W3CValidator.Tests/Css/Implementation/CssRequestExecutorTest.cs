using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using System.Reflection;
using Catharsis.Commons;
using Catharsis.Extensions;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="CssRequestExecutor"/>.</para>
/// </summary>
public sealed class CssRequestExecutorTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="CssRequestExecutor.DocumentAsync(string, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void DocumentAsync_Method()
  {
    AssertionExtensions.Should(() => Validator.For.Css.Request().DocumentAsync(null)).ThrowExactlyAsync<ArgumentNullException>().WithParameterName("document").Await();
    AssertionExtensions.Should(() => Validator.For.Css.Request().DocumentAsync(string.Empty, Attributes.CancellationToken())).ThrowExactlyAsync<OperationCanceledException>().Await();

    var validator = Validator.For.Css;
    var stylesheet = "text";

    using (var executor = validator.Request())
    {
      var result = executor.DocumentAsync(stylesheet).Await();
      result.Should().NotBeNull();
      result.Valid.Should().BeFalse();
      result.Uri.Should().Be("file://localhost/TextArea");
      result.CheckedBy.Should().Be("http://jigsaw.w3.org/css-validator/");
      result.CssLevel.Should().Be("css3");
      result.Date.Should().BeAfter(DateTimeOffset.MinValue);
      var errorsGroup = result.Issues.ErrorsGroups.Single();
      errorsGroup.Uri.Should().Be("file://localhost/TextArea");
      var error = errorsGroup.Errors.Single();
      error.Line.Should().Be(1);
      error.Type.Should().Be("parse-error");
      error.Context.Should().Be("text");
      error.Subtype.Should().Be("unrecognized");
      error.SkippedString.Should().Be("[empty string]");
      error.Message.Should().Be("Parse Error");
      result.Issues.Warnings.Should().BeEmpty();
    }

    stylesheet = Assembly.GetExecutingAssembly().GetManifestResourceStream("W3CValidator.Css.Stylesheet.css").ToTextAsync().Await();
    using (var executor = validator.Request(request => request.Profile(CssProfile.Css2).Language("ru").Warnings(WarningsLevel.Important)))
    {
      var result = executor.DocumentAsync(stylesheet).Await();
      result.Should().NotBeNull();
      result.Uri.Should().Be("file://localhost/TextArea");
      result.CheckedBy.Should().Be("http://jigsaw.w3.org/css-validator/");
      result.CssLevel.Should().Be("css2");
      result.Date.Should().BeAfter(DateTimeOffset.MinValue);
      result.Valid.Should().BeFalse();
      var errorsGroup = result.Issues.ErrorsGroups.Single();
      errorsGroup.Uri.Should().Be("file://localhost/TextArea");
      errorsGroup.Errors.Should().HaveCount(10);
      var error = errorsGroup.Errors.ElementAt(6);
      error.Line.Should().Be(184);
      error.Type.Should().Be("parse-error");
      error.Context.Should().Be(".button");
      error.Subtype.Should().Be("skippedString");
      error.SkippedString.Should().Be(")");
      error.Message.Should().Be("rgba(0,0,0,0.5) не может быть использовано с данной версией CSS css2");
      var warningsGroup = result.Issues.WarningsGroups.Single();
      warningsGroup.Uri.Should().Be("file://localhost/TextArea");
      warningsGroup.Warnings.Should().HaveCount(9);
      var warning = warningsGroup.Warnings.First();
      warning.Line.Should().Be(38);
      warning.Level.Should().Be(0);
      warning.Message.Should().Be("Свойство -moz-inline-stack - неизвестное расширение поставщика");
      warning.Context.Should().BeNull();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssRequestExecutor.UrlAsync(Uri, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void UrlAsync_Method()
  {
    AssertionExtensions.Should(() => Validator.For.Css.Request().UrlAsync(null)).ThrowExactlyAsync<ArgumentNullException>().WithParameterName("url").Await();
    AssertionExtensions.Should(() => Validator.For.Css.Request().UrlAsync(Attributes.LocalHost(), Attributes.CancellationToken())).ThrowExactlyAsync<OperationCanceledException>().Await();

    var url = "http://www.w3.org/2008/site/css/minimum".ToUri();
    var validator = Validator.For.Css;

    using var executor = validator.Request();

    var result = executor.UrlAsync(url).Await();
    result.Should().NotBeNull();
    result.Uri.Should().Be(url.ToString());
    result.CheckedBy.Should().Be("http://jigsaw.w3.org/css-validator/");
    result.CssLevel.Should().Be("css3");
    result.Date.Should().BeAfter(DateTimeOffset.MinValue);
    result.Valid.Should().BeTrue();
    result.Issues.ErrorsGroups.Should().BeEmpty();

    var warningsGroup = result.Issues.WarningsGroups.Single();
    warningsGroup.Uri.Should().Be("http://www.w3.org/2008/site/css/minimum.css");
    warningsGroup.Warnings.Should().HaveCount(11);
    var warning = warningsGroup.Warnings.First();
    warning.Context.Should().BeNull();
    warning.Level.Should().Be(0);
    warning.Line.Should().Be(38);
    warning.Message.Should().Be("Property -moz-inline-stack is an unknown vendor extension");
  }
}