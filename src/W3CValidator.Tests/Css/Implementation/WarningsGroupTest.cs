using Catharsis.Extensions;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using FluentAssertions.Execution;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="WarningsGroup"/>.</para>
/// </summary>
public sealed class WarningsGroupTest : ClassTest<WarningsGroup>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WarningsGroup()"/>
  /// <seealso cref="WarningsGroup(string, IEnumerable{IWarning})"/>
  /// <seealso cref="WarningsGroup(string, IWarning[])"/>
  [Fact]
  public void Constructors()
  {
    typeof(WarningsGroup).Should().BeDerivedFrom<object>().And.Implement<IWarningsGroup>();

    var group = new WarningsGroup();
    group.Uri.Should().BeNull();
    group.Warnings.Should().BeEmpty();

    var warning = new Warning();

    group = new WarningsGroup("uri", new List<IWarning> { warning });
    group.Uri.Should().Be("uri");
    group.Warnings.Should().Equal(warning);

    group = new WarningsGroup("uri", [warning]);
    group.Uri.Should().Be("uri");
    group.Warnings.Should().Equal(warning);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    new WarningsGroup { Uri = "uri" }.Uri.Should().Be("uri");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.WarningsList"/> property.</para>
  /// </summary>
  [Fact]
  public void WarningsList_Property()
  {
    var warnings = new List<IWarning>();
    new WarningsGroup { WarningsList = warnings }.Warnings.Should().BeSameAs(warnings);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WarningsGroup.Warnings"/> property.</para>
  /// </summary>
  [Fact]
  public void Warnings_Property()
  {
    new WarningsGroup().With(group => group.Warnings.Should().BeSameAs(group.WarningsList));
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
      Validate(string.Empty, new WarningsGroup());
      Validate(string.Empty, new WarningsGroup { Uri = string.Empty });
      Validate("uri", new WarningsGroup { Uri = "uri" });
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
      Validate(new WarningsGroup());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}