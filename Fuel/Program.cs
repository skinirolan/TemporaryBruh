using Fuel;
using System.Globalization;

try
{
    var UI = new UserInteraction();
    UI.Input();
    SolveResult result = UI.Output();
    Console.Write($"Необходимо литров топлива: {result.FuelDemand}, оптимальный список генераторов на включение: ");
    foreach( var item in result.Names)
    {
        Console.Write($"{item}, ");
        Console.WriteLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


