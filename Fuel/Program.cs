using Fuel;
using System.Globalization;

try
{
    Console.WriteLine("Введите необходимую для поселения мощность в кВт");

    var powerDemand = Convert.ToDouble(Console.ReadLine(), new CultureInfo("en-US"));

    Console.WriteLine("Введите целое количество дней для расчёта");

    var demandDays = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Введите количество генераторов");

    int numOfGens = Convert.ToInt32(Console.ReadLine());

    var container = new GenContainer(numOfGens);

    Console.WriteLine("Введите данные о генераторах в формате: [Имя_генератора], [Мощность в кВт], [Потребление в литрах]");
    Console.WriteLine("Пример ввода: Generator_name1, 12, 2.8");

    for (int i = 0; i < numOfGens; i++)
    {

        string rawGenerator = Console.ReadLine();
        container.push(rawGenerator);
    }

    (List<string>, double) res = container.GetNamesOfGenerators(powerDemand, demandDays);
    Console.Write("Необходимо влключить генераторы: ");
    foreach (var name in res.Item1)
    {
        Console.Write(name + ", ");
    }
    Console.WriteLine($"\nНеобходимо {res.Item2} литров дизельного топлива");
    Console.ReadLine();
}
catch 
{
    Console.WriteLine("Произошла неппредвиденная ошибка");
}


