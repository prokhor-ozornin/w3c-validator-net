﻿using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using W3CValidator.Css;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="Issue"/>.</para>
/// </summary>
public sealed class IssueTest : UnitTest<Issue>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.MessageId"/> property.</para>
  /// </summary>
  [Fact]
  public void MessageId_Property() { new Issue(new {MessageId = Guid.Empty.ToString()}).MessageId.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Message"/> property.</para>
  /// </summary>
  [Fact]
  public void Message_Property() { new Issue(new {Message = Guid.Empty.ToString()}).Message.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property() { new Issue(new {Line = int.MaxValue}).Line.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Column"/> property.</para>
  /// </summary>
  [Fact]
  public void Column_Property() { new Issue(new {Column = int.MaxValue}).Column.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Source"/> property.</para>
  /// </summary>
  [Fact]
  public void Source_Property() { new Issue(new {Source = Guid.Empty.ToString()}).Source.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Explanation"/> property.</para>
  /// </summary>
  [Fact]
  public void Explanation_Property() { new Issue(new {Explanation = Guid.Empty.ToString()}).Explanation.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Issue(string?, string?, int?, int?, string?, string?)"/>
  /// <seealso cref="Issue(Issue.Info)"/>
  /// <seealso cref="Issue(object)"/>
  [Fact]
  public void Constructors()
  {
    var issue = new Issue();
    issue.MessageId.Should().BeNull();
    issue.Message.Should().BeNull();
    issue.Line.Should().BeNull();
    issue.Column.Should().BeNull();
    issue.Source.Should().BeNull();
    issue.Explanation.Should().BeNull();

    issue = new Issue(new Issue.Info());
    issue.MessageId.Should().BeNull();
    issue.Message.Should().BeNull();
    issue.Line.Should().BeNull();
    issue.Column.Should().BeNull();
    issue.Source.Should().BeNull();
    issue.Explanation.Should().BeNull();

    issue = new Issue(new {});
    issue.MessageId.Should().BeNull();
    issue.Message.Should().BeNull();
    issue.Line.Should().BeNull();
    issue.Column.Should().BeNull();
    issue.Source.Should().BeNull();
    issue.Explanation.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new Issue(new {Line = 1, Column = 2, MessageOriginal = "message"}).ToString().Should().Be("1:2 message"); }
}

/// <summary>
///   <para>Tests set for class <see cref="Issue.Info"/>.</para>
/// </summary>
public sealed class IssueInfoTests : UnitTest<Issue.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.MessageId"/> property.</para>
  /// </summary>
  [Fact]
  public void MessageId_Property() { new Issue(new {MessageId = Guid.Empty.ToString()}).MessageId.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Message"/> property.</para>
  /// </summary>
  [Fact]
  public void Message_Property() { new Issue(new {Message = "message"}).Message.Should().Be("message"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property() { new Issue(new {Line = int.MaxValue}).Line.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Column"/> property.</para>
  /// </summary>
  [Fact]
  public void Column_Property() { new Issue(new {Column = int.MaxValue}).Column.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Source"/> property.</para>
  /// </summary>
  [Fact]
  public void Source_Property() { new Issue(new {Source = Guid.Empty.ToString()}).Source.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Explanation"/> property.</para>
  /// </summary>
  [Fact]
  public void Explanation_Property() { new Issue(new {Explanation = Guid.Empty.ToString()}).Explanation.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Issue.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new Issue.Info();
    info.MessageId.Should().BeNull();
    info.Message.Should().BeNull();
    info.Line.Should().BeNull();
    info.Column.Should().BeNull();
    info.Source.Should().BeNull();
    info.Explanation.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Info.Result()"/> method.</para>
  /// </summary>
  [Fact]
  public void Result_Method()
  {
    var result = new Issue.Info().Result();
    result.Should().NotBeNull().And.BeOfType<Issue>();
    result.MessageId.Should().BeNull();
    result.Message.Should().BeNull();
    result.Line.Should().BeNull();
    result.Column.Should().BeNull();
    result.Source.Should().BeNull();
    result.Explanation.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var info = new Issues.Info();
    info.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}