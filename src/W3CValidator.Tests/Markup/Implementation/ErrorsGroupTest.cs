using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="ErrorsGroup"/>.</para>
/// </summary>
public sealed class ErrorsGroupTest : EntityTest<ErrorsGroup>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.Count"/> property.</para>
  /// </summary>
  [Fact]
  public void Count_Property()
  {
    new ErrorsGroup(new { Count = int.MaxValue}).Count.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.Errors"/> property.</para>
  /// </summary>
  [Fact]
  public void Errors_Property()
  {
    var group = new ErrorsGroup();
    var error = new Issue(new {});

    var errors = group.Errors.To<List<IIssue>>();
    errors.Add(error);
    group.Errors.Should().ContainSingle().Which.Should().BeSameAs(error);

    errors.Remove(error); 
    group.Errors.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ErrorsGroup(int?, IEnumerable{IIssue}?)"/>
  /// <seealso cref="ErrorsGroup(ErrorsGroup.Info)"/>
  /// <seealso cref="ErrorsGroup(object)"/>
  [Fact]
  public void Constructors()
  {
    var group = new ErrorsGroup();
    group.Count.Should().BeNull();
    group.Errors.Should().BeEmpty();

    group = new ErrorsGroup(new ErrorsGroup.Info());
    group.Count.Should().BeNull();
    group.Errors.Should().BeEmpty();

    group = new ErrorsGroup(new object());
    group.Count.Should().BeNull();
    group.Errors.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Tests set for class <see cref="ErrorsGroup.Info"/>.</para>
  /// </summary>
  public sealed class ErrorsGroupInfoTests : EntityTest<ErrorsGroup.Info>
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ErrorsGroup.Info.Count"/> property.</para>
    /// </summary>
    [Fact]
    public void Count_Property()
    {
      new ErrorsGroup.Info { Count = int.MaxValue }.Count.Should().Be(int.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ErrorsGroup.Info.Errors"/> property.</para>
    /// </summary>
    [Fact]
    public void Errors_Property()
    {
      var errors = new ErrorsCollection();
      new ErrorsGroup.Info { Errors = errors }.Errors.Should().BeSameAs(errors);
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="ErrorsGroup.Info()"/>
    [Fact]
    public void Constructors()
    {
      var info = new ErrorsGroup.Info();
      info.Count.Should().BeNull();
      info.Errors.Should().BeNull();
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ErrorsGroup.Info.ToResult()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToResult_Method()
    {
      var result = new ErrorsGroup.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<ErrorsGroup>();
      result.Count.Should().BeNull();
      result.Errors.Should().BeEmpty();
    }

    /// <summary>
    ///   <para>Performs testing of serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Serialization()
    {
      var info = new ErrorsGroup.Info();
      info.Should().BeDataContractSerializable().And.BeXmlSerializable();
    }
  }
}