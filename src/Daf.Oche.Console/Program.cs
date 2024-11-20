// See https://aka.ms/new-console-template for more information
using Daf.Oche.Console;

var name = args[0] ?? string.Empty;
var oche = new Oche(name);
oche.Execute();