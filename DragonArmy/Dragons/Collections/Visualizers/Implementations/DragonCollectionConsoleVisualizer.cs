using DragonArmy.Dragons.Collections.Visualizers.Interfaces;
using DragonArmy.Dragons.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy.Dragons.Collections.Visualizers.Implementations
{
    public class DragonCollectionConsoleVisualizer : IDragonCollectionVisualizer
    {
        public void Visualize(IDragonCollection dragonCollection)
        {
            foreach (var element in dragonCollection)
            {
                var dragonTypeSummary = DragonTypeStatistics
                    .Create(element.Key, element.Value);
                Console.WriteLine(dragonTypeSummary);
                foreach (var dragon in element.Value)
                {
                    Console.WriteLine($"-{dragon}");
                }
            }
        }
    }
}
