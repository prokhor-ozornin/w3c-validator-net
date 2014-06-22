using System;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="CssValidationException"/>.</para>
  /// </summary>
  public sealed class CssValidationExceptionTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="CssValidationException(string, Exception)"/>
    [Fact]
    public void Constructors()
    {
      Assert.Throws<ArgumentNullException>(() => new CssValidationException(null));
      Assert.Throws<ArgumentException>(() => new CssValidationException(string.Empty));

      var innerException = new Exception();
      var exception = new CssValidationException("message", innerException);
      Assert.True(ReferenceEquals(innerException, exception.InnerException));
      Assert.Equal("message", exception.Message);
    }
  }
}