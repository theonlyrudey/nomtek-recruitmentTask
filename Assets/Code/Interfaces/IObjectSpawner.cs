using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Interfaces
{
    public interface IObjectSpawner
    {
        event Action<GameObject> OnObjectSpawned;
        IEnumerator SpawnObject(Vector3 position, AssetReferenceGameObject prefabReference);
    }
}