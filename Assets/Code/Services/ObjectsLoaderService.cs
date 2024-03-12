using System.Collections.Generic;
using Code.Data;
using Code.Interfaces;
using Zenject;

namespace Code.Services
{
    public class ObjectsLoaderService : IObjectsLoader
    {
        [Inject]
        private ObjectsContainer objectsContainer;
        
        public List<ObjectData> LoadObjects()
        {
            return objectsContainer.ObjectDataList;
        }
    }
}