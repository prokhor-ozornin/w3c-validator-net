using Catharsis.Extensions;
using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using FluentAssertions.Execution;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="WarningsGroup"/>.</para>
/// </summary>
public sealed class WarningsGroupTest : ClassTest<WarningsGroup>
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
  public sealed class WarningsGroupInfoTests : ClassTest<WarningsGroup.Info>
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
    ///   <para>Performs testing of <see cref="WarningsGroup.Info.ToResult()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToResult_Method()
    {
      using (new AssertionScope())
      {
        var result = new WarningsGroup.Info().ToResult();
        result.Should().NotBeNull().And.BeOfType<WarningsGroup>();
        result.Count.Should().BeNull();
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
}