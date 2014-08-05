using System;
using System.Globalization;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ICssValidationRequestExtensions"/>.</para>
  /// </summary>
  public sealed class ICssValidationRequestExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ICssValidationRequestExtensions.Language(ICssValidationRequest, CultureInfo)"/> method.</para>
    /// </summary>
    [Fact]
    public void Language_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ICssValidationRequestExtensions.Language(null, CultureInfo.InvariantCulture));
      Assert.Throws<ArgumentNullException>(() => ICssValidationRequestExtensions.Language(new CssValidationRequest(), null));

      var request = new CssValidationRequest();
      Assert.False(request.Parameters.ContainsKey("lang"));
      Assert.True(ReferenceEquals(request, request.Language(CultureInfo.InvariantCulture)));
      Assert.Equal(CultureInfo.InvariantCulture.TwoLetterISOLanguageName, request.Parameters["lang"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ICssValidationRequestExtensions.Medium(ICssValidationRequest, CssMedium)"/> method.</para>
    /// </summary>
    [Fact]
    public void Medium_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ICssValidationRequestExtensions.Medium(null, CssMedium.All));

      var request = new CssValidationRequest();
      Assert.False(request.Parameters.ContainsKey("usermedium"));
      Assert.True(ReferenceEquals(request, request.Medium(CssMedium.All)));
      Assert.Equal("all", request.Parameters["usermedium"]);
      Assert.Equal("aural", request.Medium(CssMedium.Aural).Parameters["usermedium"]);
      Assert.Equal("braille", request.Medium(CssMedium.Braille).Parameters["usermedium"]);
      Assert.Equal("embossed", request.Medium(CssMedium.Embossed).Parameters["usermedium"]);
      Assert.Equal("handheld", request.Medium(CssMedium.Handheld).Parameters["usermedium"]);
      Assert.Equal("presentation", request.Medium(CssMedium.Presentation).Parameters["usermedium"]);
      Assert.Equal("print", request.Medium(CssMedium.Print).Parameters["usermedium"]);
      Assert.Equal("project", request.Medium(CssMedium.Project).Parameters["usermedium"]);
      Assert.Equal("screen", request.Medium(CssMedium.Screen).Parameters["usermedium"]);
      Assert.Equal("tty", request.Medium(CssMedium.Tty).Parameters["usermedium"]);
      Assert.Equal("tv", request.Medium(CssMedium.Tv).Parameters["usermedium"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ICssValidationRequestExtensions.Profile(ICssValidationRequest, CssProfile)"/> method.</para>
    /// </summary>
    [Fact]
    public void Profile_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ICssValidationRequestExtensions.Profile(null, CssProfile.Css1));

      var request = new CssValidationRequest();
      Assert.False(request.Parameters.ContainsKey("profile"));
      Assert.True(ReferenceEquals(request, request.Profile(CssProfile.Css1)));
      Assert.Equal("css1", request.Parameters["profile"]);
      Assert.Equal("css2", request.Profile(CssProfile.Css2).Parameters["profile"]);
      Assert.Equal("css21", request.Profile(CssProfile.Css21).Parameters["profile"]);
      Assert.Equal("css3", request.Profile(CssProfile.Css3).Parameters["profile"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ICssValidationRequestExtensions.Warnings(ICssValidationRequest, WarningsLevel)"/> method.</para>
    /// </summary>
    [Fact]
    public void Warnings_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ICssValidationRequestExtensions.Warnings(null, WarningsLevel.All));

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