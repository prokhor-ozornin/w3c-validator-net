using Catharsis.Extensions;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="CssValidator"/>.</para>
/// </summary>
public sealed class CssValidatorTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidator.Request(ICssValidationRequest?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Request_Method()
  {
    var validator = Validator.For.Css;

    using (var executor = validator.Request())
    {
      executor.Should().NotBeNull().And.NotBeSameAs(validator.Request()).And.BeOfType<CssRequestExecutor>();
      executor.GetPropertyValue<ICssValidationRequest>("Request").Should().BeNull();
    }

    var request = new CssValidationRequest();

    using (var executor = validator.Request(request))
    {
      executor.Should().NotBeNull().And.NotBeSameAs(validator.Request(request)).And.BeOfType<CssRequestExecutor>();
      executor.GetPropertyValue<ICssValidationRequest>("Request").Should().NotBeNull().And.BeSameAs(request);
    }
  }
}