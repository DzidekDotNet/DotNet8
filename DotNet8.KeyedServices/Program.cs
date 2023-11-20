// See https://aka.ms/new-console-template for more information

using DotNet8.KeyedServices;
using DotNet8.KeyedServices.BeforeDotNet8Solution;
using DotNet8.KeyedServices.BookBasedSolution;
using DotNet8.KeyedServices.KeyedServiceSolution;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
  .AddTransient<IBookBasedSolutionFactory, BookBasedSolutionFactory>()
  .AddTransient<IBeforeDotNet8SolutionFactory, BeforeDotNet8SolutionFactory>()
  .AddAllInterfaceImplementations<IBeforeDotNet8Strategy>()
  .AddTransient<IKeyedServicesSolutionsFactory, KeyedServicesSolutionsFactory>()
  .AddAllInterfaceImplementationsAsKeyedServices<IKeyedServiceStrategy>()
  .BuildServiceProvider();

var bookBased = serviceProvider.GetRequiredService<IBookBasedSolutionFactory>();
Console.WriteLine(bookBased.Create(StrategyType.StrategyA).Print());
var beforeDotNet8 = serviceProvider.GetRequiredService<IBeforeDotNet8SolutionFactory>();
Console.WriteLine(beforeDotNet8.Create(StrategyType.StrategyA).Print());
var keyedService = serviceProvider.GetRequiredService<IKeyedServicesSolutionsFactory>();
Console.WriteLine(keyedService.Create(StrategyType.StrategyA).Print());
