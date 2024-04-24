using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;
using FluentAssertions.Execution;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="WarningsCollection"/>.</para>
/// </summary>
public sealed class WarningsCollectionTest : ClassTest<WarningsCollection>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WarningsCollection()"/>
  /// <seealso cref="WarningsCollection(IEnumerable{IIssue})"/>
  [Fact]
  public void Constructors()
  {
    typeof(WarningsCollection).Should().BeDerivedFrom<List<IIssue>>();

    var collection = new WarningsCollection();
    collection.Should().BeEmpty();

    collection = new WarningsCollection([]);
    collection.Should().BeEmpty();

    var warning = new Issue();
    collection = new WarningsCollection([warning]);
    collection.Should().Equal(warning);
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new WarningsCollection());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}