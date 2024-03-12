using System;
using System.Collections.Generic;
using Code.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class EdiblesHolderService : IEdiblesHolder, IDisposable
    {
        public EdiblesHolderService(IObjectPlacement objectSpawner)
        {
            objectSpawner.OnObjectPlaced += OnObjectPlaced;
        }
        
        public List<IEdible> Edibles { get; } = new();
        
        public event Action OnEdibleAdded;
        public event Action OnEdibleRemoved;
        
        public void AddEdible(IEdible edible)
        {
            if (Edibles.Contains(edible)) return;
            edible.OnEaten += RemoveEdible;
            Edibles.Add(edible);
            OnEdibleAdded?.Invoke();
        }

        public void RemoveEdible(IEdible edible)
        {
            if (!Edibles.Contains(edible)) return;
            edible.OnEaten -= RemoveEdible;
            Edibles.Remove(edible);
            OnEdibleRemoved?.Invoke();
        }

        private void OnObjectPlaced(GameObject obj)
        {
            if(obj == null) return;
            var edible = obj.GetComponent<IEdible>();
            if (edible == null) return;
            AddEdible(edible);
        }

        public void Dispose()
        {
            Edibles.Clear();
        }
    }
}