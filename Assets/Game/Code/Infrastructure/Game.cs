using Game.Code.Infrastructure.GameObjectsLocator;
using Game.Code.Logic.GUI.FadeIn;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Infrastructure
{
    public class Game : MonoBehaviour
    {
        public static Game Instance { get; private set; }
        
        public Container Container { get; private set; }
        public SpriteRendererFade SpriteRendererFade { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            
            Instance = this;
            
            Init();
            CreateObjects();
            
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

        private void CreateObjects()
        {
            Container.RegisterGameObject(Constants.SpriteFadeName, Constants.SpriteFadePath);
            SpriteRendererFade = Container.GetGameObjectByName<SpriteRendererFade>(Constants.SpriteFadeName);
            
            DontDestroyOnLoad(SpriteRendererFade.gameObject);
        }
    }
}
