using Catharsis.Commons;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="IMarkupRequestExecutorExtensions"/>.</para>
/// </summary>
public sealed class IMarkupRequestExecutorExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IMarkupRequestExecutorExtensions.Url(IMarkupRequestExecutor, Uri)"/> method.</para>
  /// </summary>
  [Fact]
  public void TryUrl_Method()
  {
    AssertionExtensions.Should(() => IMarkupRequestExecutorExtensions.Url(null, Attributes.LocalHost())).ThrowExactly<ArgumentNullException>().WithParameterName("executor");
    AssertionExtensions.Should(() => Validator.For.Markup.Request().Url(null)).ThrowExactly<ArgumentNullException>().WithParameterName("url");

    var validator = Validator.For.Markup;

    var url = "http://www.w3.org/".ToUri();

    using var executor = validator.Request();

    var result = executor.Url(url);
    result.Should().NotBeNull();
    result.Valid.Should().BeTrue();
    result.Uri.Should().Be(url.ToString());
    result.CheckedBy.Should().Be("http://validator.w3.org/");
    result.Date.Should().BeAfter(DateTimeOffset.MinValue);
    result.Doctype.Should().Be("-//W3C//DTD XHTML 1.0 Strict//EN");
    result.Encoding.Should().Be("utf-8");
    result.ErrorsGroup.Count.Should().Be(0);
    result.ErrorsGroup.Errors.Should().BeEmpty();
    result.WarningsGroup.Count.Should().Be(0);
    result.WarningsGroup.Warnings.Should().BeEmpty();
  }
}