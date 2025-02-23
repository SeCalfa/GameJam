using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Logic.Intro
{
    public class IntroAnimation : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _foreground;
        [SerializeField] private SpriteRenderer _background;
        [Space]
        [SerializeField] private List<Sprite> animator;
        
        private void Awake()
        {
            StartCoroutine(StartAnimation());
        }
        
        private IEnumerator StartAnimation()
        {
            for (int i = 0; i < animator.Count - 1; i++)
            {
                var alpha = 1f;
                _foreground.sprite = animator[i];
                _background.sprite = animator[i + 1];
                
                while (alpha >= 0)
                {
                    alpha -= 0.05f;
                    _foreground.color = new Color(1, 1, 1, alpha);

                    yield return new WaitForSeconds(0.01f);
                }
            }
            
            Infrastructure.Game.Instance.Curtain.Show(() =>
            {
                SceneManager.LoadScene("Map1");
            });
        }
    }
}
