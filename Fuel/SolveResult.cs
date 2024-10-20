using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel;

/// <summary>
/// Содержит информацию о необходимом топливе и списке имён генераторов на включение
/// </summary>
/// <param name="Names">Список имен генераторов на включение</param>
/// <param name="FuelDemand">Необходимо топлива</param>
public record SolveResult (List<string>Names, double FuelDemand);
