using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Error"/>.</para>
  /// </summary>
  public sealed class ErrorTests: UnitTestsBase<Error>
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var error = new Error();
      var xml = XDocument.Parse(error.Xml());
      Assert.Equal("error", xml.Root.Name);
      Assert.Null(xml.Root.Element("context"));
      Assert.Equal("0", xml.Root.Element("line").Value);
      Assert.Null(xml.Root.Element("message"));
      Assert.Null(xml.Root.Element("property"));
      Assert.Null(xml.Root.Element("skippedstring"));
      Assert.Null(xml.Root.Element("errorsubtype"));
      Assert.Null(xml.Root.Element("errortype"));

      error = new Error
      {
        ContextOriginal = "context",
        Line = 1,
        MessageOriginal = "message",
        PropertyOriginal = "property",
        SkippedStringOriginal = "skippedString",
        SubtypeOriginal = "subtype",
        TypeOriginal = "type"
      };
      xml = XDocument.Parse(error.Xml());
      Assert.Equal("error", xml.Root.Name);
      Assert.Equal("context", xml.Root.Element("context").Value);
      Assert.Equal("1", xml.Root.Element("line").Value);
      Assert.Equal("message", xml.Root.Element("message").Value);
      Assert.Equal("property", xml.Root.Element("property").Value);
      Assert.Equal("skippedString", xml.Root.Element("skippedstring").Value);
      Assert.Equal("subtype", xml.Root.Element("errorsubtype").Value);
      Assert.Equal("type", xml.Root.Element("errortype").Value);
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Error()"/>
    [Fact]
    public void Constructors()
    {
      var error = new Error();
      Assert.Null(error.ContextOriginal);
      Assert.Null(error.Context);
      Assert.Equal(0, error.Line);
      Assert.Null(error.MessageOriginal);
      Assert.Null(error.Message);
      Assert.Null(error.PropertyOriginal);
      Assert.Null(error.Property);
      Assert.Null(error.SkippedStringOriginal);
      Assert.Null(error.SkippedString);
      Assert.Null(error.SubtypeOriginal);
      Assert.Null(error.Subtype);
      Assert.Null(error.TypeOriginal);
      Assert.Null(error.Type);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Error.ContextOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void ContextOriginal_Property()
    {
      var error = new Error { ContextOriginal = "context" };
      Assert.Equal("context", error.ContextOriginal);
      Assert.Equal("context", error.Context);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Error.Line"/> property.</para>
    /// </summary>
    [Fact]
    public void Line_Property()
    {
      Assert.Equal(1, new Error { Line = 1 }.Line);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Error.MessageOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void MessageOriginal_Property()
    {
      var error = new Error { MessageOriginal = "message" };
      Assert.Equal("message", error.MessageOriginal);
      Assert.Equal("message", error.Message);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Error.PropertyOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void PropertyOriginal_Property()
    {
      var error = new Error { PropertyOriginal = "property" };
      Assert.Equal("property", error.PropertyOriginal);
      Assert.Equal("property", error.Property);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Error.SkippedStringOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void SkippedStringOriginal_Property()
    {
      var error = new Error { SkippedStringOriginal = "skippedString" };
      Assert.Equal("skippedString", error.SkippedStringOriginal);
      Assert.Equal("skippedString", error.SkippedString);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Error.SubtypeOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void SubtypeOriginal_Property()
    {
      var error = new Error { SubtypeOriginal = "subtype" };
      Assert.Equal("subtype", error.SubtypeOriginal);
      Assert.Equal("subtype", error.Subtype);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Error.TypeOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void TypeOriginal_Property()
    {
      var error = new Error { TypeOriginal = "type" };
      Assert.Equal("type", error.TypeOriginal);
      Assert.Equal("type", error.Type);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Error.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("1:message", new Error { Line = 1, MessageOriginal = "message" }.ToString());
    }
  }
}