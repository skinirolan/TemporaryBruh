using System.Globalization;
using System.Security.AccessControl;

namespace Fuel;

/// <summary>
/// Контейнер для хранения генераторов и решения поставленной задачи
/// </summary>
public class GeneratorManager
{
    /// <summary>
    /// Массив с генераторами
    /// </summary>
    private Generator[] _generators;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="size">Размер контейнера</param>
    public GeneratorManager(int size)
    {
        _generators = new Generator[size];
    }

    /// <summary>
    /// Добавляет генератор в список генераторов
    /// </summary>
    /// <param name="generator">"Сырое" представление генератора"</param>
    public void Push(string generator)
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
        var generatorInfo = generator.Split(",");
        if (generatorInfo.Count() != 3) throw new Exception("Ошибка ввода");
        var generatorOut = new Generator
        {
            Name = generatorInfo[0],
            Power = Convert.ToDouble(generatorInfo[1], new CultureInfo("en-US")),
            FuelConsumption = Convert.ToDouble(generatorInfo[2], new CultureInfo("en-US")),
        };
        if (generatorOut.FuelConsumption < 0 || generatorOut.Power < 0) throw new Exception("Ошибка ввода: параметры генераторов должны быть больше 0");
        return generatorOut;
    }

    /// <summary>
    /// С попощью метода двоичного перебора вычисляется наиболее эффективная комбинация включения генераторов
    /// </summary>
    /// <returns>Список имён генераторов на включение и количество топлива в литрах</returns>
    public SolveResult GetNamesOfGenerators(double powerDemand, int daysDemand)
    {
        List<string> generatorsResult = new List<string>();
        byte[] generatorsOn = new byte[_generators.Length]; 

        int maxIterations = (int)Math.Pow(2,_generators.Length);
        double minSum = double.MaxValue;
        
        for (int i = 0; i < maxIterations; i++)
        {
            double sum = 0;
            double power = 0;
            int j = 0;

            byte[] multiplier = ConvertNumberToBinArr(i);

            foreach (var m in multiplier)
            {
                sum += _generators[j].FuelConsumption*multiplier[j];
                power += _generators[j].Power * multiplier[j];
                j++;
            }

            if (sum < minSum && powerDemand <= power)
            {
                minSum = sum;
                Array.Copy(multiplier, generatorsOn, generatorsOn.Length);
            }
        }

        for (int i = 0; i < _generators.Length; i++)
        {
            if (generatorsOn[i] == 1) generatorsResult.Add(_generators[i].Name);
        }
        
        if (generatorsResult.Count == 0 || minSum == double.MaxValue) 
            return new SolveResult(null, -1);

        return new SolveResult(generatorsResult, 24*minSum * daysDemand);
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
