using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fuel;

/// <summary>
/// Контейнер для хранения генераторов и решения поставленной задачи
/// </summary>
public class GenContainer
{
    /// <summary>
    /// Массив с генераторами
    /// </summary>
    private Generator[] _generators;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="size">Размер контейнера</param>
    public GenContainer(int size)
    {
        _generators = new Generator[size];
    }

    /// <summary>
    /// Добавляет генератор в список генераторов
    /// </summary>
    /// <param name="generator">"Сырое" представление генератора"</param>
    public void push(string generator)
    {
       for (int i = 0; i < _generators.Length; i++)
        {
            if (_generators[i] == null)
            {
                _generators[i] = SerializeGenerator(generator);
                return;
            }
        }
    }

    /// <summary>
    /// Конвертирует генератор, представленный строкой в сущность типа Geneartor
    /// </summary>
    /// <param name="generator">"Генератор" в строковом представлении</param>
    /// <returns>Генератор</returns>
    private Generator SerializeGenerator(string generator)
    {
        var gen = generator.Split(",");
        var genOut = new Generator
        {
            Name = gen[0],
            Power = Convert.ToDouble(gen[1]),
            FuelConsumption = Convert.ToDouble(gen[2], new CultureInfo("en-US")),
        };

        return genOut;
    }

    /// <summary>
    /// С попощью метода двоичного перебора вычисляется наиболее эффективная комбинация включения генераторов
    /// </summary>
    /// <returns>Список имён генераторов на включение и количество топлива в литрах</returns>
    public (List<string>,double) GetNamesOfGenerators(double powerDemand, int daysDemand)
    {
        List<string> gensResult = new List<string>();
        byte[] gensOn = new byte[_generators.Length]; //какие гены включить

        int maxIterations = (int)Math.Pow(2,_generators.Length);
        double minSum = double.MaxValue;
        
        for (int i = 0; i < maxIterations; i++)
        {
            double sum = 0;
            double power = 0;

            byte[] multiplier = ConvertNumberToBinArr(i);

            int j = 0;

            foreach (var m in multiplier)
            {
                sum += _generators[j].FuelConsumption*multiplier[j];
                power += _generators[j].Power * multiplier[j];
                j++;
            }

            if (sum < minSum && powerDemand <= power)
            {
                minSum = sum;
                Array.Copy(multiplier, gensOn, gensOn.Length);
            }
        }

        for (int i = 0; i < _generators.Length; i++)
        {
            if (gensOn[i] == 1) gensResult.Add(_generators[i].Name);
        }
        if (gensResult.Count == 0 || minSum == double.MaxValue) return (null, -1);
        return (gensResult,minSum*daysDemand);
    }

    /// <summary>
    /// Переводит целое число из десятичной системы счисления в двоичную
    /// </summary>
    /// <param name="number">число</param>
    /// <returns>Двоичное представление числа в виде массива из нулей и единиц</returns>
    private byte[] ConvertNumberToBinArr(int number) 
    {
        byte[] binArr = new byte[_generators.Length];

        int i = 0;

        while (number > 0)
        {
            binArr[i] = (byte)(number % 2);
            number /= 2;
            i++;
        }
        return binArr;
    }
}
