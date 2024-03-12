using System;
using UnityEngine;

namespace Code.Interfaces
{
    public interface IEdible
    {
        event Action<IEdible> OnEaten;
        void GetEaten();
        Vector3 Position { get; }
        bool Initialized { get; }
    }
}