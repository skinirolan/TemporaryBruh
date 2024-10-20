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
    private GeneratorManager _generators;
    private SolveResult _solveResult;

    /// <summary>
    /// Метод ввода данных
    /// </summary>
    public void Input()
    {

        Console.WriteLine("Введите необходимую для поселения мощность в кВт");

        _powerDemand = Convert.ToDouble(Console.ReadLine(), new CultureInfo("en-US"));

        Console.WriteLine("Введите целое количество дней для расчёта");

        _demandDays = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите количество генераторов");

        _numberOfGenerators = Convert.ToInt32(Console.ReadLine());

        _generators = new GeneratorManager(_numberOfGenerators);

        BelowZeroCheck();

        Console.WriteLine("Введите данные о генераторах в формате: [Имя_генератора], [Мощность в кВт], [Потребление в литрах/час]\nПример ввода: Generator_name1, 12, 2.8");

        for (int i = 0; i < _numberOfGenerators; i++)
        {
            string rawGenerator = Console.ReadLine();
            _generators.Push(rawGenerator);
        }
        Process();
    }

    /// <summary>
    /// Получение списка имён генераторов
    /// </summary>
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
            if (_solveResult.FuelDemand == -1) 
                throw new Exception("Ошибка: с заданным вводом невозможно обеспечить поселение энергией");
            return _solveResult;
        }
        throw new Exception("Произошла непредвиденная ошибка");
    }

    /// <summary>
    /// Проверка значений на корректность
    /// </summary>
    private void BelowZeroCheck()
    {
        if (_powerDemand <= 0 || _demandDays <= 0 || _numberOfGenerators <= 0) throw new Exception("Ошибка ввода: все значения должны быть больше 0");
    }
}
