using System;
using System.Collections;
using Code.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Services
{
    public class ObjectSpawnerService : IObjectSpawner
    {
        public event Action<GameObject> OnObjectSpawned;
        
        public IEnumerator SpawnObject(Vector3 position, AssetReferenceGameObject prefabReference)
        {
            var handle = prefabReference.InstantiateAsync(position, Quaternion.identity);
            yield return handle;
            OnObjectSpawned?.Invoke(handle.Result);
        }
    }
}