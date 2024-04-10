using Catharsis.Commons;
using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;
using System.Runtime.Serialization;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="ErrorsGroup"/>.</para>
/// </summary>
public sealed class ErrorsGroupTest : ClassTest<ErrorsGroup>
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
    typeof(ErrorsGroup).Should().BeDerivedFrom<object>().And.Implement<IErrorsGroup>();

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
  public sealed class ErrorsGroupInfoTests : ClassTest<ErrorsGroup.Info>
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
      typeof(ErrorsGroup.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IErrorsGroup>>().And.BeDecoratedWith<DataContractAttribute>();

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
      using (new AssertionScope())
      {
        var result = new ErrorsGroup.Info().ToResult();
        result.Should().NotBeNull().And.BeOfType<ErrorsGroup>();
        result.Count.Should().BeNull();
        result.Errors.Should().BeEmpty();
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
        Validate(new ErrorsGroup.Info());
      }

      return;

      static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
    }
  }
}