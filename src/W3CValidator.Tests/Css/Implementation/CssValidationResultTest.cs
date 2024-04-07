using W3CValidator.Css;
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
  ///   <para>Performs testing of <see cref="CssValidationResult.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property() { new CssValidationResult(new {Uri = Guid.Empty.ToString()}).Uri.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Valid"/> property.</para>
  /// </summary>
  [Fact]
  public void Valid_Property() { new CssValidationResult(new {Valid = true}).Valid.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new CssValidationResult(new {Date = DateTimeOffset.MaxValue}).Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.CheckedBy"/> property.</para>
  /// </summary>
  [Fact]
  public void CheckedBy_Property() { new CssValidationResult(new {CheckedBy = Guid.Empty.ToString()}).CheckedBy.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.CssLevel"/> property.</para>
  /// </summary>
  [Fact]
  public void CssLevel_Property() { new CssValidationResult(new {CssLevel = Guid.Empty.ToString()}).CssLevel.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Issues"/> property.</para>
  /// </summary>
  [Fact]
  public void Issues_Property()
  {
    var issues = new Issues(new {});
    new CssValidationResult(new {Issues = issues}).Issues.Should().Be(issues);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="CssValidationResult(CssValidationResult.Info)"/>
  /// <seealso cref="CssValidationResult(object)"/>
  [Fact]
  public void Constructors()
  {
    var result = new CssValidationResult();
    result.Uri.Should().BeNull();
    result.Valid.Should().BeNull();
    result.Date.Should().BeNull();
    result.CheckedBy.Should().BeNull();
    result.CssLevel.Should().BeNull();
    result.Issues.Should().BeNull();

    result = new CssValidationResult(new CssValidationResult.Info());
    result.Uri.Should().BeNull();
    result.Valid.Should().BeNull();
    result.Date.Should().BeNull();
    result.CheckedBy.Should().BeNull();
    result.CssLevel.Should().BeNull();
    result.Issues.Should().BeNull();

    result = new CssValidationResult(new object());
    result.Uri.Should().BeNull();
    result.Valid.Should().BeNull();
    result.Date.Should().BeNull();
    result.CheckedBy.Should().BeNull();
    result.CssLevel.Should().BeNull();
    result.Issues.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(CssValidationResult.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="CssValidationResult.Equals(ICssValidationResult)"/></description></item>
  ///     <item><description><see cref="CssValidationResult.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(CssValidationResult.Uri), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(CssValidationResult.Uri), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    using (new AssertionScope())
    {
      Validate(string.Empty, new CssValidationResult(new { }));
      Validate(string.Empty, new CssValidationResult(new { Uri = string.Empty }));
      Validate("uri", new CssValidationResult(new { Uri = "uri" }));
    }

    return;

    static void Validate(string value, object instance) => instance.ToString().Should().Be(value);
  }
}

/// <summary>
///   <para>Tests set for class <see cref="CssValidationResult.Info"/>.</para>
/// </summary>
public sealed class CssValidationResultInfoTests : ClassTest<CssValidationResult.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Info.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property() { new CssValidationResult.Info {Uri = Guid.Empty.ToString()}.Uri.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Info.Valid"/> property.</para>
  /// </summary>
  [Fact]
  public void Valid_Property() { new CssValidationResult.Info {Valid = true}.Valid.Should().BeTrue(); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Info.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new CssValidationResult.Info {Date = DateTimeOffset.MaxValue}.Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Info.CheckedBy"/> property.</para>
  /// </summary>
  [Fact]
  public void CheckedBy_Property() { new CssValidationResult.Info {CheckedBy = Guid.Empty.ToString()}.CheckedBy.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Info.CssLevel"/> property.</para>
  /// </summary>
  [Fact]
  public void CssLevel_Property() { new CssValidationResult.Info {CssLevel = Guid.Empty.ToString()}.CssLevel.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Info.Issues"/> property.</para>
  /// </summary>
  [Fact]
  public void Issues_Property()
  {
    var issues = new Issues(new {});
    new CssValidationResult.Info {Issues = issues}.Issues.Should().BeSameAs(issues);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="CssValidationResult.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new CssValidationResult.Info();
    info.Uri.Should().BeNull();
    info.Valid.Should().BeNull();
    info.Date.Should().BeNull();
    info.CheckedBy.Should().BeNull();
    info.CssLevel.Should().BeNull();
    info.Issues.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CssValidationResult.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new CssValidationResult.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<CssValidationResult>();
      result.Uri.Should().BeNull();
      result.Valid.Should().BeNull();
      result.Date.Should().BeNull();
      result.CheckedBy.Should().BeNull();
      result.CssLevel.Should().BeNull();
      result.Issues.Should().BeNull();
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of XML serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new CssValidationResult.Info());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}