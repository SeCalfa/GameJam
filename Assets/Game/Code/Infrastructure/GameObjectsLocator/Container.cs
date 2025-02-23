using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Code.Infrastructure.GameObjectsLocator
{
    public class Container
    {
        private readonly List<GameObjectsDictionary> _gameObjects = new();

        public void RegisterGameObject(string name, GameObject gameObject)
        {
            _gameObjects.Add(new GameObjectsDictionary(name, gameObject));
        }

        public GameObject CreateGameObject(string name, string path)
        {
            var gameObject = Resources.Load(path) as GameObject;
            var gameObjectSpawned = Object.Instantiate(gameObject);
            
            return gameObjectSpawned;
        }
        
        public void RegisterGameObject(string name, string path)
        {
            var gameObject = Resources.Load(path) as GameObject;
            var gameObjectSpawned = Object.Instantiate(gameObject);
            
            _gameObjects.Add(new GameObjectsDictionary(name, gameObjectSpawned));
        }

        public T GetGameObjectByName<T>(string name)
        {
            var gameObject = _gameObjects.First(g => g.Name == name).GameObject;

            gameObject.TryGetComponent<T>(out var result);

            return result;
        }
        
        public GameObject GetGameObjectByName(string name)
        {
            var gameObject = _gameObjects.First(g => g.Name == name).GameObject;

            return gameObject;
        }

        public void RemoveGameObject(string name)
        {
            var gameObject = _gameObjects.FirstOrDefault(g => g.Name == name);
            Object.Destroy(gameObject?.GameObject);
            _gameObjects.Remove(gameObject);
        }

        public bool Contains(string name)
        {
            var gameObject = _gameObjects.FirstOrDefault(g => g.Name == name);

            return gameObject != null;
        }

        public void ClearAllGameObjects()
        {
            foreach (var go in _gameObjects)
            {
                Object.Destroy(go.GameObject);
            }
            
            _gameObjects.Clear();
        }
    }
}