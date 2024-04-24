using Catharsis.Commons;
using Catharsis.Extensions;
using W3CValidator.Css;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="CssValidator"/>.</para>
/// </summary>
public sealed class CssValidatorTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidator.Request(ICssValidationRequest)"/> method.</para>
  /// </summary>
  [Fact]
  public void Request_Method()
  {
    using (new AssertionScope())
    {
      var validator = Validator.For.Css;

      Validate(validator);
      Validate(validator, new CssValidationRequest());
    }

    return;

    static void Validate(ICssValidator validator, ICssValidationRequest request = null)
    {
      using var executor = validator.Request(request);

      executor.Should().BeOfType<CssRequestExecutor>();
      executor.GetPropertyValue<ICssValidationRequest>("Request").Should().BeSameAs(request);
    }
  }
}