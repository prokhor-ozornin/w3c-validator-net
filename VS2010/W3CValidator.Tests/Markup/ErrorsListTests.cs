using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ErrorsList"/>.</para>
  /// </summary>
  public sealed class ErrorsListTests : UnitTestsBase<ErrorsList>
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var list = new ErrorsList();
      var xml = XDocument.Parse(list.Xml());
      Assert.Equal("errors", xml.Root.Name);
      Assert.Equal("0", xml.Root.Element("errorcount").Value);
      Assert.False(xml.Root.Element("errorlist").Elements("error").Any());

      list = new ErrorsList
      {
        Count = 1,
        ErrorsCollection = new List<Issue>
        {
           new Issue
           {
             Column = 1,
             ExplanationOriginal = "error.explanation",
             Line = 2,
             MessageOriginal = "error.message",
             MessageId = "error.messageId",
             SourceOriginal = "error.source"
           }
        },
      };
      xml = XDocument.Parse(list.Xml());
      Assert.Equal("errors", xml.Root.Name);
      Assert.Equal("1", xml.Root.Element("errorcount").Value);
      Assert.Equal(1, xml.Root.Element("errorlist").Elements("error").Count());
      var error = xml.Root.Element("errorlist").Elements("error").Single();
      Assert.Equal("1", error.Element("col").Value);
      Assert.Equal("error.explanation", error.Element("explanation").Value);
      Assert.Equal("2", error.Element("line").Value);
      Assert.Equal("error.message", error.Element("message").Value);
      Assert.Equal("error.messageId", error.Element("messageid").Value);
      Assert.Equal("error.source", error.Element("source").Value);
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="ErrorsList()"/>
    [Fact]
    public void Constructors()
    {
      var list = new ErrorsList();
      Assert.Equal(0, list.Count);
      Assert.False(list.Errors.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ErrorsList.Count"/> property.</para>
    /// </summary>
    [Fact]
    public void Count_Property()
    {
      Assert.Equal(1, new ErrorsList { Count = 1 }.Count);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ErrorsList.ErrorsCollection"/> property.</para>
    /// </summary>
    [Fact]
    public void ErrorsCollection_Property()
    {
      var list = new ErrorsList();
      var error = new Issue();

      list.ErrorsCollection.Add(error);
      Assert.True(ReferenceEquals(list.ErrorsCollection.Single(), error));

      list.ErrorsCollection.Remove(error);
      Assert.False(list.ErrorsCollection.Any());
    }
  }
}