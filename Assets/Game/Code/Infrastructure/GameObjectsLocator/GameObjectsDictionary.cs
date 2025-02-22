using UnityEngine;

namespace Game.Code.Infrastructure.GameObjectsLocator
{
    public class GameObjectsDictionary
    {
        public string Name { get; }
        public GameObject GameObject { get; }

        public GameObjectsDictionary(string name, GameObject gameObject)
        {
            Name = name;
            GameObject = gameObject;
        }
    }
}