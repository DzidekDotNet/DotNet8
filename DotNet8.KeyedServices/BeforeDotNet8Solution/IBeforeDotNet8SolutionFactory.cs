namespace DotNet8.KeyedServices.BeforeDotNet8Solution;

internal interface IBeforeDotNet8SolutionFactory
{
  public IBeforeDotNet8Strategy Create(StrategyType type);
}
internal sealed class BeforeDotNet8SolutionFactory : IBeforeDotNet8SolutionFactory
{
  private readonly IEnumerable<IBeforeDotNet8Strategy> _strategies;
  public BeforeDotNet8SolutionFactory(IEnumerable<IBeforeDotNet8Strategy> strategies)
  {
    _strategies = strategies;
  }
  public IBeforeDotNet8Strategy Create(StrategyType type)
  {
    foreach (var strategy in _strategies)
    {
      if (strategy.Type == type)
      {
        return strategy;
      }
    }
    throw new NotImplementedException();
  }
}