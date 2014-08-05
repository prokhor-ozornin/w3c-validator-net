using System;
using System.Linq;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="CssValidationRequest"/>.</para>
  /// </summary>
  public sealed class CssValidationRequestTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="CssValidationRequest()"/>
    [Fact]
    public void Constructors()
    {
      var request = new CssValidationRequest();
      Assert.False(request.Parameters.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationRequest.Language(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Language_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new CssValidationRequest().Language(null));
      Assert.Throws<ArgumentException>(() => new CssValidationRequest().Language(string.Empty));

      var request = new CssValidationRequest();
      Assert.False(request.Parameters.ContainsKey("lang"));
      Assert.True(ReferenceEquals(request, request.Language("language")));
      Assert.Equal("language", request.Parameters["lang"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationRequest.Medium(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Medium_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new CssValidationRequest().Medium(null));
      Assert.Throws<ArgumentException>(() => new CssValidationRequest().Medium(string.Empty));

      var request = new CssValidationRequest();
      Assert.False(request.Parameters.ContainsKey("usermedium"));
      Assert.True(ReferenceEquals(request, request.Medium("medium")));
      Assert.Equal("medium", request.Parameters["usermedium"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationRequest.Profile(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Profile_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new CssValidationRequest().Profile(null));
      Assert.Throws<ArgumentException>(() => new CssValidationRequest().Profile(string.Empty));

      var request = new CssValidationRequest();
      Assert.False(request.Parameters.ContainsKey("profile"));
      Assert.True(ReferenceEquals(request, request.Profile("profile")));
      Assert.Equal("profile", request.Parameters["profile"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationRequest.Warnings(WarningsLevel)"/> method.</para>
    /// </summary>
    [Fact]
    public void Warnings_Method()
    {
      var request = new CssValidationRequest();

      Assert.False(request.Parameters.ContainsKey("warning"));
      Assert.True(ReferenceEquals(request, request.Warnings(WarningsLevel.All)));
      Assert.Equal(2, request.Parameters["warning"]);
      Assert.Equal(0, request.Warnings(WarningsLevel.Important).Parameters["warning"]);
      Assert.Equal(-1, request.Warnings(WarningsLevel.None).Parameters["warning"]);
      Assert.Equal(1, request.Warnings(WarningsLevel.Normal).Parameters["warning"]);
    }
  }
}