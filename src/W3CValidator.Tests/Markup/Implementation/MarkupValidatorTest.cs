﻿using Catharsis.Commons;
using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;
using W3CValidator.Css;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="MarkupValidator"/>.</para>
/// </summary>
public sealed class MarkupValidatorTest : UnitTest
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

      Validate(validator);
      Validate(validator, new MarkupValidationRequest());
    }

    return;

    static void Validate(IMarkupValidator validator, IMarkupValidationRequest request = null)
    {
      using var executor = validator.Request(request);

      executor.Should().BeOfType<MarkupRequestExecutor>();
      executor.GetPropertyValue<IMarkupValidationRequest>("Request").Should().BeSameAs(request);
    }
  }
}