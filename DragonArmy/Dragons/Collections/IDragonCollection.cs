using System;
using System.Collections.Generic;

namespace DragonArmy.Dragons.Collections
{
    public interface IDragonCollection : 
        IEnumerable<KeyValuePair<Type, ICollection<Dragon>>>
    {
        void Add(Dragon dragon);
        void Print();
    }
}
