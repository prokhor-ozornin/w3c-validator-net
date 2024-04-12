﻿using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using FluentAssertions.Execution;
using System.Runtime.Serialization;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="Warning"/>.</para>
/// </summary>
public sealed class WarningTest : ClassTest<Warning>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Warning(string?, int?, int?, string?)"/>
  /// <seealso cref="Warning(Warning.Info)"/>
  /// <seealso cref="Warning(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(Warning).Should().BeDerivedFrom<object>().And.Implement<IWarning>();

    var warning = new Warning();
    warning.Message.Should().BeNull();
    warning.Level.Should().BeNull();
    warning.Line.Should().BeNull();
    warning.Context.Should().BeNull();

    warning = new Warning(new Warning.Info());
    warning.Message.Should().BeNull();
    warning.Level.Should().BeNull();
    warning.Line.Should().BeNull();
    warning.Context.Should().BeNull();

    warning = new Warning(new object());
    warning.Message.Should().BeNull();
    warning.Level.Should().BeNull();
    warning.Line.Should().BeNull();
    warning.Context.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.Message"/> property.</para>
  /// </summary>
  [Fact]
  public void Message_Property()
  {
    new Warning(new
    {
      Message = Guid.Empty.ToString()
    }).Message.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.Level"/> property.</para>
  /// </summary>
  [Fact]
  public void Level_Property()
  {
    new Warning(new
    {
      Level = int.MaxValue
    }).Level.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property()
  {
    new Warning(new
    {
      Line = int.MaxValue
    }).Line.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.Context"/> property.</para>
  /// </summary>
  [Fact]
  public void Context_Property()
  {
    new Warning(new
    {
      ContextOriginal = Guid.Empty.ToString()
    }).Context.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    using (new AssertionScope())
    {
      Validate("1:2 message", new Warning(new
      {
        Level = 2,
        Line = 1,
        Message = "message"
      }));
    }

    return;

    static void Validate(string value, object instance) => instance.ToString().Should().Be(value);
  }
}

/// <summary>
///   <para>Tests set for class <see cref="Warning.Info"/>.</para>
/// </summary>
public sealed class WarningInfoTests : ClassTest<Warning.Info>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Warning.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Warning.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IWarning>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new Warning.Info();
    info.Message.Should().BeNull();
    info.Level.Should().BeNull();
    info.Line.Should().BeNull();
    info.Context.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.Info.Message"/> property.</para>
  /// </summary>
  [Fact]
  public void Message_Property()
  {
    new Warning.Info { Message = Guid.Empty.ToString() }.Message.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.Info.Level"/> property.</para>
  /// </summary>
  [Fact]
  public void Level_Property()
  {
    new Warning.Info { Level = int.MaxValue }.Level.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.Info.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property()
  {
    new Warning.Info { Line = int.MaxValue }.Line.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.Info.Context"/> property.</para>
  /// </summary>
  [Fact]
  public void Context_Property()
  {
    new Warning.Info { Context = Guid.Empty.ToString() }.Context.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Warning.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new Warning.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<Warning>();
      result.Message.Should().BeNull();
      result.Level.Should().BeNull();
      result.Line.Should().BeNull();
      result.Context.Should().BeNull();
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of XML serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Warning.Info());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}