using W3CValidator.Markup;
using FluentAssertions;
using Xunit;

namespace W3CValidator.Tests.Markup;

/// <summary>
///   <para>Tests set for class <see cref="ErrorsCollection"/>.</para>
/// </summary>
public sealed class ErrorsCollectionTest
{
  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    var collection = new ErrorsCollection() as object;
    collection.Should().BeDataContractSerializable().And.BeXmlSerializable();
  }
}