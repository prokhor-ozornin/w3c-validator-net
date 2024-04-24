using System.Text;
using Catharsis.Commons;
using W3CValidator.Markup;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="IMarkupValidationRequestExtensions"/>.</para>
/// </summary>
public sealed class IMarkupValidationRequestExtensionsTest : UnitTest
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

      Validate(null, new MarkupValidationRequest());
      Encoding.GetEncodings().ForEach(encoding => Validate(encoding.GetEncoding(), new MarkupValidationRequest()));
    }

    return;

    static void Validate(Encoding encoding, IMarkupValidationRequest request) => request.Encoding(encoding).Should().BeSameAs(request).And.BeOfType<MarkupValidationRequest>().Which.Parameters["charset"].Should().Be(encoding?.WebName);
  }
}