﻿using Catharsis.Commons;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="MarkupRequestExecutor"/>.</para>
/// </summary>
public sealed class MarkupRequestExecutorTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupRequestExecutor.UrlAsync(Uri, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void UrlAsync_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Validator.For.Markup.Request().UrlAsync(null)).ThrowExactlyAsync<ArgumentNullException>().WithParameterName("url").Await();
      AssertionExtensions.Should(() => Validator.For.Markup.Request().UrlAsync(Attributes.LocalHost(), Attributes.CancellationToken())).ThrowExactlyAsync<TaskCanceledException>().Await();

      var validator = Validator.For.Markup;

      var url = "http://www.w3.org/".ToUri();

      using var executor = validator.Request();

      var result = executor.UrlAsync(url).Await();
      result.Should().NotBeNull();
      result.Valid.Should().BeTrue();
      result.Uri.Should().Be(url.ToString());
      result.CheckedBy.Should().Be("http://validator.w3.org/");
      result.Date.Should().BeAfter(DateTimeOffset.MinValue);
      result.Doctype.Should().Be("-//W3C//DTD XHTML 1.0 Strict//EN");
      result.Encoding.Should().Be("utf-8");
      result.ErrorsGroup.Count.Should().Be(0);
      result.ErrorsGroup.Errors.Should().BeEmpty();
      result.WarningsGroup.Count.Should().Be(0);
      result.WarningsGroup.Warnings.Should().BeEmpty();
    }

    return;

    static void Validate()
    {

    }
  }
}