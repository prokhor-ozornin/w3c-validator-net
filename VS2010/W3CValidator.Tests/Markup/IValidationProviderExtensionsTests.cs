using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IValidationProviderExtensions"/>.</para>
  /// </summary>
  public sealed class IValidationProviderExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IValidationProviderExtensions.Markup(IValidationProvider)"/> method.</para>
    /// </summary>
    [Fact]
    public void Markup_Method()
    {
      Assert.NotNull(Validator.Validate.Markup());
      Assert.True(ReferenceEquals(Validator.Validate.Markup(), Validator.Validate.Markup()));
    }
  }
}