using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Warning"/>.</para>
  /// </summary>
  public sealed class WarningTests : UnitTestsBase<Warning>
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var warning = new Warning();
      var xml = XDocument.Parse(warning.Xml());
      Assert.Equal("warning", xml.Root.Name);
      Assert.Null(xml.Root.Element("context"));
      Assert.Equal("0", xml.Root.Element("level").Value);
      Assert.Equal("0", xml.Root.Element("line").Value);
      Assert.Null(xml.Root.Element("message"));

      warning = new Warning
      {
        ContextOriginal = "context",
        Level = 1,
        Line = 2,
        MessageOriginal = "message"
      };
      xml = XDocument.Parse(warning.Xml());
      Assert.Equal("warning", xml.Root.Name);
      Assert.Equal("context", xml.Root.Element("context").Value);
      Assert.Equal("1", xml.Root.Element("level").Value);
      Assert.Equal("2", xml.Root.Element("line").Value);
      Assert.Equal("message", xml.Root.Element("message").Value);
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Warning()"/>
    [Fact]
    public void Constructors()
    {
      var warning = new Warning();
      Assert.Null(warning.ContextOriginal);
      Assert.Null(warning.Context);
      Assert.Equal(0, warning.Level);
      Assert.Equal(0, warning.Line);
      Assert.Null(warning.MessageOriginal);
      Assert.Null(warning.Message);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Warning.ContextOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void ContextOriginal_Property()
    {
      var warning = new Warning { ContextOriginal = "context" };
      Assert.Equal("context", warning.ContextOriginal);
      Assert.Equal("context", warning.Context);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Warning.Level"/> property.</para>
    /// </summary>
    [Fact]
    public void Level_Property()
    {
      Assert.Equal(1, new Warning { Level = 1 }.Level);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Warning.Line"/> property.</para>
    /// </summary>
    [Fact]
    public void Line_Property()
    {
      Assert.Equal(1, new Warning { Line = 1 }.Line);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Warning.MessageOriginal"/> property.</para>
    /// </summary>
    [Fact]
    public void MessageOriginal_Property()
    {
      var error = new Warning { MessageOriginal = "message" };
      Assert.Equal("message", error.MessageOriginal);
      Assert.Equal("message", error.Message);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Warning.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("1:2 message", new Warning { Level = 2, Line = 1, MessageOriginal = "message" }.ToString());
    }
  }
}