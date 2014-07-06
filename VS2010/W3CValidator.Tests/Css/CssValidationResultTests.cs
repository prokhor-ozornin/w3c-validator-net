using System;
using System.Linq;
using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="CssValidationResult"/>.</para>
  /// </summary>
  public sealed class CssValidationResultTests : UnitTestsBase<CssValidationResult>
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      XNamespace ns = "http://www.w3.org/2005/07/css-validator";

      var result = new CssValidationResult();
      var xml = XDocument.Parse(result.Xml());
      Assert.Equal(ns + "cssvalidationresponse", xml.Root.Name);
      Assert.Null(xml.Root.Element(ns + "checkedby"));
      Assert.Null(xml.Root.Element(ns + "csslevel"));
      Assert.Equal(result.Date, DateTime.Parse(xml.Root.Element(ns + "date").Value).ToUniversalTime());
      var issues = xml.Root.Element(ns + "result");
      Assert.False(issues.Element(ns + "errors").Elements(ns + "errorlist").Any());
      Assert.False(issues.Element(ns + "warnings").Elements(ns + "warninglist").Any());
      Assert.Null(xml.Root.Element(ns + "uri"));
      Assert.Equal("false", xml.Root.Element(ns + "validity").Value);
      Assert.True(result.Equals(result.Xml().Xml<CssValidationResult>()));

      result = new CssValidationResult
      {
        CheckedBy = "checkedBy",
        CssLevel = "cssLevel",
        Date = DateTime.MaxValue,
        Uri = "uri",
        Valid = true
      };
      xml = XDocument.Parse(result.Xml());
      Assert.Equal(ns + "cssvalidationresponse", xml.Root.Name);
      Assert.Equal("checkedBy", xml.Root.Element(ns + "checkedby").Value);
      Assert.Equal("cssLevel", xml.Root.Element(ns + "csslevel").Value);
      Assert.Equal(DateTime.MaxValue, DateTime.Parse(xml.Root.Element(ns + "date").Value));
      issues = xml.Root.Element(ns + "result");
      Assert.False(issues.Element(ns + "errors").Elements(ns + "errorlist").Any());
      Assert.False(issues.Element(ns + "warnings").Elements(ns + "warninglist").Any());
      Assert.Equal("uri", xml.Root.Element(ns + "uri").Value);
      Assert.Equal("true", xml.Root.Element(ns + "validity").Value);
      Assert.True(result.Equals(result.Xml().Xml<CssValidationResult>()));
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="CssValidationResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new CssValidationResult();
      Assert.Null(result.CheckedBy);
      Assert.Null(result.CssLevel);
      Assert.True(result.Date > DateTime.MinValue);
      Assert.True(result.Date <= DateTime.UtcNow);
      Assert.False(result.Issues.ErrorsGroups.Any());
      Assert.False(result.Issues.WarningsGroups.Any());
      Assert.Null(result.Uri);
      Assert.False(result.Valid);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationResult.CheckedBy"/> property.</para>
    /// </summary>
    [Fact]
    public void CheckedBy_Property()
    {
      Assert.Equal("checkedBy", new CssValidationResult { CheckedBy = "checkedBy" }.CheckedBy);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationResult.CssLevel"/> property.</para>
    /// </summary>
    [Fact]
    public void CssLevel_Property()
    {
      Assert.Equal("cssLevel", new CssValidationResult { CssLevel = "cssLevel" }.CssLevel);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationResult.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new CssValidationResult { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationResult.IssuesList"/> property.</para>
    /// </summary>
    [Fact]
    public void IssuesList_Property()
    {
      var issues = new IssuesList();
      Assert.True(ReferenceEquals(issues, new CssValidationResult { IssuesList = issues }.Issues));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationResult.Uri"/> property.</para>
    /// </summary>
    [Fact]
    public void Uri_Property()
    {
      Assert.Equal("uri", new CssValidationResult { Uri = "uri" }.Uri);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationResult.Valid"/> property.</para>
    /// </summary>
    [Fact]
    public void Valid_Property()
    {
      Assert.True(new CssValidationResult { Valid = true }.Valid);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="CssValidationResult.Equals(ICssValidationResult)"/></description></item>
    ///     <item><description><see cref="CssValidationResult.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Uri", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationResult.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Uri", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="CssValidationResult.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("uri", new CssValidationResult { Uri = "uri" }.ToString());
    }
  }
}