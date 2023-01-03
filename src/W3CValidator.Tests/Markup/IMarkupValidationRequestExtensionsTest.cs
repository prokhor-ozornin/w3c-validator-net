using System.Text;
using W3CValidator.Markup;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Commons;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="IMarkupValidationRequestExtensions"/>.</para>
/// </summary>
public sealed class IMarkupValidationRequestExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IMarkupValidationRequestExtensions.Encoding(IMarkupValidationRequest, Encoding?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    static void Validate(Encoding? encoding)
    {
      var request = new MarkupValidationRequest();
      
      request.Parameters.Should().BeEmpty();

      request.Encoding(encoding).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["charset"].Should().Be(encoding?.WebName);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IMarkupValidationRequestExtensions.Encoding(null, Encoding.Default)).ThrowExactly<ArgumentNullException>();
      AssertionExtensions.Should(() => IMarkupValidationRequestExtensions.Encoding(new MarkupValidationRequest(), null)).ThrowExactly<ArgumentNullException>();

      Validate(null);
      Encoding.GetEncodings().Select(info => info.GetEncoding()).ForEach(Validate);
    }
  }
}