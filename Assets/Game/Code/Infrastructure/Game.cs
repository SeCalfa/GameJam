using Game.Code.Infrastructure.GameObjectsLocator;
using Game.Code.Logic.Audio;
using Game.Code.Logic.GUI;
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
        public Hud Hud { get; private set; }
        
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
        
        public void CreateHud()
        {
            Container.RegisterGameObject(Constants.HudName, Constants.HudPath);
            Hud = Container.GetGameObjectByName<Hud>(Constants.HudName);
            
            DontDestroyOnLoad(Hud.gameObject);
        }
        
        public void CreatePlayer()
        {
            var player = Container.CreateGameObject(Constants.PlayerName, Constants.PlayerPath);
            var startPoint = GameObject.FindWithTag("StartPoint").transform.position;

            player.transform.position = startPoint;
        }

        public void ClearGame()
        {
            Container.ClearAllGameObjects();
            Destroy(gameObject);
        }
    }
}
