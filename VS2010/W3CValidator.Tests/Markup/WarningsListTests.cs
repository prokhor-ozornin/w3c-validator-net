using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="WarningsList"/>.</para>
  /// </summary>
  public sealed class WarningsListTests : UnitTestsBase<WarningsList>
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var list = new WarningsList();
      var xml = XDocument.Parse(list.Xml());
      Assert.Equal("warnings", xml.Root.Name);
      Assert.Equal("0", xml.Root.Element("warningcount").Value);
      Assert.False(xml.Root.Element("warninglist").Elements("warning").Any());

      list = new WarningsList
      {
        Count = 1,
        WarningsCollection = new List<Issue>
        {
           new Issue
           {
             Column = 1,
             ExplanationOriginal = "warning.explanation",
             Line = 2,
             MessageOriginal = "warning.message",
             MessageId = "warning.messageId",
             SourceOriginal = "warning.source"
           }
        },
      };
      xml = XDocument.Parse(list.Xml());
      Assert.Equal("warnings", xml.Root.Name);
      Assert.Equal("1", xml.Root.Element("warningcount").Value);
      Assert.Equal(1, xml.Root.Element("warninglist").Elements("warning").Count());
      var error = xml.Root.Element("warninglist").Elements("warning").Single();
      Assert.Equal("1", error.Element("col").Value);
      Assert.Equal("warning.explanation", error.Element("explanation").Value);
      Assert.Equal("2", error.Element("line").Value);
      Assert.Equal("warning.message", error.Element("message").Value);
      Assert.Equal("warning.messageId", error.Element("messageid").Value);
      Assert.Equal("warning.source", error.Element("source").Value);
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="WarningsList()"/>
    [Fact]
    public void Constructors()
    {
      var list = new WarningsList();
      Assert.Equal(0, list.Count);
      Assert.False(list.Warnings.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WarningsList.Count"/> property.</para>
    /// </summary>
    [Fact]
    public void Count_Property()
    {
      Assert.Equal(1, new WarningsList { Count = 1 }.Count);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WarningsList.WarningsCollection"/> property.</para>
    /// </summary>
    [Fact]
    public void WarningsCollection_Property()
    {
      var list = new WarningsList();
      var warning = new Issue();

      list.WarningsCollection.Add(warning);
      Assert.True(ReferenceEquals(list.WarningsCollection.Single(), warning));

      list.WarningsCollection.Remove(warning);
      Assert.False(list.WarningsCollection.Any());
    }
  }
}