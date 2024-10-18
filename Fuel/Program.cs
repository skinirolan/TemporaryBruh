using ConsoleApplication;

Console.WriteLine("Введите необходимую для поселения мощность");

var powerDemand = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите количество дней для расчёта");

var demandDays = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите количество генераторов");

int numOfGens = Convert.ToInt32(Console.ReadLine());

var container = new GenContainer();

for (int i = 0; i < numOfGens; i++)
{
    string rawGenerator = Console.ReadLine();
    container.push(rawGenerator);
}


