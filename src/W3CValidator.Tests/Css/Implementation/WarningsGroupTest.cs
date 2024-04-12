using Catharsis.Extensions;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using FluentAssertions.Execution;
using System.Runtime.Serialization;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="WarningsGroup"/>.</para>
/// </summary>
public sealed class WarningsGroupTest : ClassTest<WarningsGroup>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WarningsGroup(string?, IEnumerable{IWarning}?)"/>
  /// <seealso cref="WarningsGroup(WarningsGroup.Info)"/>
  /// <seealso cref="WarningsGroup(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(WarningsGroup).Should().BeDerivedFrom<object>().And.Implement<IWarningsGroup>();

    var group = new WarningsGroup();
    group.Uri.Should().BeNull();
    group.Warnings.Should().BeEmpty();

    group = new WarningsGroup(new WarningsGroup.Info());
    group.Uri.Should().BeNull();
    group.Warnings.Should().BeEmpty();

    group = new WarningsGroup(new {});
    group.Uri.Should().BeNull();
    group.Warnings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    new WarningsGroup(new
    {
      Uri = Guid.Empty.ToString()
    }).Uri.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Warnings"/> property.</para>
  /// </summary>
  [Fact]
  public void Warnings_Property()
  {
    var list = new WarningsGroup(new
    {
    });

    var warning = new Warning(new
    {
    });

    var warnings = list.Warnings.To<List<Warning>>();

    warnings.Add(warning);
    list.Warnings.Should().ContainSingle().Which.Should().BeSameAs(warning);

    warnings.Remove(warning);
    list.Warnings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(WarningsGroup.Uri), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    using (new AssertionScope())
    {
      Validate(string.Empty, new WarningsGroup(new { }));
      Validate(string.Empty, new WarningsGroup(new { Uri = string.Empty }));
      Validate("uri", new WarningsGroup(new { Uri = "uri" }));
    }

    return;

    static void Validate(string value, object instance) => instance.ToString().Should().Be(value);
  }
}

/// <summary>
///   <para>Tests set for class <see cref="WarningsGroup.Info"/>.</para>
/// </summary>
public sealed class WarningsGroupInfoTests : ClassTest<WarningsGroup.Info>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WarningsGroup.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(WarningsGroup.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IWarningsGroup>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new WarningsGroup.Info();
    info.Uri.Should().BeNull();
    info.Warnings.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Info.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    new WarningsGroup.Info { Uri = Guid.Empty.ToString() }.Uri.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Warnings"/> property.</para>
  /// </summary>
  [Fact]
  public void Warnings_Property()
  {
    var warnings = new List<Warning>();
    new WarningsGroup.Info { Warnings = warnings }.Warnings.Should().BeSameAs(warnings);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new WarningsGroup.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<WarningsGroup>();
      result.Uri.Should().BeNull();
      result.Warnings.Should().BeEmpty();
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
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new WarningsGroup.Info());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}