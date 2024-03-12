using System;
using System.Collections.Generic;

namespace Code.Interfaces
{
    public interface IEdiblesHolder
    {
        event Action OnEdibleAdded;
        event Action  OnEdibleRemoved;
        List<IEdible> Edibles { get; }
        void AddEdible(IEdible edible);
        void RemoveEdible(IEdible edible);
    }
}