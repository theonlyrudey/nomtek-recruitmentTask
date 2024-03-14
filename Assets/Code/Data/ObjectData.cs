using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Data
{
    [System.Serializable]
    public class ObjectData
    {
        [SerializeField] private string name;
        [SerializeField] private ObjectContentAsset content;
        
        public string Name => name;
        public AssetReferenceSprite Thumbnail => content.Thumbnail;
        public AssetReferenceGameObject Prefab => content.Prefab;
    }
}
