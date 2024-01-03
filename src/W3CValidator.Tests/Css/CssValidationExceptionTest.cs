using Catharsis.Commons;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="CssException"/>.</para>
/// </summary>
public sealed class CssValidationExceptionTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="CssException(string?, Exception?)"/>
  [Fact]
  public void Constructors()
  {
    var exception = new CssException();
    exception.InnerException.Should().BeNull();
    exception.Message.Should().BeNull();

    var inner = new Exception();
    exception = new CssException("message", inner);
    exception.InnerException.Should().NotBeNull().And.BeSameAs(inner);
    exception.Message.Should().Be("message");
  }
}