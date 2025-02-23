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
        
        private void Awake()
        {
            _sceneFade = Game.Instance.SpriteRendererFade;
            if (levelType != LevelType.Intro) _sceneFade.Init(darkSide);
            
            _curtain = Game.Instance.Curtain;
            _curtain.Hide();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) && _sceneFade)
            {
                _sceneFade.Show();
            }
            
            if (Input.GetKeyDown(KeyCode.T) && _sceneFade)
            {
                _sceneFade.Hide();
            }
        }
    }
}