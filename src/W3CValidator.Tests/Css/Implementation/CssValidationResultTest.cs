﻿using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using FluentAssertions.Execution;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="CssValidationResult"/>.</para>
/// </summary>
public sealed class CssValidationResultTest : ClassTest<CssValidationResult>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="CssValidationResult()"/>
  [Fact]
  public void Constructors()
  {
    typeof(CssValidationResult).Should().BeDerivedFrom<object>().And.Implement<ICssValidationResult>();

    var result = new CssValidationResult();
    result.Uri.Should().BeNull();
    result.Valid.Should().BeNull();
    result.Date.Should().BeNull();
    result.CheckedBy.Should().BeNull();
    result.CssLevel.Should().BeNull();
    result.Issues.Errors.Should().BeEmpty();
    result.Issues.ErrorsGroups.Should().BeEmpty();
    result.Issues.Warnings.Should().BeEmpty();
    result.Issues.WarningsGroups.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    new CssValidationResult { Uri = "uri" }.Uri.Should().Be("uri");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Valid"/> property.</para>
  /// </summary>
  [Fact]
  public void Valid_Property()
  {
    new CssValidationResult { Valid = true }.Valid.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new CssValidationResult { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.CheckedBy"/> property.</para>
  /// </summary>
  [Fact]
  public void CheckedBy_Property()
  {
    new CssValidationResult { CheckedBy = "checkedBy" }.CheckedBy.Should().Be("checkedBy");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.CssLevel"/> property.</para>
  /// </summary>
  [Fact]
  public void CssLevel_Property()
  {
    new CssValidationResult { CssLevel = "cssLevel" }.CssLevel.Should().Be("cssLevel");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Issues"/> property.</para>
  /// </summary>
  [Fact]
  public void Issues_Property()
  {
    var issues = new Issues();
    new CssValidationResult { Issues = issues }.Issues.Should().BeSameAs(issues);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(CssValidationResult.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
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
    TestEquality(nameof(CssValidationResult.Uri), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(CssValidationResult.Uri), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    using (new AssertionScope())
    {
      Validate(string.Empty, new CssValidationResult());
      Validate(string.Empty, new CssValidationResult { Uri = string.Empty });
      Validate("uri", new CssValidationResult { Uri = "uri" });
    }

    return;

    static void Validate(string value, object instance) => instance.ToString().Should().Be(value);
  }

  /// <summary>
  ///   <para>Performs testing of XML serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new CssValidationResult());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}