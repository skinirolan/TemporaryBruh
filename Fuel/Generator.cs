﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication;

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
