using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Issue"/>.</para>
  /// </summary>
  public sealed class IssueTests : UnitTestsBase<Issue>
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var issue = new Issue();
      var xml = XDocument.Parse(issue.Xml());
      Assert.Equal("0", xml.Root.Element("col").Value);
      Assert.Null(xml.Root.Element("explanation"));
      Assert.Equal("0", xml.Root.Element("line").Value);
      Assert.Null(xml.Root.Element("message"));
      Assert.Null(xml.Root.Element("messageid"));
      Assert.Null(xml.Root.Element("source"));

      issue = new Issue
      {
        Column = 1,
        ExplanationOriginal = "explanation",
        Line = 2,
        MessageOriginal = "message",
        MessageId = "messageId",
        SourceOriginal = "source"
      };
      xml = XDocument.Parse(issue.Xml());
      Assert.Equal("1", xml.Root.Element("col").Value);
      Assert.Equal("explanation", xml.Root.Element("explanation").Value);
      Assert.Equal("2", xml.Root.Element("line").Value);
      Assert.Equal("message", xml.Root.Element("message").Value);
      Assert.Equal("messageId", xml.Root.Element("messageid").Value);
      Assert.Equal("source", xml.Root.Element("source").Value);
    }
    
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Issue()"/>
    [Fact]
    public void Constructors()
    {
      var issue = new Issue();
      Assert.Equal(0, issue.Column);
      Assert.Null(issue.ExplanationOriginal);
      Assert.Null(issue.Explanation);
      Assert.Equal(0, issue.Line);
      Assert.Null(issue.MessageOriginal);
      Assert.Null(issue.Message);
      Assert.Null(issue.MessageId);
      Assert.Null(issue.SourceOriginal);
      Assert.Null(issue.Source);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Issue.Column"/> property.</para>
    /// </summary>
    [Fact]
    public void Column_Property()
    {
      Assert.Equal(1, new Issue { Column = 1 }.Column);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Issue.ExplanationOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void ExplanationOriginal_Property()
    {
      var issue = new Issue { ExplanationOriginal = "explanation" };
      Assert.Equal("explanation", issue.ExplanationOriginal);
      Assert.Equal("explanation", issue.Explanation);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Issue.Line"/> property.</para>
    /// </summary>
    [Fact]
    public void Line_Property()
    {
      Assert.Equal(1, new Issue { Line = 1 }.Line);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Issue.MessageOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void MessageOriginal_Property()
    {
      var issue = new Issue { MessageOriginal = "message" };
      Assert.Equal("message", issue.MessageOriginal);
      Assert.Equal("message", issue.Message);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Issue.MessageId"/> property.</para>
    /// </summary>
    [Fact]
    public void MessageId_Property()
    {
      Assert.Equal("messageId", new Issue { MessageId = "messageId" }.MessageId);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Issue.SourceOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void SourceOriginal_Property()
    {
      var issue = new Issue { SourceOriginal = "source" };
      Assert.Equal("source", issue.SourceOriginal);
      Assert.Equal("source", issue.Source);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Issue.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("1:2 message", new Issue { Line = 1, Column = 2, MessageOriginal = "message" }.ToString());
    }
  }
}