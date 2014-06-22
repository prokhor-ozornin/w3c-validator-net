using System;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IValidationProviderExtensions"/>.</para>
  /// </summary>
  public sealed class IValidationProviderExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IValidationProviderExtensions.Css(IValidationProvider)"/> method.</para>
    /// </summary>
    [Fact]
    public void Css_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IValidationProviderExtensions.Css(null));

      Assert.NotNull(Validator.Validate.Css());
      Assert.True(ReferenceEquals(Validator.Validate.Css(), Validator.Validate.Css()));
    }
  }
}