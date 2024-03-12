using System.Collections;
using Code.Installers;
using Code.Interfaces;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace UnitTests
{
    [TestFixture]
    public class DataLoadingTests : ZenjectUnitTestFixture
    {
        [SetUp]
        public void CommonInstall()
        {
            string path = "Data/MainScriptableObjectsInstaller";
            MainScriptableObjectsInstaller.InstallFromResource(path, Container);
            TestInstaller.Install(Container);
        }
        
        [Test]
        public void WillILoaderResolve()
        {
            IObjectsLoader loader = Container.Resolve<IObjectsLoader>();
            Assert.NotNull(loader);
        }

        [Test]
        public void WillLoadData()
        {
            IObjectsLoader loader = Container.Resolve<IObjectsLoader>();
            var list = loader.LoadObjects();
            Assert.NotNull(list);
        }

        [Test]
        public void HasAnyData()
        {
            IObjectsLoader loader = Container.Resolve<IObjectsLoader>();
            var list = loader.LoadObjects();
            Debug.Log($"List count: {list.Count}");
            Assert.Greater(list.Count, 0);
        }

        [UnityTest]
        public IEnumerator WillSpawnerSpawn()
        {
            IObjectSpawner spawner = Container.Resolve<IObjectSpawner>();
            IObjectsLoader loader = Container.Resolve<IObjectsLoader>();

            var list = loader.LoadObjects();
            Assert.Greater(list.Count, 0, "No data objects loaded.");

            bool objectSpawned = false;
            GameObject spawnedObject = null;
            
            void OnObjectSpawned(GameObject obj)
            {
                objectSpawned = true;
                spawnedObject = obj;
                Assert.NotNull(obj, "Spawned object is null.");
            }

            spawner.OnObjectSpawned += OnObjectSpawned;
            yield return spawner.SpawnObject(Vector3.zero, list[0].Prefab);
            
            if (spawnedObject != null)
            {
                Object.DestroyImmediate(spawnedObject);
            }

            spawner.OnObjectSpawned -= OnObjectSpawned;
        }
    }
}
