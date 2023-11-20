namespace DotNet8.KeyedServices.BookBasedSolution;

internal interface IBookBasedSolutionFactory
{
  public IBookBasedStrategy Create(StrategyType type);
}

internal sealed class BookBasedSolutionFactory : IBookBasedSolutionFactory
{

  public IBookBasedStrategy Create(StrategyType type)
  {
    switch (type)
    {
      case StrategyType.StrategyA:
        return new BookBasedStrategyAStrategy();
      case StrategyType.StrategyB:
        return new BookBasedStrategyBStrategy();
    }
    throw new NotImplementedException();
  }
}
