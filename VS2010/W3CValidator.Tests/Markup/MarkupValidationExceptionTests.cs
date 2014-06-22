using System;
using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="MarkupValidationException"/>.</para>
  /// </summary>
  public sealed class MarkupValidationExceptionTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="ValidationException(string, Exception)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      Assert.Throws<ArgumentNullException>(() => new MarkupValidationException(null));
      Assert.Throws<ArgumentException>(() => new MarkupValidationException(string.Empty));

      var innerException = new Exception();
      var exception = new MarkupValidationException("message", innerException);
      Assert.True(ReferenceEquals(innerException, exception.InnerException));
      Assert.Equal("message", exception.Message);
    }
  }
}