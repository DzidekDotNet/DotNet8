using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet8.KeyedServices;

internal static class ServiceCollectionExtensions
{
  internal static IServiceCollection AddAllInterfaceImplementations<T>(this IServiceCollection services)
  {
    services.Scan(s =>
      s.FromAssemblyOf<T>().AddClasses(c => c.AssignableTo<T>()).AsImplementedInterfaces().WithTransientLifetime());
    return services;
  }
  internal static IServiceCollection AddAllInterfaceImplementationsAsKeyedServices<T>(this IServiceCollection services)
  {
    var implementations = Assembly.GetExecutingAssembly()
      .GetTypes()
      .Where(t => t.GetInterfaces().Contains(typeof(T)));

    foreach (var concreteImplementationType in implementations)
    {
      var attributes = Attribute.GetCustomAttributes(concreteImplementationType, typeof(KeyedServiceAttribute)).OfType<KeyedServiceAttribute>().ToList();
      if (attributes.Any())
      {
        services.AddKeyedTransient(typeof(T), attributes.First().ServiceType, concreteImplementationType);
      }
    }
    return services;
  }
}

internal sealed class KeyedServiceAttribute : Attribute
{
  internal StrategyType ServiceType { get; }
  public KeyedServiceAttribute(StrategyType serviceType)
  {
    ServiceType = serviceType;
  }
}
