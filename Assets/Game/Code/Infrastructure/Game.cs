using Game.Code.Infrastructure.GameObjectsLocator;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene("Game");
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene("Map2");
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneManager.LoadScene("Map3");
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        private void Init()
        {
            Container = new Container();
        }
    }
}
