using System.Runtime.Serialization;

namespace W3CValidator.Markup;

/// <summary>
///   <para></para>
/// </summary>
[CollectionDataContract(Name = "errorlist", ItemName = "error")]
public sealed class ErrorsCollection : List<Issue.Info>
{
}