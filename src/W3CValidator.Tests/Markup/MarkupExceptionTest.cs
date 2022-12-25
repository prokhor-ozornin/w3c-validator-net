using W3CValidator.Markup;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="MarkupException"/>.</para>
/// </summary>
public sealed class MarkupExceptionTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  ///   <seealso cref="MarkupException(string?, Exception?)"/>
  /// </summary>
  [Fact]
  public void Constructors()
  {
    var exception = new MarkupException();
    exception.InnerException.Should().BeNull();
    exception.Message.Should().BeNull();

    var inner = new Exception();
    exception = new MarkupException("message", inner);
    exception.InnerException.Should().NotBeNull().And.BeSameAs(inner);
    exception.Message.Should().Be("message");
  }
}