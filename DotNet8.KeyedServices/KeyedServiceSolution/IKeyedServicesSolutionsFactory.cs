using Microsoft.Extensions.DependencyInjection;

namespace DotNet8.KeyedServices.KeyedServiceSolution;

internal interface IKeyedServicesSolutionsFactory
{
  public IKeyedServiceStrategy Create(StrategyType type);
}

internal sealed class KeyedServicesSolutionsFactory : IKeyedServicesSolutionsFactory
{
  private readonly IServiceProvider _serviceProvider;
  public KeyedServicesSolutionsFactory(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }
  public IKeyedServiceStrategy Create(StrategyType type)
  {
    return _serviceProvider.GetRequiredKeyedService<IKeyedServiceStrategy>(type);
  }
}
