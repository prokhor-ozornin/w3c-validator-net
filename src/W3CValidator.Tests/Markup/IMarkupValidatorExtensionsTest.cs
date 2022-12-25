using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using W3CValidator.Css;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="IMarkupValidatorExtensions"/>.</para>
/// </summary>
public sealed class IMarkupValidatorExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IMarkupValidatorExtensions.Request(IMarkupValidator, Action{IMarkupValidationRequest}?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Request_Method()
  {
    AssertionExtensions.Should(() => IMarkupValidatorExtensions.Request(null!)).ThrowExactly<ArgumentNullException>();

    using (var executor = IMarkupValidatorExtensions.Request(Validator.For.Markup))
    {
      executor.Should().NotBeNull().And.BeOfType<MarkupRequestExecutor>();
      executor.Property("Request").Should().BeNull();
    }

    using (var executor = Validator.For.Markup.Request(_ => {}))
    {
      executor.Should().NotBeNull().And.BeOfType<MarkupRequestExecutor>();
      executor.Property("Request").Should().NotBeNull();
    }
  }
}