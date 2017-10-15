using DragonArmy.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DragonArmy.Dragons.Factories
{
    public class DragonFactory
    {
        private readonly Dictionary<string, Type> _dragonTypes;

        public DragonFactory()
        {
            _dragonTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Dragon)))
                .ToDictionary(
                    key => key.Name.Remove(key.Name.IndexOf("Dragon")),
                    value => value);
        }

        public Dragon Create(string dragonInfo)
        {
            var dragonInfoParts = dragonInfo.Split();
            var dragonType = _dragonTypes[dragonInfoParts[0]];
            var dragonName = dragonInfoParts[1];
            var dragonDamage = Damage.Create(dragonInfoParts[2]);
            var dragonHealth = Health.Create(dragonInfoParts[3]);
            var dragonArmor = Armor.Create(dragonInfoParts[4]);

            return (Dragon)Activator.CreateInstance(
                dragonType,
                dragonName,
                dragonDamage,
                dragonHealth,
                dragonArmor);
        }
    }
}
