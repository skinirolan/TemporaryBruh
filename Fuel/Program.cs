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
        Console.Write($"{item}; ");
    }
    Console.WriteLine();
}
catch (FormatException ex)
{
    Console.WriteLine("Ошибка ввода");
} 
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


