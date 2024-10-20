using Fuel;
using System.Globalization;

try
{
    var UI = new UserInteraction();
    UI.Input();
    UI.Output();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}


