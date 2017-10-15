using System.Collections.Generic;

namespace DragonArmy.Dragons.Comparers
{
    public class TypeNameEqualityComparer : IEqualityComparer<Dragon>
    {
        public bool Equals(Dragon firstDragon, Dragon secondDragon)
        {
            return firstDragon.Name.Equals(secondDragon.Name) &&
                firstDragon.GetType().Equals(secondDragon.GetType());
        }

        public int GetHashCode(Dragon dragon)
        {
            return dragon.Name.GetHashCode() ^
                dragon.GetType().GetHashCode();
        }
    }
}
