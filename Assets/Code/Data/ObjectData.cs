using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Data
{
    [System.Serializable]
    public class ObjectData
    {
        [SerializeField] private string name;
        [SerializeField] private AssetReferenceSprite thumbnail;
        [SerializeField] private AssetReferenceGameObject prefab;
        
        public string Name => name;
        public AssetReferenceSprite Thumbnail => thumbnail;
        public AssetReferenceGameObject Prefab => prefab;
    }
}
