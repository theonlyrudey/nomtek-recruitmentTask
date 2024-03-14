using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Data
{
    [CreateAssetMenu(fileName = "ObjectContentAsset", menuName = "Data/Object Content Asset")]
    public class ObjectContentAsset : ScriptableObject
    {
        [SerializeField] private AssetReferenceSprite thumbnail;
        [SerializeField] private AssetReferenceGameObject prefab;
        
        public AssetReferenceSprite Thumbnail => thumbnail;
        public AssetReferenceGameObject Prefab => prefab;
    }
}