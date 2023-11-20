namespace DotNet8.KeyedServices.BookBasedSolution;

internal interface IBookBasedStrategy
{
  public string Print();
}

internal sealed class BookBasedStrategyAStrategy : IBookBasedStrategy
{
  public string Print() => "BookBasedStrategyAStrategy";
}

internal sealed class BookBasedStrategyBStrategy : IBookBasedStrategy
{
  public string Print() => "BookBasedStrategyBStrategy";
}