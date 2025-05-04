using AutoFixture;
using System.Text;
using Catharsis.Extensions;
using W3CValidator.Markup;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="MarkupValidationRequest"/>.</para>
/// </summary>
public sealed class MarkupValidationRequestTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="MarkupValidationRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(MarkupValidationRequest).Should().BeDerivedFrom<ValidationRequest>().And.Implement<IMarkupValidationRequest>();

    using (new AssertionScope())
    {
      var request = new MarkupValidationRequest();

      request.Parameters.Should().BeOfType<Dictionary<string, object>>().And.BeEmpty();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationRequest.Doctype(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Doctype_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, Fixture.Create<IMarkupValidationRequest>());
      Validate("html", Fixture.Create<IMarkupValidationRequest>());
    }

    return;

    static void Validate(string doctype, IMarkupValidationRequest request) => request.Doctype(doctype).Should().BeSameAs(request).And.BeOfType<MarkupValidationRequest>().Which.Parameters["doctype"].Should().Be(doctype);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationRequest.Encoding(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, Fixture.Create<IMarkupValidationRequest>());
      Encoding.GetEncodings().ForEach(encoding => Validate(encoding.Name, Fixture.Create<IMarkupValidationRequest>()));
    }

    return;

    static void Validate(string encoding, IMarkupValidationRequest request) => request.Encoding(encoding).Should().BeSameAs(request).And.BeOfType<MarkupValidationRequest>().Which.Parameters["charset"].Should().Be(encoding);
  }
}