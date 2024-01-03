using W3CValidator.Markup;
using FluentAssertions;
using Xunit;
using Catharsis.Commons;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="WarningsCollection"/>.</para>
/// </summary>
public sealed class WarningsCollectionTest : ClassTest<WarningsCollection>
{
  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var collection = new WarningsCollection() as object;
    collection.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}