using System.Collections.Generic;
using UnityEngine;

namespace Code.Data
{
    [CreateAssetMenu(fileName = "ObjectsContainer", menuName = "Data/ObjectsContainer")]
    public class ObjectsContainer : ScriptableObject
    {
        [SerializeField] private List<ObjectData> objectDataList;
        
        public List<ObjectData> ObjectDataList => objectDataList;
    }
}
