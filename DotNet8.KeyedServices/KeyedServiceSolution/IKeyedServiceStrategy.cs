namespace DotNet8.KeyedServices.KeyedServiceSolution;

internal interface IKeyedServiceStrategy
{
  public string Print();
}

[KeyedService(StrategyType.StrategyA)]
internal sealed class KeyedServiceStrategyAStrategy : IKeyedServiceStrategy
{
  public string Print() => "KeyedServiceStrategyAStrategy";
}
[KeyedService(StrategyType.StrategyB)]
internal sealed class KeyedServiceStrategyBStrategy : IKeyedServiceStrategy
{
  public string Print() => "KeyedServiceStrategyBStrategy";
}