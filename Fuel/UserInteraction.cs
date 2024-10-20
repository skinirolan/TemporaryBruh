using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel;

/// <summary>
/// Класс для взаимодействия приложения с пользователем
/// </summary>
public class UserInteraction
{
    private double _powerDemand;
    private int _demandDays;
    private int _numberOfGenerators;
    private GeneratorContainer _generators;
    private SolveResult _solveResult;

    /// <summary>
    /// Метод ввода данных
    /// </summary>
    public void Input()
    {
        try
        {
            Console.WriteLine("Введите необходимую для поселения мощность в кВт");

            _powerDemand = Convert.ToDouble(Console.ReadLine(), new CultureInfo("en-US"));

            Console.WriteLine("Введите целое количество дней для расчёта");

            _demandDays = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество генераторов");

            _numberOfGenerators = Convert.ToInt32(Console.ReadLine());

            _generators = new GeneratorContainer(_numberOfGenerators);

            Console.WriteLine("Введите данные о генераторах в формате: [Имя_генератора], [Мощность в кВт], [Потребление в литрах]\nПример ввода: Generator_name1, 12, 2.8");

            for (int i = 0; i < _numberOfGenerators; i++)
            {
                string rawGenerator = Console.ReadLine();
                _generators.push(rawGenerator);
            }
            Process();
        }
        catch
        {
            Console.WriteLine("Ошибка ввода");
        }
    }

    private void Process() 
    {
        _solveResult = _generators.GetNamesOfGenerators(_powerDemand, _demandDays);
    }

    /// <summary>
    /// Метод вывода результата
    /// </summary>
    /// <returns>Список имен генеарторов на включение и необходимый литраж топлива</returns>
    /// <exception cref="Exception"></exception>
    public SolveResult Output() 
    {
        if (_solveResult != null) 
        {
            return _solveResult;
        }
        if (_solveResult.FuelDemand == -1) throw new Exception("Ошибка: с заданным вводом цель недостижима");
        throw new Exception("Произошла непредвиденная ошибка");
    }
}
