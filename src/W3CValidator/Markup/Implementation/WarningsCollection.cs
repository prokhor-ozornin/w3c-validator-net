using System.Runtime.Serialization;

namespace W3CValidator.Markup;

/// <summary>
///   <para></para>
/// </summary>
[CollectionDataContract(Name = "warninglist", ItemName = "warning")]
public sealed class WarningsCollection : List<Issue.Info>
{
}