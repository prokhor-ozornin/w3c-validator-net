using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using W3CValidator.Markup;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="IMarkupValidationRequestExtensions"/>.</para>
/// </summary>
/// <seealso cref="IMarkupValidationRequestExtensions"/>
public sealed class IMarkupValidationRequestExtensionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IMarkupValidationRequestExtensions.Encoding(IMarkupValidationRequest, Encoding)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IMarkupValidationRequestExtensions.Encoding(null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Test(null, new MarkupValidationRequest());
      Encoding.GetEncodings().ForEach(encoding => Test(encoding.GetEncoding(), new MarkupValidationRequest()));
    }

    return;

    static void Test(Encoding encoding, IMarkupValidationRequest request) => request.Encoding(encoding).Should().BeSameAs(request).And.BeOfType<MarkupValidationRequest>().Which.Parameters["charset"].Should().Be(encoding?.WebName);
  }
}