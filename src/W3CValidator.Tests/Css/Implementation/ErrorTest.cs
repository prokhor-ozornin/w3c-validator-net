using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using FluentAssertions.Execution;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="Error"/>.</para>
/// </summary>
public sealed class ErrorTest : ClassTest<Error>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Message"/> property.</para>
  /// </summary>
  [Fact]
  public void Message_Property() { new Error(new {Message = Guid.Empty.ToString()}).Message.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property() { new Error(new {Type = Guid.Empty.ToString()}).Type.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Subtype"/> property.</para>
  /// </summary>
  [Fact]
  public void Subtype_Property() { new Error(new {Subtype = Guid.Empty.ToString()}).Subtype.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Property"/> property.</para>
  /// </summary>
  [Fact]
  public void Property_Property() { new Error(new {Property = Guid.Empty.ToString()}).Property.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property() { new Error(new {Line = int.MaxValue}).Line.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Context"/> property.</para>
  /// </summary>
  [Fact]
  public void Context_Property() { new Error(new {Context = Guid.Empty.ToString()}).Context.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.SkippedString"/> property.</para>
  /// </summary>
  [Fact]
  public void SkippedString_Property() { new Error(new {SkippedString = Guid.Empty.ToString()}).SkippedString.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Error(string?, string?, string?, string?, int?, string?, string?)"/>
  /// <seealso cref="Error(Error.Info)"/>
  /// <seealso cref="Error(object)"/>
  [Fact]
  public void Constructors()
  {
    var error = new Error();
    error.Message.Should().BeNull();
    error.Type.Should().BeNull();
    error.Subtype.Should().BeNull();
    error.Property.Should().BeNull();
    error.Line.Should().BeNull();
    error.Context.Should().BeNull();
    error.SkippedString.Should().BeNull();

    error = new Error(new Error.Info());
    error.Message.Should().BeNull();
    error.Type.Should().BeNull();
    error.Subtype.Should().BeNull();
    error.Property.Should().BeNull();
    error.Line.Should().BeNull();
    error.Context.Should().BeNull();
    error.SkippedString.Should().BeNull();

    error = new Error(new {});
    error.Message.Should().BeNull();
    error.Type.Should().BeNull();
    error.Subtype.Should().BeNull();
    error.Property.Should().BeNull();
    error.Line.Should().BeNull();
    error.Context.Should().BeNull();
    error.SkippedString.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    using (new AssertionScope())
    {
      Validate(string.Empty, new ErrorsGroup(new { }));
      Validate(string.Empty, new ErrorsGroup(new { Uri = string.Empty }));
      Validate("uri", new ErrorsGroup(new { Uri = "uri" }));
    }

    return;

    static void Validate(string value, object instance) => instance.ToString().Should().Be(value);

    new Error(new {Line = 1, Message = "message"}).ToString().Should().Be("1:message");
  }
}

/// <summary>
///   <para>Tests set for class <see cref="Error.Info"/>.</para>
/// </summary>
public sealed class ErrorInfoTests : ClassTest<Error.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Info.Message"/> property.</para>
  /// </summary>
  [Fact]
  public void Message_Property() { new Error.Info {Message = Guid.Empty.ToString()}.Message.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Info.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property() { new Error.Info {Type = Guid.Empty.ToString()}.Type.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Info.Subtype"/> property.</para>
  /// </summary>
  [Fact]
  public void Subtype_Property() { new Error.Info {Subtype = Guid.Empty.ToString()}.Subtype.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Info.Property"/> property.</para>
  /// </summary>
  [Fact]
  public void Property_Property() { new Error.Info {Property = Guid.Empty.ToString()}.Property.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Info.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property() { new Error.Info {Line = int.MaxValue}.Line.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Info.Context"/> property.</para>
  /// </summary>
  [Fact]
  public void Context_Property() { new Error.Info {Context = Guid.Empty.ToString()}.Context.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Info.SkippedString"/> property.</para>
  /// </summary>
  [Fact]
  public void SkippedString_Property() { new Error.Info {SkippedString = Guid.Empty.ToString()}.SkippedString.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Error.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new Error.Info();
    info.Message.Should().BeNull();
    info.Type.Should().BeNull();
    info.Subtype.Should().BeNull();
    info.Property.Should().BeNull();
    info.Line.Should().BeNull();
    info.Context.Should().BeNull();
    info.SkippedString.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Error.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new Error.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<Error>();
      result.Message.Should().BeNull();
      result.Type.Should().BeNull();
      result.Subtype.Should().BeNull();
      result.Property.Should().BeNull();
      result.Line.Should().BeNull();
      result.Context.Should().BeNull();
      result.SkippedString.Should().BeNull();
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
      Validate(new Error.Info());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}