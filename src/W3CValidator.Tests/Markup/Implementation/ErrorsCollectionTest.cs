using Catharsis.Extensions;
using Catharsis.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using W3CValidator.Markup;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="ErrorsCollection"/>.</para>
/// </summary>
/// <seealso cref="ErrorsCollection"/>
public sealed class ErrorsCollectionTest : Test
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

    using (new AssertionScope())
    {
      var collection = new ErrorsCollection();
      collection.Should().BeEmpty();
    }

    using (new AssertionScope())
    {
      var collection = new ErrorsCollection([]);
      collection.Should().BeEmpty();

      var error = new Issue();
      collection = new ErrorsCollection([error]);
      collection.Should().Equal(error);
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
      Test(new ErrorsCollection());
      Test(Fixture<ErrorsCollection>.Create());
    }

    return;

    static void Test(IList<IIssue> issues) => issues.To<object>().Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}