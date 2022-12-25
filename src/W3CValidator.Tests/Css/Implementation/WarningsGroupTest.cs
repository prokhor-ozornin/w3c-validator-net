﻿using Catharsis.Commons;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="WarningsGroup"/>.</para>
/// </summary>
public sealed class WarningsGroupTest : UnitTest<WarningsGroup>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property() { new WarningsGroup(new {Uri = Guid.Empty.ToString()}).Uri.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Warnings"/> property.</para>
  /// </summary>
  [Fact]
  public void Warnings_Property()
  {
    var list = new WarningsGroup(new {});
    
    var warning = new Warning(new {});

    var warnings = list.Warnings.To<List<Warning>>();

    warnings.Add(warning);
    list.Warnings.Should().ContainSingle().Which.Should().BeSameAs(warning);

    warnings.Remove(warning);
    list.Warnings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WarningsGroup(string?, IEnumerable{IWarning}?)"/>
  /// <seealso cref="WarningsGroup(WarningsGroup.Info)"/>
  /// <seealso cref="WarningsGroup(object)"/>
  [Fact]
  public void Constructors()
  {
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
  ///   <para>Performs testing of <see cref="WarningsGroup.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(WarningsGroup.Uri), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new WarningsGroup(new {Uri = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="WarningsGroup.Info"/>.</para>
/// </summary>
public sealed class WarningsGroupInfoTests : UnitTest<WarningsGroup.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Info.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property() { new WarningsGroup.Info {Uri = Guid.Empty.ToString()}.Uri.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Warnings"/> property.</para>
  /// </summary>
  [Fact]
  public void Warnings_Property()
  {
    var warnings = new List<Warning>();
    new WarningsGroup.Info {Warnings = warnings}.Warnings.Should().BeSameAs(warnings);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WarningsGroup.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new WarningsGroup.Info();
    info.Uri.Should().BeNull();
    info.Warnings.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Info.Result()"/> method.</para>
  /// </summary>
  [Fact]
  public void Result_Method()
  {
    var result = new WarningsGroup.Info().Result();
    result.Should().NotBeNull().And.BeOfType<WarningsGroup>();
    result.Uri.Should().BeNull();
    result.Warnings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    new WarningsGroup.Info().Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}