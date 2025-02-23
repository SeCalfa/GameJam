using System.Collections.Generic;
using Game.Code.Logic.GUI.Fade;
using UnityEngine;

namespace Game.Code.Infrastructure
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelType levelType;
        [SerializeField] private List<SpriteRenderer> darkSide;
        
        private SpriteRendererFade _sceneFade;
        private Curtain _curtain;
        
        public LevelType GetLevelType => levelType;
        
        public static LevelManager Instance { get; private set; }
        
        private void Awake()
        {
            Instance = this;
            
            _sceneFade = Game.Instance.SpriteRendererFade;
            if (levelType != LevelType.Intro && levelType != LevelType.MainMenu) _sceneFade.Init(darkSide);
            
            if (levelType == LevelType.Map1)
            {
                Game.Instance.CreateHud();
                Game.Instance.CreatePlayer();
                
                if (Game.Instance.Hud.DarkSideOn)
                    Game.Instance.SpriteRendererFade.Show();
            }
            else if (levelType == LevelType.Map2)
            {
                Game.Instance.CreatePlayer();
                
                if (Game.Instance.Hud.DarkSideOn)
                    Game.Instance.SpriteRendererFade.Show();
            }
            else if (levelType == LevelType.Map3)
            {
                Game.Instance.CreatePlayer();
                
                if (Game.Instance.Hud.DarkSideOn)
                    Game.Instance.SpriteRendererFade.Show();
            }
            
            _curtain = Game.Instance.Curtain;
            _curtain.Hide();
        }
    }
}