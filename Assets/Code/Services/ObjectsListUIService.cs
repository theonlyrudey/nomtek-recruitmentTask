using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Data;
using Code.Interfaces;
using Code.UI.Elements;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ObjectsListUIService : IObjectsListUI
{
    private Dictionary<string, List<SpawnableObjectElement>> elements = new();
    
    public event Action<string> OnElementButtonClicked;
    
    public async Task CreateObjects(AssetReferenceGameObject prefab, List<ObjectData> objectsData, Transform parent)
    {
        foreach (var objectData in objectsData)
        {
            var thumbnailLoadTask = objectData.Thumbnail.LoadAssetAsync().Task;
            await thumbnailLoadTask;
            var thumbnail = thumbnailLoadTask.Result;

            var elementLoadTask = prefab.InstantiateAsync(parent).Task;
            await elementLoadTask;
            var element = elementLoadTask.Result.GetComponent<SpawnableObjectElement>();
            
            element.Initialize(objectData.Name, thumbnail);
            element.OnButtonClicked += OnElementButtonClickedHandler;
                
            AddElement(objectData.Name, element);
        }
    }

    public void SetFilter(string text)
    {
        foreach (var kvp in elements)
        {
            bool elementEnabled = kvp.Key.ToLower().Contains(text.ToLower());
            foreach (var element in kvp.Value)
            {
                element.Enabled = elementEnabled;
            }
        }
    }
    
    private void AddElement(string objectName, SpawnableObjectElement element)
    {
        if (!elements.ContainsKey(objectName))
        {
            elements.Add(objectName, new List<SpawnableObjectElement>{element});
        }
        else
        {
            elements[objectName].Add(element);
        }
    }
    
    private void OnElementButtonClickedHandler(string label)
    {
        OnElementButtonClicked?.Invoke(label);
    }
}
