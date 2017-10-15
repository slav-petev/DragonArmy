using DragonArmy.Dragons.Collections;
using DragonArmy.Dragons.Collections.Visualizers.Implementations;
using DragonArmy.Dragons.Comparers;
using DragonArmy.Dragons.Factories;
using System;
using System.IO;

namespace DragonArmy
{
    class DragonArmyConsoleClient
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("ZeroTests.txt"));

            var dragonFactory = new DragonFactory();

            var numberOfDragons = int.Parse(
                Console.ReadLine());

            var dragons = new DragonCollection(new TypeNameEqualityComparer(),
                new DragonNameComparer(),
                new DragonCollectionConsoleVisualizer());
            for (var i = 0; i < numberOfDragons; i++)
            {
                var dragonInfo = Console.ReadLine();
                var dragon = dragonFactory.Create(dragonInfo);
                dragons.Add(dragon);
            }

            dragons.Print();
        }
    }
}
