using System;
using Xunit;

namespace W3CValidator
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ValidationException"/>.</para>
  /// </summary>
  public sealed class ValidationExceptionTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="ValidationException(string, Exception)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      Assert.Throws<ArgumentNullException>(() => new ValidationException(null));
      Assert.Throws<ArgumentException>(() => new ValidationException(string.Empty));

      var innerException = new Exception();
      var exception = new ValidationException("message", innerException);
      Assert.True(ReferenceEquals(innerException, exception.InnerException));
      Assert.Equal("message", exception.Message);
    }
  }
}