using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;
using Catharsis.Commons;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="CssValidationRequest"/>.</para>
/// </summary>
public sealed class CssValidationRequestTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="CssValidationRequest()"/>
  [Fact]
  public void Constructors()
  {
    var request = new CssValidationRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationRequest.Language(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Language_Method()
  {
    var request = new CssValidationRequest();

    request.Parameters.Should().BeEmpty();

    request.Language(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["lang"].Should().BeNull();

    request.Language("ru").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["lang"].Should().Be("ru");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationRequest.Medium(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Medium_Method()
  {
    var request = new CssValidationRequest();

    request.Parameters.Should().BeEmpty();

    request.Medium(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["user-medium"].Should().BeNull();

    request.Medium("screen").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["user-medium"].Should().Be("screen");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationRequest.Profile(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Profile_Method()
  {
    var request = new CssValidationRequest();

    request.Parameters.Should().BeEmpty();

    request.Profile(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["profile"].Should().BeNull();

    request.Profile("personal").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["profile"].Should().Be("personal");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationRequest.Warnings(int?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Warnings_Method()
  {
    static void Validate(WarningsLevel? level)
    {
      var request = new CssValidationRequest();

      request.Parameters.Should().BeEmpty();

      request.Warnings(level).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["warning"].Should().Be((int?) level);
    }

    using (new AssertionScope())
    {
      Validate(null);
      Enum.GetValues<WarningsLevel>().ForEach(level => Validate(level));
    }
  }
}