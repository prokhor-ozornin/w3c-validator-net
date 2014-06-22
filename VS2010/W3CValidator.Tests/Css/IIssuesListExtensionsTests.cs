using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IIssuesListExtensions"/>.</para>
  /// </summary>
  public sealed class IIssuesListExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IIssuesListExtensions.Errors(IIssuesList)"/> method.</para>
    /// </summary>
    [Fact]
    public void Errors_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IIssuesListExtensions.Errors(null));
      
      var issues = new IssuesList();
      Assert.False(issues.Errors().Any());

      issues.ErrorsGroupsCollection.Add(new ErrorsList());
      Assert.False(issues.Errors().Any());

      var first = new Error();
      var second = new Error();
      issues.ErrorsGroupsCollection.Add(new ErrorsList { ErrorsCollection = new List<Error> { first } });
      issues.ErrorsGroupsCollection.Add(new ErrorsList { ErrorsCollection = new List<Error> { second } });
      Assert.True(issues.Errors().SequenceEqual(new[] { first, second }));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IIssuesListExtensions.Warnings(IIssuesList)"/> method.</para>
    /// </summary>
    [Fact]
    public void Warnings_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IIssuesListExtensions.Warnings(null));

      var issues = new IssuesList();
      Assert.False(issues.Warnings().Any());

      issues.WarningsGroupsCollection.Add(new WarningsList());
      Assert.False(issues.Warnings().Any());

      var first = new Warning();
      var second = new Warning();
      issues.WarningsGroupsCollection.Add(new WarningsList { WarningsCollection = new List<Warning> { first } });
      issues.WarningsGroupsCollection.Add(new WarningsList { WarningsCollection = new List<Warning> { second } });
      Assert.True(issues.Warnings().SequenceEqual(new[] { first, second }));
    }
  }
}