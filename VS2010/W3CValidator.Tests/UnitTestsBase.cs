using System;
using Catharsis.Commons;
using Xunit;

namespace W3CValidator
{
  public abstract class UnitTestsBase<T>
  {
    protected void TestCompareTo<PROPERTY>(string property, PROPERTY lower, PROPERTY greater, Func<T> constructor = null)
    {
      Assertion.NotEmpty(property);

      constructor = constructor ?? (() => typeof(T).NewInstance().To<T>());

      var first = constructor().To<IComparable<T>>();
      var second = constructor().To<T>();

      first.Property(property, lower);
      second.Property(property, lower);

      Assert.Equal(0, first.CompareTo(second));
      second.Property(property, greater);
      Assert.True(first.CompareTo(second) < 0);
    }

    protected void TestEquality<PROPERTY>(string property, PROPERTY oldValue, PROPERTY newValue, Func<T> constructor = null)
    {
      Assertion.NotEmpty(property);

      constructor = constructor ?? (() => typeof(T).NewInstance().To<T>());
      var entity = constructor();

      Assert.False(entity.Equals(null));
      Assert.True(entity.Equals(entity));
      Assert.True(entity.Equals(constructor()));

      Assert.True(constructor().Property(property, oldValue).Equals(constructor().Property(property, oldValue)));
      Assert.False(constructor().Property(property, oldValue).Equals(constructor().Property(property, newValue)));
    }

    protected void TestHashCode<PROPERTY>(string property, PROPERTY oldValue, PROPERTY newValue, Func<T> constructor = null)
    {
      Assertion.NotEmpty(property);

      constructor = constructor ?? (() => typeof(T).NewInstance().To<T>());
      var entity = constructor();

      Assert.True(entity.GetHashCode() == entity.GetHashCode());
      Assert.True(entity.GetHashCode() == constructor().GetHashCode());

      Assert.True(constructor().Property(property, oldValue).GetHashCode() == constructor().Property(property, oldValue).GetHashCode());
      Assert.True(constructor().Property(property, oldValue).GetHashCode() != constructor().Property(property, newValue).GetHashCode());
    }
  }
}