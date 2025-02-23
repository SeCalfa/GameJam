using System.Collections.Generic;
using Game.Code.Logic.Audio;
using Game.Code.Logic.GUI.FadeIn;
using UnityEngine;

namespace Game.Code.Infrastructure
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelType levelType;
        [SerializeField] private List<SpriteRenderer> darkSide;
        
        private SpriteRendererFade _sceneFade;
        
        private void Awake()
        {
            _sceneFade = Game.Instance.SpriteRendererFade;
            _sceneFade.Init(darkSide);
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