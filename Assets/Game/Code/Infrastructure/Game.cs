using Game.Code.Infrastructure.GameObjectsLocator;
using Game.Code.Logic.Audio;
using Game.Code.Logic.GUI.Fade;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Infrastructure
{
    public class Game : MonoBehaviour
    {
        public static Game Instance { get; private set; }
        
        public Container Container { get; private set; }
        public SpriteRendererFade SpriteRendererFade { get; private set; }
        public Curtain Curtain { get; private set; }
        public SoundManager SoundManager { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            
            Instance = this;
            
            Init();
            CreateSpriteFade();
            CreateCurtain();
            CreateSoundManager();
            
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Curtain.Show(() =>
                {
                    SceneManager.LoadScene("Game");
                });
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Curtain.Show(() =>
                {
                    SceneManager.LoadScene("Map2");
                });
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Curtain.Show(() =>
                {
                    SceneManager.LoadScene("Map3");
                });
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

        private void CreateSpriteFade()
        {
            Container.RegisterGameObject(Constants.SpriteFadeName, Constants.SpriteFadePath);
            SpriteRendererFade = Container.GetGameObjectByName<SpriteRendererFade>(Constants.SpriteFadeName);
            
            DontDestroyOnLoad(SpriteRendererFade.gameObject);
        }

        private void CreateCurtain()
        {
            Container.RegisterGameObject(Constants.CurtainName, Constants.CurtainPath);
            Curtain = Container.GetGameObjectByName<Curtain>(Constants.CurtainName);
            
            DontDestroyOnLoad(Curtain.gameObject);
        }
        
        private void CreateSoundManager()
        {
            Container.RegisterGameObject(Constants.SoundManagerName, Constants.SoundManagerPath);
            SoundManager = Container.GetGameObjectByName<SoundManager>(Constants.SoundManagerName);
            
            DontDestroyOnLoad(SoundManager.gameObject);
        }
    }
}
