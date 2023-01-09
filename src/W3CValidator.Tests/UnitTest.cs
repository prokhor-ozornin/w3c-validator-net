using Catharsis.Extensions;

namespace W3CValidator.Tests;

public abstract class UnitTest : IDisposable
{
  protected CancellationToken Cancellation { get; } = new(true);

  protected Random Randomizer { get; } = new();

  protected Uri LocalHost { get; } = "https://localhost".ToUri();

  public virtual void Dispose()
  {
  }
}