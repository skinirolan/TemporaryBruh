using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication;

public class GenContainer
{
    /// <summary>
    /// Список с генераторами
    /// </summary>
    private IEnumerable<Generator> Generators;


    public GenContainer()
    {
        Generators = new List<Generator>();
    }

    /// <summary>
    /// Добавляет генератор в список генераторов
    /// </summary>
    /// <param name="generator">"Сырое" представление генератора"</param>
    public void push(string generator)
    {
        Generators.Append(SerializeGenerator(generator));
    }

    /// <summary>
    /// Конвертирует генератор, представленный строкой в сущность типа Geneartor
    /// </summary>
    /// <param name="generator">"Генератор" в строковом представлении</param>
    /// <returns></returns>
    private Generator SerializeGenerator(string generator)
    {
        var genOut = new Generator
        {
            Name = "d",
            Power = 1,
            FuelConsumption = 2
        };
        return genOut;
    }
}
