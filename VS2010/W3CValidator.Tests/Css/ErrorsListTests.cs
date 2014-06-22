using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Css
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
      Assert.Equal("errorlist", xml.Root.Name);
      Assert.False(xml.Root.Elements("error").Any());
      Assert.Null(xml.Root.Element("uri"));
      Assert.Equal(list, list.Xml().Xml<ErrorsList>());

      list = new ErrorsList
      {
        ErrorsCollection = new List<Error>
        {
           new Error
           {
             ContextOriginal = "error.context",
             Line = 1,
             MessageOriginal = "error.message",
             PropertyOriginal = "error.property",
             SkippedStringOriginal = "error.skippedString",
             SubtypeOriginal = "error.subtype",
             TypeOriginal = "error.type"
           }
        },
        Uri = "uri"
      };
      xml = XDocument.Parse(list.Xml());
      Assert.Equal("errorlist", xml.Root.Name);
      Assert.Equal(1, xml.Root.Elements("error").Count());
      var error = xml.Root.Elements("error").Single();
      Assert.Equal("error.context", error.Element("context").Value);
      Assert.Equal("1", error.Element("line").Value);
      Assert.Equal("error.message", error.Element("message").Value);
      Assert.Equal("error.property", error.Element("property").Value);
      Assert.Equal("error.skippedString", error.Element("skippedstring").Value);
      Assert.Equal("error.subtype", error.Element("errorsubtype").Value);
      Assert.Equal("error.type", error.Element("errortype").Value);
      Assert.Equal("uri", xml.Root.Element("uri").Value);
      Assert.Equal(list, list.Xml().Xml<ErrorsList>());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="ErrorsList()"/>
    [Fact]
    public void Constructors()
    {
      var list = new ErrorsList();
      Assert.False(list.Errors.Any());
      Assert.Null(list.Uri);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ErrorsList.ErrorsCollection"/> property.</para>
    /// </summary>
    [Fact]
    public void ErrorsCollection_Property()
    {
      var list = new ErrorsList();
      var error = new Error();

      list.ErrorsCollection.Add(error);
      Assert.True(ReferenceEquals(list.Errors.Single(), error));

      list.ErrorsCollection.Remove(error);
      Assert.False(list.Errors.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ErrorsList.Uri"/> property.</para>
    /// </summary>
    [Fact]
    public void Uri_Property()
    {
      Assert.Equal("uri", new ErrorsList { Uri = "uri" }.Uri);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ErrorsList.Equals(ErrorsList)"/></description></item>
    ///     <item><description><see cref="ErrorsList.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Uri", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ErrorsList.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Uri", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ErrorsList.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("uri", new ErrorsList { Uri = "uri" }.ToString());
    }
  }
}