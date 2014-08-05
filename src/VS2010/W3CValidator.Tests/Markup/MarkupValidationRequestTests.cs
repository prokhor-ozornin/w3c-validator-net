using System;
using System.Linq;
using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="MarkupValidationRequest"/>.</para>
  /// </summary>
  public sealed class MarkupValidationRequestTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="MarkupValidationRequest()"/>
    [Fact]
    public void Constructors()
    {
      var request = new MarkupValidationRequest();
      Assert.False(request.Parameters.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationRequest.Doctype(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Doctype_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new MarkupValidationRequest().Doctype(null));
      Assert.Throws<ArgumentException>(() => new MarkupValidationRequest().Doctype(string.Empty));

      var request = new MarkupValidationRequest();
      Assert.False(request.Parameters.ContainsKey("doctype"));
      Assert.True(ReferenceEquals(request, request.Doctype("doctype")));
      Assert.Equal("doctype", request.Parameters["doctype"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationRequest.Encoding(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Encoding_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new MarkupValidationRequest().Encoding(null));
      Assert.Throws<ArgumentException>(() => new MarkupValidationRequest().Encoding(string.Empty));

      var request = new MarkupValidationRequest();
      Assert.False(request.Parameters.ContainsKey("charset"));
      Assert.True(ReferenceEquals(request, request.Encoding("encoding")));
      Assert.Equal("encoding", request.Parameters["charset"]);
    }
  }
}