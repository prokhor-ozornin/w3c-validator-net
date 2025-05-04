using AutoFixture;
using Catharsis.Extensions;
using W3CValidator.Css;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="Issues"/>.</para>
/// </summary>
public sealed class IssuesTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Issues()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Issues).Should().BeDerivedFrom<object>().And.Implement<IIssues>();

    using (new AssertionScope())
    {
      var issues = new Issues();

      issues.ErrorsGroups.Should().BeEmpty();
      issues.WarningsGroups.Should().BeEmpty();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issues.ErrorsGroupsList"/> property.</para>
  /// </summary>
  [Fact]
  public void ErrorsGroupsList_Property()
  {
    var errors = new List<IErrorsGroup>();
    new Issues { ErrorsGroupsList = errors }.ErrorsGroupsList.Should().BeSameAs(errors);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issues.WarningsGroupsList"/> property.</para>
  /// </summary>
  [Fact]
  public void WarningsGroupsList_Property()
  {
    var warnings = new List<IWarningsGroup>();
    new Issues { WarningsGroupsList = warnings }.WarningsGroupsList.Should().BeSameAs(warnings);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issues.ErrorsGroups"/> property.</para>
  /// </summary>
  [Fact]
  public void ErrorsGroups_Property()
  {
    new Issues().With(issues => issues.ErrorsGroups.Should().BeSameAs(issues.ErrorsGroupsList));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Issues.WarningsGroups"/> property.</para>
  /// </summary>
  [Fact]
  public void WarningsGroups_Property()
  {
    new Issues().With(issues => issues.WarningsGroups.Should().BeSameAs(issues.WarningsGroupsList));
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Issues());
      Validate(Fixture.Create<IIssues>());
    }

    return;

    static void Validate(IIssues instance) => instance.To<object>().Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}