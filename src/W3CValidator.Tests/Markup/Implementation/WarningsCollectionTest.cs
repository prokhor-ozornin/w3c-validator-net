using Catharsis.Extensions;
using Catharsis.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using W3CValidator.Markup;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="WarningsCollection"/>.</para>
/// </summary>
/// <seealso cref="WarningsCollection"/>
public sealed class WarningsCollectionTest : Test
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

    using (new AssertionScope())
    {
      var collection = new WarningsCollection();
      collection.Should().BeEmpty();
    }

    using (new AssertionScope())
    {
      var collection = new WarningsCollection([]);
      collection.Should().BeEmpty();

      var warning = new Issue();
      collection = new WarningsCollection([warning]);
      collection.Should().Equal(warning);
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
      Test(new WarningsCollection());
      Test(Fixture<WarningsCollection>.Create());
    }

    return;

    static void Test(IList<IIssue> issues) => issues.To<object>().Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}