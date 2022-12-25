using System.Reflection;
using Catharsis.Commons;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="ICssRequestExecutorExtensions"/>.</para>
/// </summary>
public sealed class ICssRequestExecutorExtensionsTest
{
  private CancellationToken Cancellation { get; } = new(true);

  /// <summary>
  ///   <para>Performs testing of <see cref="ICssRequestExecutorExtensions.Document(ICssRequestExecutor, out ICssValidationResult?, string, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void Document_Method()
  {
    AssertionExtensions.Should(() => ICssRequestExecutorExtensions.Document(null!, out _, "document")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Validator.For.Css.Request().Document(out _, null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Validator.For.Css.Request().Document(out _, string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => Validator.For.Css.Request().Document(out _, "document", Cancellation)).ThrowExactly<TaskCanceledException>();

    var validator = Validator.For.Css;

    var stylesheet = "text";

    using (var executor = validator.Request())
    {
      executor.Document(out var result, stylesheet).Should().BeTrue();
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

    stylesheet = Assembly.GetExecutingAssembly().GetManifestResourceStream("W3CValidator.Css.Stylesheet.css").Text().Await();
    using (var executor = validator.Request(info => info.Profile(CssProfile.Css2).Language("ru").Warnings(WarningsLevel.Important)))
    {
      executor.Document(out var result, stylesheet).Should().BeTrue();
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
  ///   <para>Performs testing of <see cref="ICssRequestExecutorExtensions.Url(ICssRequestExecutor, out ICssValidationResult?, Uri, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void Url_Method()
  {
    AssertionExtensions.Should(() => ICssRequestExecutorExtensions.Url(null!, out _, "https://localhost".ToUri())).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Validator.For.Css.Request().Url(out _, null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Validator.For.Css.Request().Url(out _, "https://localhost".ToUri(), Cancellation)).ThrowExactly<TaskCanceledException>();

    var url = "http://www.w3.org/2008/site/css/minimum".ToUri();
    
    var validator = Validator.For.Css;

    using var executor = validator.Request();

    executor.Url(out var result, url).Should().BeTrue();
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