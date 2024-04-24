using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using FluentAssertions.Execution;
using System.Runtime.Serialization;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="MarkupValidationResult"/>.</para>
/// </summary>
public sealed class MarkupValidationResultTest : ClassTest<MarkupValidationResult>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="MarkupValidationResult()"/>
  [Fact]
  public void Constructors()
  {
    typeof(MarkupValidationResult).Should().BeDerivedFrom<object>().And.Implement<IComparable<IMarkupValidationResult>>().And.Implement<IEquatable<IMarkupValidationResult>>().And.Implement<IMarkupValidationResult>().And.BeDecoratedWith<DataContractAttribute>();

    var result = new MarkupValidationResult();
    result.Uri.Should().BeNull();
    result.Valid.Should().BeNull();
    result.Date.Should().BeNull();
    result.CheckedBy.Should().BeNull();
    result.Doctype.Should().BeNull();
    result.Encoding.Should().BeNull();
    result.ErrorsGroup.Should().BeNull();
    result.WarningsGroup.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    new MarkupValidationResult { Uri = "uri" }.Uri.Should().Be("uri");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Valid"/> property.</para>
  /// </summary>
  [Fact]
  public void Valid_Property()
  {
    new MarkupValidationResult { Valid = true }.Valid.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new MarkupValidationResult { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.CheckedBy"/> property.</para>
  /// </summary>
  [Fact]
  public void CheckedBy_Property()
  {
    new MarkupValidationResult { CheckedBy = "checkedBy" }.CheckedBy.Should().Be("checkedBy");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Doctype"/> property.</para>
  /// </summary>
  [Fact]
  public void Doctype_Property()
  {
    new MarkupValidationResult { Doctype = "doctype" }.Doctype.Should().Be("doctype");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Encoding"/> property.</para>
  /// </summary>
  [Fact]
  public void Encoding_Property()
  {
    new MarkupValidationResult { Encoding = "encoding" }.Encoding.Should().Be("encoding");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.ErrorsGroup"/> property.</para>
  /// </summary>
  [Fact]
  public void ErrorsGroup_Property()
  {
    var group = new ErrorsGroup();
    new MarkupValidationResult { ErrorsGroup = group }.ErrorsGroup.Should().BeSameAs(group);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.WarningsGroup"/> property.</para>
  /// </summary>
  [Fact]
  public void WarningsGroup_Property()
  {
    var group = new WarningsGroup();
    new MarkupValidationResult { WarningsGroup = group }.WarningsGroup.Should().BeSameAs(group);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.CompareTo(IMarkupValidationResult)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(MarkupValidationResult.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="MarkupValidationResult.Equals(IMarkupValidationResult)"/></description></item>
  ///     <item><description><see cref="MarkupValidationResult.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(MarkupValidationResult.Uri), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(MarkupValidationResult.Uri), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    using (new AssertionScope())
    {
      Validate(string.Empty, new MarkupValidationResult());
      Validate(string.Empty, new MarkupValidationResult { Uri = string.Empty });
      Validate("uri", new MarkupValidationResult { Uri = "uri" });
    }

    return;

    static void Validate(string value, object instance) => instance.ToString().Should().Be(value);
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new MarkupValidationResult());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}