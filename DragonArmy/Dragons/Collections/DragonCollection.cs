using DragonArmy.Dragons.Comparers;
using DragonArmy.Dragons.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using DragonArmy.Dragons.Collections.Visualizers.Interfaces;

namespace DragonArmy.Dragons.Collections
{
    public class DragonCollection : IDragonCollection
    {
        private readonly Dictionary<Type, ICollection<Dragon>> _dragons =
            new Dictionary<Type, ICollection<Dragon>>();
        private readonly IEqualityComparer<Dragon> _dragonEqualityComparer;
        private readonly IComparer<Dragon> _dragonComparer;
        private readonly IDragonCollectionVisualizer _visualizer;

        public DragonCollection(IEqualityComparer<Dragon> dragonEqualityComparer,
            IComparer<Dragon> dragonComparer,
            IDragonCollectionVisualizer visualizer)
        {
            _dragonEqualityComparer = dragonEqualityComparer;
            _dragonComparer = dragonComparer;
            _visualizer = visualizer;
        }

        public void Add(Dragon dragon)
        {
            var dragonType = dragon.GetType();
            if (_dragons.ContainsKey(dragonType))
            {
                var existingDragon = _dragons[dragonType].SingleOrDefault(setDragon =>
                    _dragonEqualityComparer.Equals(dragon, setDragon));
                if (existingDragon == null)
                    _dragons[dragonType].Add(dragon);
                else
                    existingDragon = dragon;
            }
            else
            {
                _dragons.Add(dragonType, new SortedSet<Dragon>(_dragonComparer)
                    { dragon });
            }
        }

        public IEnumerator<KeyValuePair<Type, ICollection<Dragon>>> GetEnumerator()
        {
            return _dragons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Print()
        {
            _visualizer.Visualize(this);
        }
    }
}
