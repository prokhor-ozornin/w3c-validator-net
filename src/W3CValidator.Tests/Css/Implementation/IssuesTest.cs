using Catharsis.Commons;
using Catharsis.Extensions;
using W3CValidator.Css;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using System.Runtime.Serialization;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="Issues"/>.</para>
/// </summary>
public sealed class IssuesTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Issues(IEnumerable{IErrorsGroup}?, IEnumerable{IWarningsGroup}?)"/>
  /// <seealso cref="Issues(Issues.Info)"/>
  /// <seealso cref="Issues(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(Issues).Should().BeDerivedFrom<object>().And.Implement<IIssues>();

    var issues = new Issues();
    issues.ErrorsGroups.Should().BeEmpty();
    issues.WarningsGroups.Should().BeEmpty();

    issues = new Issues(new Issues.Info());
    issues.ErrorsGroups.Should().BeEmpty();
    issues.WarningsGroups.Should().BeEmpty();

    issues = new Issues(new {});
    issues.ErrorsGroups.Should().BeEmpty();
    issues.WarningsGroups.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issues.ErrorsGroups"/> property.</para>
  /// </summary>
  [Fact]
  public void ErrorsGroups_Property()
  {
    var issues = new Issues(new
    {
    });
    issues.ErrorsGroups.Should().BeEmpty();

    var group = new ErrorsGroup(new
    {
    });

    var groups = issues.ErrorsGroups.To<List<ErrorsGroup>>();
    groups.Add(group);
    issues.ErrorsGroups.Should().ContainSingle().Which.Should().BeSameAs(group);
    groups.Remove(group);
    issues.ErrorsGroups.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issues.WarningsGroups"/> property.</para>
  /// </summary>
  [Fact]
  public void WarningsGroups_Property()
  {
    var issues = new Issues(new
    {
    });
    issues.WarningsGroups.Should().BeEmpty();

    var group = new WarningsGroup(new
    {
    });

    var groups = issues.WarningsGroups.To<List<WarningsGroup>>();

    groups.Add(group);
    issues.WarningsGroups.Should().ContainSingle().Which.Should().BeSameAs(group);
    groups.Remove(group);
    issues.WarningsGroups.Should().BeEmpty();
  }
}


/// <summary>
///   <para>Tests set for class <see cref="Issues.Info"/>.</para>
/// </summary>
public sealed class IssuesListInfoTests
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Issues.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Issues.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IIssues>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new Issues.Info();
    info.Errors.Should().BeNull();
    info.Warnings.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issues.Info.Errors"/> property.</para>
  /// </summary>
  [Fact]
  public void ErrorsGroups_Property()
  {
    var groups = new List<ErrorsGroup.Info>();
    new Issues.Info { Errors = groups }.Errors.Should().BeSameAs(groups);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issues.Info.Warnings"/> property.</para>
  /// </summary>
  [Fact]
  public void WarningsGroups_Property()
  {
    var groups = new List<WarningsGroup.Info>();
    new Issues.Info { Warnings = groups }.Warnings.Should().BeSameAs(groups);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issues.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new Issues.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<Issues>();
      result.Errors.Should().BeEmpty();
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
      Validate(new Issues.Info());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}