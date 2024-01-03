using Catharsis.Commons;
using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using W3CValidator.Css;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="MarkupValidator"/>.</para>
/// </summary>
public sealed class MarkupValidatorTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidator.Request(IMarkupValidationRequest?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Request_Method()
  {
    var validator = Validator.For.Markup;

    using (var executor = validator.Request())
    {
      executor.Should().NotBeNull().And.BeOfType<MarkupRequestExecutor>();
      executor.GetPropertyValue<IMarkupValidationRequest>("Request").Should().BeNull();
    }

    var request = new MarkupValidationRequest();
    using (var executor = validator.Request(request))
    {
      executor.Should().NotBeNull().And.BeOfType<MarkupRequestExecutor>();
      executor.GetPropertyValue<IMarkupValidationRequest>("Request").Should().NotBeNull().And.BeSameAs(request);
    }
  }
}