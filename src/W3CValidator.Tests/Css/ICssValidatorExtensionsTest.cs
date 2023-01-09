﻿using Catharsis.Extensions;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="ICssValidatorExtensions"/>.</para>
/// </summary>
public sealed class ICssValidatorExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ICssValidatorExtensions.Request(ICssValidator, Action{ICssValidationRequest})"/> method.</para>
  /// </summary>
  [Fact]
  public void Request_Method()
  {
    AssertionExtensions.Should(() => ICssValidatorExtensions.Request(null)).ThrowExactly<ArgumentNullException>().WithParameterName("validator");

    using (var executor = ICssValidatorExtensions.Request(Validator.For.Css))
    {
      executor.Should().NotBeNull().And.BeOfType<CssRequestExecutor>();
      executor.GetPropertyValue<ICssValidationRequest>("Request").Should().BeNull();
    }

    using (var executor = Validator.For.Css.Request(_ => {}))
    {
      executor.Should().NotBeNull().And.BeOfType<CssRequestExecutor>();
      executor.GetPropertyValue<ICssValidationRequest>("Request").Should().NotBeNull();
    }
  }
}