using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Css
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
      Assert.Equal("warninglist", xml.Root.Name);
      Assert.False(xml.Root.Elements("warning").Any());
      Assert.Null(xml.Root.Element("uri"));
      Assert.Equal(list, list.Xml().Xml<WarningsList>());

      list = new WarningsList
      {
        WarningsCollection = new List<Warning>
        {
           new Warning
           {
             Level = 1,
             Line = 2,
             MessageOriginal = "warning.message"
           }
        },
        Uri = "uri"
      };
      xml = XDocument.Parse(list.Xml());
      Assert.Equal("warninglist", xml.Root.Name);
      Assert.Equal(1, xml.Root.Elements("warning").Count());
      var error = xml.Root.Elements("warning").Single();
      Assert.Equal("1", error.Element("level").Value);
      Assert.Equal("2", error.Element("line").Value);
      Assert.Equal("warning.message", error.Element("message").Value);
      Assert.Equal("uri", xml.Root.Element("uri").Value);
      Assert.Equal(list, list.Xml().Xml<WarningsList>());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="WarningsList()"/>
    [Fact]
    public void Constructors()
    {
      var list = new WarningsList();
      Assert.False(list.Warnings.Any());
      Assert.Null(list.Uri);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WarningsList.WarningsCollection"/> property.</para>
    /// </summary>
    [Fact]
    public void WarningsCollection_Property()
    {
      var list = new WarningsList();
      var warning = new Warning();

      list.WarningsCollection.Add(warning);
      Assert.True(ReferenceEquals(list.Warnings.Single(), warning));

      list.WarningsCollection.Remove(warning);
      Assert.False(list.Warnings.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WarningsList.Uri"/> property.</para>
    /// </summary>
    [Fact]
    public void Uri_Property()
    {
      Assert.Equal("uri", new WarningsList { Uri = "uri" }.Uri);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="WarningsList.Equals(WarningsList)"/></description></item>
    ///     <item><description><see cref="WarningsList.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Uri", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WarningsList.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Uri", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WarningsList.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("uri", new WarningsList { Uri = "uri" }.ToString());
    }
  }
}