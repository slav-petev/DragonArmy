using System.Collections.Generic;

namespace DragonArmy.Dragons.Comparers
{
    public class DragonNameComparer : IComparer<Dragon>
    {
        public int Compare(Dragon first, Dragon second)
        {
            return first.Name.CompareTo(second.Name);
        }
    }
}
