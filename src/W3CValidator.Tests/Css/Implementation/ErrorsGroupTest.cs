﻿using Catharsis.Commons;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="ErrorsGroup"/>.</para>
/// </summary>
public sealed class ErrorsListTests : UnitTest<ErrorsGroup>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property() { new ErrorsGroup(new {Uri = Guid.Empty.ToString()}).Uri.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.Errors"/> property.</para>
  /// </summary>
  [Fact]
  public void Errors_Property()
  {
    var group = new ErrorsGroup(new {});
    
    var error = new Error(new {});

    var errors = group.Errors.To<List<Error>>();
    errors.Add(error);
    group.Errors.Should().ContainSingle().Which.Should().BeSameAs(error);

    errors.Remove(error);
    group.Errors.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ErrorsGroup(string?, IEnumerable{IError}?)"/>
  /// <seealso cref="ErrorsGroup(ErrorsGroup.Info)"/>
  /// <seealso cref="ErrorsGroup(object)"/>
  [Fact]
  public void Constructors()
  {
    var group = new ErrorsGroup();
    group.Uri.Should().BeNull();
    group.Errors.Should().BeEmpty();

    group = new ErrorsGroup(new ErrorsGroup.Info());
    group.Uri.Should().BeNull();
    group.Errors.Should().BeEmpty();

    group = new ErrorsGroup(new object());
    group.Uri.Should().BeNull();
    group.Errors.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method() { new ErrorsGroup(new {Uri = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString()); }
}

/// <summary>
///   <para>Tests set for class <see cref="ErrorsGroup.Info"/>.</para>
/// </summary>
public sealed class ErrorsGroupInfoTests : UnitTest<ErrorsGroup.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.Info.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property() { new ErrorsGroup.Info {Uri = Guid.Empty.ToString()}.Uri.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.Info.Errors"/> property.</para>
  /// </summary>
  [Fact]
  public void Errors_Property()
  {
    var errors = new List<Error>();
    new ErrorsGroup.Info {Errors = errors}.Errors.Should().BeSameAs(errors);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ErrorsGroup.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new ErrorsGroup.Info();
    info.Uri.Should().BeNull();
    info.Errors.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.Info.Result()"/> method.</para>
  /// </summary>
  [Fact]
  public void Result_Method()
  {
    var result = new ErrorsGroup.Info().Result();
    result.Should().NotBeNull().And.BeOfType<ErrorsGroup>();
    result.Uri.Should().BeNull();
    result.Errors.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    new ErrorsGroup.Info().Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}