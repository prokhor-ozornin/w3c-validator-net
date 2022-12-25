﻿using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ValidationException"/>.</para>
/// </summary>
public sealed class ValidationExceptionTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  ///   <seealso cref="ValidationException(string?, Exception?)"/>
  /// </summary>
  [Fact]
  public void Constructors()
  {
    var exception = new ValidationException();
    exception.InnerException.Should().BeNull();
    exception.Message.Should().BeNull();

    var inner = new Exception();
    exception = new ValidationException("message", inner);
    exception.InnerException.Should().NotBeNull().And.BeSameAs(inner);
    exception.Message.Should().Be("message");
  }
}