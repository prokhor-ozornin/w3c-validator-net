using Xunit;

namespace W3CValidator
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Validator"/>.</para>
  /// </summary>
  public sealed class ValidatorTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="Validator.Validate"/> property.</para>
    /// </summary>
    [Fact]
    public void Validate_Property()
    {
      Assert.NotNull(Validator.Validate);
      Assert.True(ReferenceEquals(Validator.Validate, Validator.Validate));
    }
  }
}