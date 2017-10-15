using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy.Dragons.Statistics
{
    public class DragonTypeStatistics
    {
        public string TypeName { get; private set; }
        public double AverageDamage { get; private set; }
        public double AverageHealth { get; private set; }
        public double AverageArmor { get; private set; }

        private DragonTypeStatistics(string typeName, double averageDamage,
            double averageHealth, double averageArmor)
        {
            this.TypeName = typeName;
            this.AverageDamage = averageDamage;
            this.AverageHealth = averageHealth;
            this.AverageArmor = averageArmor;
        }

        public override string ToString()
        {
            return $"{this.TypeName}::({this.AverageDamage:F2}/{this.AverageHealth:F2}/{this.AverageArmor:F2})";
        }

        public static DragonTypeStatistics Create(Type dragonType,
            IEnumerable<Dragon> dragons)
        {
            var dragonTypeName = dragonType.Name.Remove(
                dragonType.Name.IndexOf("Dragon"));
            var averageDamage = dragons
                .Select(dragon => dragon.Damage.Value)
                .Average();
            var averageHealth = dragons
                .Select(dragon => dragon.Health.Value)
                .Average();
            var averageArmor = dragons
                .Select(dragon => dragon.Armor.Value)
                .Average();

            return new DragonTypeStatistics(dragonTypeName, averageDamage,
                averageHealth, averageArmor);
        }
    }
}
