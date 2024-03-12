using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.Data;
using Code.Interfaces;
using Code.UI.Elements;
using Code.UI.Views;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Code.UI.Controllers
{
    public class ObjectsLoaderPopupController : MonoBehaviour
    {
        [SerializeField] private ObjectsLoaderPopupView view;
        [SerializeField] private AssetReferenceGameObject spawnableObjectElement;
        
        [Inject] private IObjectsLoader objectsLoader;
        [Inject] private IObjectSpawner objectSpawner;
        [Inject] private IObjectPlacement objectPlacement;
        [Inject] private ITextFilter textFilter;
        [Inject] private IObjectsListUI objectsListUI;

        private List<ObjectData> objectsData;
        
        private async void Awake()
        {
            objectsData = objectsLoader.LoadObjects();
            SubscribeEvents();
            await objectsListUI.CreateObjects(spawnableObjectElement, objectsData, view.ContentParent);
            view.Show();
        }

        private void OnElementButtonClicked(string label)
        {
            StartCoroutine(objectSpawner.SpawnObject(Vector3.zero, objectsData.First(obj => obj.Name == label).Prefab));
            view.Hide();
        }

        private void OnPlacementStatusChanged(GameObject obj)
        {
            view.Show();
        }

        private void SubscribeEvents()
        {
            objectPlacement.OnObjectPlaced += OnPlacementStatusChanged;
            objectPlacement.OnPlacementCancelled += OnPlacementStatusChanged;
            textFilter.OnTextFiltered += objectsListUI.SetFilter;
            objectsListUI.OnElementButtonClicked += OnElementButtonClicked;
        }
    }
}