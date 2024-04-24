using Catharsis.Extensions;
using W3CValidator.Css;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using FluentAssertions.Execution;

namespace W3CValidator.Tests.Css;

/// <summary>
///   <para>Tests set for class <see cref="ErrorsGroup"/>.</para>
/// </summary>
public sealed class ErrorsListTests : ClassTest<ErrorsGroup>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ErrorsGroup()"/>
  /// <seealso cref="ErrorsGroup(string, IEnumerable{IError})"/>
  /// <seealso cref="ErrorsGroup(string, IError[])"/>
  [Fact]
  public void Constructors()
  {
    typeof(ErrorsGroup).Should().BeDerivedFrom<object>().And.Implement<IErrorsGroup>();

    var group = new ErrorsGroup();
    group.Uri.Should().BeNull();
    group.Errors.Should().BeEmpty();

    var error = new Error();

    group = new ErrorsGroup("uri", new List<IError> { error });
    group.Uri.Should().Be("uri");
    group.Errors.Should().Equal(error);

    group = new ErrorsGroup("uri", [error]);
    group.Uri.Should().Be("uri");
    group.Errors.Should().Equal(error);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    new ErrorsGroup { Uri = "uri" }.Uri.Should().Be("uri");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.ErrorsList"/> property.</para>
  /// </summary>
  [Fact]
  public void ErrorsList_Property()
  {
    var errors = new List<IError>();
    new ErrorsGroup { ErrorsList = errors }.Errors.Should().BeSameAs(errors);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.Errors"/> property.</para>
  /// </summary>
  [Fact]
  public void Errors_Property()
  {
    new ErrorsGroup().With(group => group.Errors.Should().BeSameAs(group.ErrorsList));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ErrorsGroup.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    using (new AssertionScope())
    {
      Validate(string.Empty, new ErrorsGroup());
      Validate(string.Empty, new ErrorsGroup { Uri = string.Empty });
      Validate("uri", new ErrorsGroup { Uri = "uri" });
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
      Validate(new ErrorsGroup());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}