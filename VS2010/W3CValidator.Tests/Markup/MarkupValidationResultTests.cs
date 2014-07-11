using System;
using System.Linq;
using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Markup
{
  /// <summary>
  ///   <para>Tests set for class <see cref="MarkupValidationResult"/>.</para>
  /// </summary>
  public sealed class MarkupValidationResultTests : UnitTestsBase<MarkupValidationResult>
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      XNamespace ns = "http://www.w3.org/2005/10/markup-validator";

      var result = new MarkupValidationResult();
      var xml = XDocument.Parse(result.ToXml());
      Assert.Equal(ns + "markupvalidationresponse", xml.Root.Name);
      Assert.Null(xml.Root.Element(ns + "checkedby"));
      Assert.Null(xml.Root.Element(ns + "doctype"));
      Assert.Null(xml.Root.Element(ns + "charset"));
      Assert.Equal(1, xml.Root.Element(ns + "errors").Elements(ns + "errorlist").Count());
      Assert.Equal("0", xml.Root.Element(ns + "errors").Element(ns + "errorcount").Value);
      Assert.False(xml.Root.Element(ns + "errors").Element(ns + "errorlist").Elements("error").Any());
      Assert.Null(xml.Root.Element(ns + "uri"));
      Assert.Equal("false", xml.Root.Element(ns + "validity").Value);
      Assert.Equal("0", xml.Root.Element(ns + "warnings").Element(ns + "warningcount").Value);
      Assert.Equal(1, xml.Root.Element(ns + "warnings").Elements(ns + "warninglist").Count());
      Assert.False(xml.Root.Element(ns + "warnings").Element(ns + "warninglist").Elements("warning").Any());
      Assert.True(result.Equals(result.ToXml().AsXml<MarkupValidationResult>()));

      result = new MarkupValidationResult
      {
        CheckedBy = "checkedBy",
        Doctype = "doctype",
        Encoding = "encoding",
        Uri = "uri",
        Valid = true
      };
      xml = XDocument.Parse(result.ToXml());
      Assert.Equal(ns + "markupvalidationresponse", xml.Root.Name);
      Assert.Equal("checkedBy", xml.Root.Element(ns + "checkedby").Value);
      Assert.Equal("doctype", xml.Root.Element(ns + "doctype").Value);
      Assert.Equal("encoding", xml.Root.Element(ns + "charset").Value);
      Assert.Equal("0", xml.Root.Element(ns + "errors").Element(ns + "errorcount").Value);
      Assert.Equal(1, xml.Root.Element(ns + "errors").Elements(ns + "errorlist").Count());
      Assert.False(xml.Root.Element(ns + "errors").Element(ns + "errorlist").Elements("error").Any());
      Assert.Equal("uri", xml.Root.Element(ns + "uri").Value);
      Assert.Equal("true", xml.Root.Element(ns + "validity").Value);
      Assert.Equal("0", xml.Root.Element(ns + "warnings").Element(ns + "warningcount").Value);
      Assert.Equal(1, xml.Root.Element(ns + "warnings").Elements(ns + "warninglist").Count());
      Assert.False(xml.Root.Element(ns + "warnings").Element(ns + "warninglist").Elements("warning").Any());
      Assert.True(result.Equals(result.ToXml().AsXml<MarkupValidationResult>()));
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="MarkupValidationResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new MarkupValidationResult();
      Assert.Null(result.CheckedBy);
      Assert.True(result.Date > DateTime.MinValue);
      Assert.True(result.Date <= DateTime.UtcNow);
      Assert.Null(result.Doctype);
      Assert.Null(result.Encoding);
      Assert.Equal(0, result.Errors.Count);
      Assert.False(result.ErrorsList.Errors.Any());
      Assert.Null(result.Uri);
      Assert.False(result.Valid);
      Assert.Equal(0, result.Warnings.Count);
      Assert.False(result.WarningsList.Warnings.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.CheckedBy"/> property.</para>
    /// </summary>
    [Fact]
    public void CheckedBy_Property()
    {
      Assert.Equal("checkedBy", new MarkupValidationResult { CheckedBy = "checkedBy" }.CheckedBy);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new MarkupValidationResult { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.Doctype"/> property.</para>
    /// </summary>
    [Fact]
    public void Doctype_Property()
    {
      Assert.Equal("doctype", new MarkupValidationResult { Doctype = "doctype" }.Doctype);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.Encoding"/> property.</para>
    /// </summary>
    [Fact]
    public void Encoding_Property()
    {
      Assert.Equal("encoding", new MarkupValidationResult { Encoding = "encoding" }.Encoding);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.Errors"/> property.</para>
    /// </summary>
    [Fact]
    public void Errors_Property()
    {
      var errorsList = new ErrorsList();
      var result = new MarkupValidationResult { Errors = errorsList };

      Assert.True(ReferenceEquals(errorsList, result.Errors));
      Assert.True(ReferenceEquals(errorsList, result.ErrorsList));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.Uri"/> property.</para>
    /// </summary>
    [Fact]
    public void Uri_Property()
    {
      Assert.Equal("uri", new MarkupValidationResult { Uri = "uri" }.Uri);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.Valid"/> property.</para>
    /// </summary>
    [Fact]
    public void Valid_Property()
    {
      Assert.True(new MarkupValidationResult { Valid = true }.Valid);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.Warnings"/> property.</para>
    /// </summary>
    [Fact]
    public void Warnings_Property()
    {
      var warningsList = new WarningsList();
      var result = new MarkupValidationResult { Warnings = warningsList };

      Assert.True(ReferenceEquals(warningsList, result.Warnings));
      Assert.True(ReferenceEquals(warningsList, result.WarningsList));
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="MarkupValidationResult.Equals(IMarkupValidationResult)"/></description></item>
    ///     <item><description><see cref="MarkupValidationResult.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Uri", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Uri", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MarkupValidationResult.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("uri", new MarkupValidationResult { Uri = "uri" }.ToString());
    }
  }
}