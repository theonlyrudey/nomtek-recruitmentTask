using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.Data;
using Code.Interfaces;
using Code.UI.Elements;
using Code.UI.Views;
using UnityEngine;
using Zenject;

namespace Code.UI.Controllers
{
    public class ObjectsLoaderPopupController : MonoBehaviour
    {
        [SerializeField] private ObjectsLoaderPopupView view;
        [SerializeField] private SpawnableObjectElement spawnableObjectElement;
        
        [Inject] private IObjectsLoader objectsLoader;
        [Inject] private IObjectSpawner objectSpawner;
        [Inject] private IObjectPlacement objectPlacement;

        private List<ObjectData> objectsData;
        private Dictionary<string, List<SpawnableObjectElement>> elements = new();
        
        private async void Awake()
        {
            objectsData = objectsLoader.LoadObjects();
            objectPlacement.OnObjectPlaced += OnObjectPlaced;
            objectPlacement.OnPlacementCancelled += OnPlacementCancelled;
            await CreateElements();
            view.Show();
        }
        
        private async Task CreateElements()
        {
            foreach (var objectData in objectsData)
            {
                var thumbnailLoadTask = objectData.Thumbnail.LoadAssetAsync().Task;
                await thumbnailLoadTask;
                
                var thumbnail = thumbnailLoadTask.Result;
                var element = Instantiate(spawnableObjectElement, view.ContentParent);
                element.Initialize(objectData.Name, thumbnail);
                element.OnButtonClicked += OnElementButtonClicked;
                
                AddElement(objectData.Name, element);
            }
        }
        
        private void OnElementButtonClicked(string label)
        {
            StartCoroutine(objectSpawner.SpawnObject(Vector3.zero, objectsData.First(obj => obj.Name == label).Prefab));
            view.Hide();
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
        
        private void OnPlacementCancelled()
        {
            view.Show();
        }

        private void OnObjectPlaced()
        {
            view.Show();
        }

    }
}