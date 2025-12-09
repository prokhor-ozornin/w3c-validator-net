using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using W3CValidator.Css;
using W3CValidator.Markup;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="MarkupValidator"/>.</para>
/// </summary>
/// <seealso cref="MarkupValidator"/>
public sealed class MarkupValidatorTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidator.Request(IMarkupValidationRequest)"/> method.</para>
  /// </summary>
  [Fact]
  public void Request_Method()
  {
    using (new AssertionScope())
    {
      var validator = Validator.For.Markup;

      Test(validator);
      Test(validator, new MarkupValidationRequest());
    }

    return;

    static void Test(IMarkupValidator validator, IMarkupValidationRequest request = null)
    {
      using var executor = validator.Request(request);

      executor.Should().BeOfType<MarkupRequestExecutor>().And.GetPropertyValue<IMarkupValidationRequest>("Request").Should().BeSameAs(request);
    }
  }
}