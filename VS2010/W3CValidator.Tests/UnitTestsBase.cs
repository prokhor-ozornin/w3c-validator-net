using System;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator
{
  public abstract class UnitTestsBase<T>
  {
    protected void TestCompareTo<PROPERTY>(string property, PROPERTY lower, PROPERTY greater)
    {
      Assertion.NotEmpty(property);

      var first = typeof(T).NewInstance().To<IComparable<T>>();
      var second = typeof(T).NewInstance().To<T>();

      first.Property(property, lower);
      second.Property(property, lower);

      Assert.Equal(0, first.CompareTo(second));
      second.Property(property, greater);
      Assert.True(first.CompareTo(second) < 0);
    }

    protected void TestEquality<PROPERTY>(string property, PROPERTY oldValue, PROPERTY newValue)
    {
      Assertion.NotEmpty(property);

      var entity = typeof(T).NewInstance();

      Assert.False(entity.Equals(null));
      Assert.True(entity.Equals(entity));
      Assert.True(entity.Equals(typeof(T).NewInstance()));

      Assert.True(typeof(T).NewInstance().Property(property, oldValue).Equals(typeof(T).NewInstance().Property(property, oldValue)));
      Assert.False(typeof(T).NewInstance().Property(property, oldValue).Equals(typeof(T).NewInstance().Property(property, newValue)));
    }

    protected void TestHashCode<PROPERTY>(string property, PROPERTY oldValue, PROPERTY newValue)
    {
      Assertion.NotEmpty(property);

      var entity = typeof(T).NewInstance();

      Assert.True(entity.GetHashCode() == entity.GetHashCode());
      Assert.True(entity.GetHashCode() == typeof(T).NewInstance().GetHashCode());

      Assert.True(typeof(T).NewInstance().Property(property, oldValue).GetHashCode() == typeof(T).NewInstance().Property(property, oldValue).GetHashCode());
      Assert.True(typeof(T).NewInstance().Property(property, oldValue).GetHashCode() != typeof(T).NewInstance().Property(property, newValue).GetHashCode());
    }
  }
}