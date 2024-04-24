using Catharsis.Commons;
using W3CValidator.Markup;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using W3CValidator.Css;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="Issue"/>.</para>
/// </summary>
public sealed class IssueTest : ClassTest<Issue>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Issue()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Issue).Should().BeDerivedFrom<object>().And.Implement<IIssue>();

    var issue = new Issue();
    issue.MessageId.Should().BeNull();
    issue.Message.Should().BeNull();
    issue.Line.Should().BeNull();
    issue.Column.Should().BeNull();
    issue.Source.Should().BeNull();
    issue.Explanation.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.MessageId"/> property.</para>
  /// </summary>
  [Fact]
  public void MessageId_Property()
  {
    new Issue { MessageId = "messageId" }.MessageId.Should().Be("messageId");  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Message"/> property.</para>
  /// </summary>
  [Fact]
  public void Message_Property()
  {
    new Issue { Message = "message" }.Message.Should().Be("message");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property()
  {
    new Issue { Line = int.MaxValue }.Line.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Column"/> property.</para>
  /// </summary>
  [Fact]
  public void Column_Property()
  {
    new Issue { Column = int.MaxValue }.Column.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Source"/> property.</para>
  /// </summary>
  [Fact]
  public void Source_Property()
  {
    new Issue { Source = "source" }.Source.Should().Be("source");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.Explanation"/> property.</para>
  /// </summary>
  [Fact]
  public void Explanation_Property()
  {
    new Issue { Explanation = "explanation" }.Explanation.Should().Be("explanation");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issue.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    using (new AssertionScope())
    {
      Validate("1:2 message", new Issue { Column = 2, Line = 1, Message = "message" });
    }

    return;

    static void Validate(string value, object instance) => instance.ToString().Should().Be(value);
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Issues());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
} 