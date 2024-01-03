using System.Globalization;
using Catharsis.Commons;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="ICssValidationRequestExtensions"/>.</para>
/// </summary>
public sealed class ICssValidationRequestExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ICssValidationRequestExtensions.Language(ICssValidationRequest, CultureInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void Language_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICssValidationRequestExtensions.Language(null, null)).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null);
      CultureInfo.GetCultures(CultureTypes.AllCultures).ForEach(Validate);
    }

    return;

    static void Validate(CultureInfo culture)
    {
      var request = new CssValidationRequest();

      request.Parameters.Should().BeEmpty();

      request.Language(culture).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["lang"].Should().Be(culture?.TwoLetterISOLanguageName);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICssValidationRequestExtensions.Medium(ICssValidationRequest, CssMedium?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Medium_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICssValidationRequestExtensions.Medium(null, CssMedium.All)).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null);
      Enum.GetValues<CssMedium>().ForEach(medium => Validate(medium));
    }

    return;

    static void Validate(CssMedium? medium)
    {
      var request = new CssValidationRequest();

      request.Parameters.Should().BeEmpty();

      request.Medium(medium).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["usermedium"].Should().Be(medium?.ToInvariantString());
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICssValidationRequestExtensions.Profile(ICssValidationRequest, CssProfile?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Profile_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICssValidationRequestExtensions.Profile(null, CssProfile.Css1)).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null);
      Enum.GetValues<CssProfile>().ForEach(profile => Validate(profile));
    }

    return;

    static void Validate(CssProfile? profile)
    {
      var request = new CssValidationRequest();
      request.Parameters.Should().BeEmpty();

      request.Profile(profile).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["profile"].Should().Be(profile?.ToInvariantString());
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICssValidationRequestExtensions.Warnings(ICssValidationRequest, WarningsLevel?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Warnings_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICssValidationRequestExtensions.Warnings(null, WarningsLevel.All)).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null);
      Enum.GetValues<WarningsLevel>().ForEach(level => Validate(level));
    }

    return;

    static void Validate(WarningsLevel? level)
    {
      var request = new CssValidationRequest();

      request.Parameters.Should().BeEmpty();

      request.Warnings(level).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["warning"].Should().Be((int?) level);
    }
  }
}