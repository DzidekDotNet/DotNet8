namespace DotNet8.KeyedServices.BeforeDotNet8Solution;

internal interface IBeforeDotNet8Strategy
{
  public StrategyType Type { get; }
  public string Print();
}

internal sealed class BeforeDotNet8StrategyAStrategy : IBeforeDotNet8Strategy
{
  public StrategyType Type => StrategyType.StrategyA;
  public string Print() => "BeforeDotNet8StrategyAStrategy";
}

internal sealed class BeforeDotNet8StrategyBStrategy : IBeforeDotNet8Strategy
{
  public StrategyType Type => StrategyType.StrategyB;
  public string Print() => "BeforeDotNet8StrategyBStrategy";
}