using Game.Code.Infrastructure.GameObjectsLocator;
using UnityEngine;

namespace Game.Code.Infrastructure
{
    public class Game : MonoBehaviour
    {
        public static Game Instance;
        
        public Container Container { get; private set; }
        
        private void Awake()
        {
            Instance = this;
            
            Init();
            DontDestroyOnLoad(gameObject);
        }

        private void Init()
        {
            Container = new Container();
        }
    }
}
