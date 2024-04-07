using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace W3CValidator.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ValidationException"/>.</para>
/// </summary>
public sealed class ValidationExceptionTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  ///   <seealso cref="ValidationException(string?, Exception?)"/>
  /// </summary>
  [Fact]
  public void Constructors()
  {
    using (new AssertionScope())
    {
      var exception = new ValidationException();
      exception.InnerException.Should().BeNull();
      exception.Message.Should().BeNull();

      var inner = new Exception();
      exception = new ValidationException("message", inner);
      exception.InnerException.Should().NotBeNull().And.BeSameAs(inner);
      exception.Message.Should().Be("message");
    }

    return;

    static void Validate()
    {

    }
  }
}