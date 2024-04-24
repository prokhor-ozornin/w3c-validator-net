using Catharsis.Commons;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;
using W3CValidator.Markup;
using ErrorsGroup = W3CValidator.Markup.ErrorsGroup;
using WarningsGroup = W3CValidator.Markup.WarningsGroup;

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
  public void Url_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IMarkupRequestExecutorExtensions.Url(null, Attributes.LocalHost())).ThrowExactly<ArgumentNullException>().WithParameterName("executor");
      AssertionExtensions.Should(() => Validator.For.Markup.Request().Url(null)).ThrowExactly<ArgumentNullException>().WithParameterName("url");

      Validate(new MarkupValidationResult
      {
        Valid = true,
        Uri = "http://www.w3.org/",
        CheckedBy = "http://validator.w3.org/",
        Doctype = "-//W3C//DTD XHTML 1.0 Strict//EN",
        Encoding = "utf-8",
        ErrorsGroup = new ErrorsGroup(0),
        WarningsGroup = new WarningsGroup(0)
      }, "http://www.w3.org/".ToUri(), Validator.For.Markup.Request());
    }

    return;

    static void Validate(IMarkupValidationResult result, Uri url, IMarkupRequestExecutor executor)
    {
      using (executor)
      {
        var validation = executor.Url(url);

        validation.Should().BeOfType<MarkupValidationResult>();
        validation.Valid.Should().Be(result.Valid);
        validation.Uri.Should().Be(result.Uri);
        validation.CheckedBy.Should().Be(result.CheckedBy);
        validation.Date.Should().BeAfter(DateTimeOffset.MinValue);
        validation.Doctype.Should().Be(result.Doctype);
        validation.Encoding.Should().Be(result.Encoding);
        validation.ErrorsGroup.Count.Should().Be(result.ErrorsGroup.Count);
        validation.ErrorsGroup.Errors.Should().Equal(result.ErrorsGroup.Errors);
        validation.WarningsGroup.Count.Should().Be(result.WarningsGroup.Count);
        validation.WarningsGroup.Warnings.Should().Equal(result.WarningsGroup.Warnings);
      }
    }
  }
}