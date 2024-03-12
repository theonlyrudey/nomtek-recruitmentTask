using System;
using System.Collections;
using Code.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Code.Services
{
    public class ObjectSpawnerService : IObjectSpawner
    {
        private DiContainer container;
        public ObjectSpawnerService(DiContainer container)
        {
            this.container = container;
        }
        public event Action<GameObject> OnObjectSpawned;
        
        public IEnumerator SpawnObject(Vector3 position, AssetReferenceGameObject prefabReference)
        {
            var handle = prefabReference.InstantiateAsync(position, Quaternion.identity);
            yield return handle;
            container.InjectGameObject(handle.Result);
            OnObjectSpawned?.Invoke(handle.Result);
        }
    }
}