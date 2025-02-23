using Game.Code.Infrastructure.GameObjectsLocator;
using Game.Code.Logic.GUI.FadeIn;
using Game.Code.Logic.GUI.TransitionController;
using UnityEngine;

namespace Game.Code.Infrastructure
{
    public class Game : MonoBehaviour
    {
        public static Game Instance { get; private set; }
        
        public Container Container { get; private set; }
        public SpriteRendererFade SpriteRendererFade { get; private set; }

        private SceneTransitionController SceneTransitionController { get; set; }

        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            
            Instance = this;
            
            Init();
            CreateSpriteFade();
            CreateTransitionController();
            
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneTransitionController.StartSceneTransition("Game");
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneTransitionController.StartSceneTransition("Map2");
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneTransitionController.StartSceneTransition("Map3");
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

        private void CreateTransitionController()
        {
            Container.RegisterGameObject(Constants.CurtainSceneName, Constants.CurtainSceneTransitionPath);
            SceneTransitionController = Container.GetGameObjectByName<SceneTransitionController>(Constants.CurtainSceneName);
            
            DontDestroyOnLoad(SceneTransitionController.gameObject);
        }
    }
}
