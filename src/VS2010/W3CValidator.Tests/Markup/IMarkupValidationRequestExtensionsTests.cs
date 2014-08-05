using System;
using System.Text;
using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IMarkupValidationRequestExtensions"/>.</para>
  /// </summary>
  public sealed class IMarkupValidationRequestExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IMarkupValidationRequestExtensions.Encoding(IMarkupValidationRequest, Encoding)"/> method.</para>
    /// </summary>
    [Fact]
    public void Encoding_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IMarkupValidationRequestExtensions.Encoding(null, Encoding.Default));
      Assert.Throws<ArgumentNullException>(() => IMarkupValidationRequestExtensions.Encoding(new MarkupValidationRequest(), null));

      var request = new MarkupValidationRequest();
      Assert.False(request.Parameters.ContainsKey("charset"));
      Assert.True(ReferenceEquals(request, request.Encoding(Encoding.ASCII)));
      Assert.Equal(Encoding.ASCII.ToString(), request.Parameters["charset"]);
    }
  }
}