using W3CValidator.Markup;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="MarkupValidationRequest"/>.</para>
/// </summary>
public sealed class MarkupValidationRequestTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="MarkupValidationRequest()"/>
  [Fact]
  public void Constructors()
  {
    var request = new MarkupValidationRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationRequest.Doctype(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Doctype_Method()
  {
    var request = new MarkupValidationRequest();

    request.Parameters.Should().BeEmpty();

    request.Doctype(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["doctype"].Should().BeNull();

    request.Doctype("html").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["doctype"].Should().Be("html");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationRequest.Encoding(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    var request = new MarkupValidationRequest();

    request.Parameters.Should().BeEmpty();

    request.Encoding(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["charset"].Should().BeNull();

    request.Encoding("utf-8").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["charset"].Should().Be("utf-8");
  }
}