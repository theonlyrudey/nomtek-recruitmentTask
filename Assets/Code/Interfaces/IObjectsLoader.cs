using System.Collections.Generic;
using Code.Data;

namespace Code.Interfaces
{
    public interface IObjectsLoader
    {
        List<ObjectData> LoadObjects();
    }
}