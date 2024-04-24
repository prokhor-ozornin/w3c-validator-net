using Catharsis.Commons;
using W3CValidator.Markup;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="ErrorsCollection"/>.</para>
/// </summary>
public sealed class ErrorsCollectionTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ErrorsCollection()"/>
  /// <seealso cref="ErrorsCollection(IEnumerable{IIssue})"/>
  [Fact]
  public void Constructors()
  {
    typeof(ErrorsCollection).Should().BeDerivedFrom<List<IIssue>>();

    var collection = new ErrorsCollection();
    collection.Should().BeEmpty();

    collection = new ErrorsCollection([]);
    collection.Should().BeEmpty();

    var error = new Issue();
    collection = new ErrorsCollection([error]);
    collection.Should().Equal(error);
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new ErrorsCollection());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}