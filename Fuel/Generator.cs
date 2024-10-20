using System;
using System.Collections.Generic;
using System.Text;

namespace Fuel;

/// <summary>
/// Сущность "генератор"
/// </summary>
public class Generator
{
    /// <summary>
    /// Название модели генератора
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Мощность,  вырабатываемая генераторм
    /// </summary>
    public double Power {  get; set; }

    /// <summary>
    /// Потребление генератора топливом
    /// </summary>
    public double FuelConsumption { get; set; }
}
