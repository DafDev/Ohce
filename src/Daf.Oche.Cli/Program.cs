// See https://aka.ms/new-console-template for more information
using Daf.Oche.Cli;
using Daf.Oche.Domain.IoC;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddDomain()
    .AddSingleton<Oche>();
var name = args[0] ?? string.Empty;
var oche = services.BuildServiceProvider().GetRequiredService<Oche>();
oche.Execute();