using Catharsis.Commons;
using W3CValidator.Markup;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="WarningsGroup"/>.</para>
/// </summary>
public sealed class WarningsGroupTest : UnitTest<WarningsGroup>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property()
  {
    new WarningsGroup(new {Count = int.MaxValue}).Count.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Warnings"/> property.</para>
  /// </summary>
  [Fact]
  public void Warnings_Property()
  {
    var group = new WarningsGroup();
    var warning = new Issue(new {});

    var errors = group.Warnings.To<List<IIssue>>();
    errors.Add(warning);
    group.Warnings.Should().ContainSingle().Which.Should().BeSameAs(warning);

    errors.Remove(warning);
    group.Warnings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WarningsGroup(int?, IEnumerable{IIssue}?)"/>
  /// <seealso cref="WarningsGroup(WarningsGroup.Info)"/>
  /// <seealso cref="WarningsGroup(object)"/>
  [Fact]
  public void Constructors()
  {
    var group = new WarningsGroup();
    group.Count.Should().BeNull();
    group.Warnings.Should().BeEmpty();

    group = new WarningsGroup(new WarningsGroup.Info());
    group.Count.Should().BeNull();
    group.Warnings.Should().BeEmpty();

    group = new WarningsGroup(new object());
    group.Count.Should().BeNull();
    group.Warnings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Tests set for class <see cref="WarningsGroup.Info"/>.</para>
  /// </summary>
  public sealed class WarningsGroupInfoTests : UnitTest<WarningsGroup.Info>
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="WarningsGroup.Info.Count"/> property.</para>
    /// </summary>
    [Fact]
    public void Count_Property()
    {
      new WarningsGroup.Info { Count = int.MaxValue }.Count.Should().Be(int.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WarningsGroup.Info.Warnings"/> property.</para>
    /// </summary>
    [Fact]
    public void Warnings_Property()
    {
      var warnings = new WarningsCollection();
      new WarningsGroup.Info { Warnings = warnings }.Warnings.Should().BeSameAs(warnings);
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="WarningsGroup.Info()"/>
    [Fact]
    public void Constructors()
    {
      var info = new WarningsGroup.Info();
      info.Count.Should().BeNull();
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
      result.Count.Should().BeNull();
      result.Warnings.Should().BeEmpty();
    }

    /// <summary>
    ///   <para>Performs testing of serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Serialization()
    {
      var info = new WarningsGroup.Info();
      info.Should().BeDataContractSerializable().And.BeXmlSerializable();
    }
  }
}