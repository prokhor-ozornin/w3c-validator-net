using System.Linq;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IssuesList"/>.</para>
  /// </summary>
  public sealed class IssuesListTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="IssuesList()"/>
    [Fact]
    public void Constructors()
    {
      var issues = new IssuesList();
      Assert.False(issues.ErrorsGroups.Any());
      Assert.False(issues.WarningsGroups.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IssuesList.ErrorsGroupsCollection"/> property.</para>
    /// </summary>
    [Fact]
    public void ErrorsGroupsCollection_Property()
    {
      var issues = new IssuesList();
      Assert.False(issues.ErrorsGroupsCollection.Any());
      var group = new ErrorsList();
      issues.ErrorsGroupsCollection.Add(group);
      Assert.True(ReferenceEquals(group, issues.ErrorsGroupsCollection.Single()));
      issues.ErrorsGroupsCollection.Remove(group);
      Assert.False(issues.ErrorsGroupsCollection.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IssuesList.WarningsGroupsCollection"/> property.</para>
    /// </summary>
    [Fact]
    public void WarningsGroupsCollection_Property()
    {
      var issues = new IssuesList();
      Assert.False(issues.WarningsGroupsCollection.Any());
      var group = new WarningsList();
      issues.WarningsGroupsCollection.Add(group);
      Assert.True(ReferenceEquals(group, issues.WarningsGroupsCollection.Single()));
      issues.WarningsGroupsCollection.Remove(group);
      Assert.False(issues.WarningsGroupsCollection.Any());
    }
  }
}