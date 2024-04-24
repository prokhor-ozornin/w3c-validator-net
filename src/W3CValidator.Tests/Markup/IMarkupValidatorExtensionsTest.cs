using Catharsis.Commons;
using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;
using W3CValidator.Css;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="IMarkupValidatorExtensions"/>.</para>
/// </summary>
public sealed class IMarkupValidatorExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IMarkupValidatorExtensions.Request(IMarkupValidator, Action{IMarkupValidationRequest})"/> method.</para>
  /// </summary>
  [Fact]
  public void Request_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IMarkupValidatorExtensions.Request(null)).ThrowExactly<ArgumentNullException>().WithParameterName("validator");

      Validate(_ => { }, new MarkupValidator());
    }

    return;

    static void Validate(Action<IMarkupValidationRequest> request, IMarkupValidator validator)
    {
      using var executor = validator.Request(request);

      executor.Should().BeOfType<MarkupRequestExecutor>();
      executor.GetPropertyValue<IMarkupValidationRequest>("Request").Should().NotBeNull();
    }
  }
}