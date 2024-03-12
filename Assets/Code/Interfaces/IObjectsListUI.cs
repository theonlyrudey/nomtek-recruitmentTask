using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Data;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Interfaces
{
    public interface IObjectsListUI
    {
        event Action<string> OnElementButtonClicked;
        Task CreateObjects(AssetReferenceGameObject prefab, List<ObjectData> objectsData, Transform parent);
        void SetFilter(string text);
    }
}
