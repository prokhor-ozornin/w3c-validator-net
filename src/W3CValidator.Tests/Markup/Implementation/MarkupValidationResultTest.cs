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
  /// <seealso cref="MarkupValidationResult(string?, bool?, DateTimeOffset?, string?, string?, string?, IErrorsGroup?, IWarningsGroup?)"/>
  /// <seealso cref="MarkupValidationResult(MarkupValidationResult.Info)"/>
  /// <seealso cref="MarkupValidationResult(object)"/>
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

    result = new MarkupValidationResult(new WarningsGroup.Info());
    result.Uri.Should().BeNull();
    result.Valid.Should().BeNull();
    result.Date.Should().BeNull();
    result.CheckedBy.Should().BeNull();
    result.Doctype.Should().BeNull();
    result.Encoding.Should().BeNull();
    result.ErrorsGroup.Should().BeNull();
    result.WarningsGroup.Should().BeNull();

    result = new MarkupValidationResult(new {});
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
    new MarkupValidationResult(new
    {
      Uri = Guid.Empty.ToString()
    }).Uri.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Valid"/> property.</para>
  /// </summary>
  [Fact]
  public void Valid_Property()
  {
    new MarkupValidationResult(new
    {
      Valid = true
    }).Valid.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new MarkupValidationResult(new
    {
      Date = DateTimeOffset.MaxValue
    }).Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.CheckedBy"/> property.</para>
  /// </summary>
  [Fact]
  public void CheckedBy_Property()
  {
    new MarkupValidationResult(new
    {
      CheckedBy = Guid.Empty.ToString()
    }).CheckedBy.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Doctype"/> property.</para>
  /// </summary>
  [Fact]
  public void Doctype_Property()
  {
    new MarkupValidationResult(new
    {
      Doctype = Guid.Empty.ToString()
    }).Doctype.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Encoding"/> property.</para>
  /// </summary>
  [Fact]
  public void Encoding_Property()
  {
    new MarkupValidationResult(new
    {
      Encoding = Guid.Empty.ToString()
    }).Encoding.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.ErrorsGroup"/> property.</para>
  /// </summary>
  [Fact]
  public void ErrorsGroup_Property()
  {
    var group = new ErrorsGroup();
    new MarkupValidationResult(new
    {
      ErrorsGroup = group
    }).ErrorsGroup.Should().BeSameAs(group);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.WarningsGroup"/> property.</para>
  /// </summary>
  [Fact]
  public void WarningsGroup_Property()
  {
    var group = new WarningsGroup();
    new MarkupValidationResult(new
    {
      WarningsGroup = group
    }).WarningsGroup.Should().BeSameAs(group);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.CompareTo(IMarkupValidationResult?)"/> method.</para>
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
      Validate(string.Empty, new MarkupValidationResult(new { }));
      Validate(string.Empty, new MarkupValidationResult(new { Uri = string.Empty }));
      Validate("uri", new MarkupValidationResult(new { Uri = "uri" }));
    }

    return;

    static void Validate(string value, object instance) => instance.ToString().Should().Be(value);
  }
}

/// <summary>
///   <para>Tests set for class <see cref="MarkupValidationResult.Info"/>.</para>
/// </summary>
public sealed class MarkupValidationResultInfoTests : ClassTest<MarkupValidationResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="MarkupValidationResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(MarkupValidationResult.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IMarkupValidationResult>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new MarkupValidationResult.Info();
    info.Uri.Should().BeNull();
    info.Valid.Should().BeNull();
    info.Date.Should().BeNull();
    info.CheckedBy.Should().BeNull();
    info.Doctype.Should().BeNull();
    info.Encoding.Should().BeNull();
    info.ErrorsGroup.Should().BeNull();
    info.WarningsGroup.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Info.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    new MarkupValidationResult.Info { Uri = Guid.Empty.ToString() }.Uri.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Info.Valid"/> property.</para>
  /// </summary>
  [Fact]
  public void Valid_Property()
  {
    new MarkupValidationResult.Info { Valid = true }.Valid.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Info.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new MarkupValidationResult.Info { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Info.CheckedBy"/> property.</para>
  /// </summary>
  [Fact]
  public void CheckedBy_Property()
  {
    new MarkupValidationResult.Info { CheckedBy = Guid.Empty.ToString() }.CheckedBy.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Info.Doctype"/> property.</para>
  /// </summary>
  [Fact]
  public void Doctype_Property()
  {
    new MarkupValidationResult.Info { Doctype = Guid.Empty.ToString() }.Doctype.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Info.Encoding"/> property.</para>
  /// </summary>
  [Fact]
  public void Encoding_Property()
  {
    new MarkupValidationResult.Info { Encoding = Guid.Empty.ToString() }.Encoding.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Info.ErrorsGroup"/> property.</para>
  /// </summary>
  [Fact]
  public void ErrorsGroup_Property()
  {
    var group = new ErrorsGroup();
    new MarkupValidationResult.Info { ErrorsGroup = group }.ErrorsGroup.Should().BeSameAs(group);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Info.WarningsGroup"/> property.</para>
  /// </summary>
  [Fact]
  public void WarningsGroup_Property()
  {
    var group = new WarningsGroup();
    new MarkupValidationResult.Info { WarningsGroup = group }.WarningsGroup.Should().BeSameAs(group);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MarkupValidationResult.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new MarkupValidationResult.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<MarkupValidationResult>();
      result.Uri.Should().BeNull();
      result.Valid.Should().BeNull();
      result.Date.Should().BeNull();
      result.CheckedBy.Should().BeNull();
      result.Doctype.Should().BeNull();
      result.Encoding.Should().BeNull();
      result.ErrorsGroup.Should().BeNull();
      result.WarningsGroup.Should().BeNull();
    }

    return;

    static void Validate()
    {

    }
  }

    /// <summary>
    ///   <para>Performs testing of serialization/deserialization process.</para>
    /// </summary>
    [Fact]
  public void SerializationXml()
  {
    using (new AssertionScope())
    {
      var info = new MarkupValidationResult.Info();
      info.Should().BeDataContractSerializable().And.BeXmlSerializable();
    }

    return;

    static void Validate()
    {

    }
  }
}