using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Logic.GUI.Fade
{
    public class SpriteRendererFade : MonoBehaviour
    {
        private List<SpriteRenderer> _spriteRenderer;

        private float _alpha;
        private Coroutine _coroutine;

        public void Init(List<SpriteRenderer> spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }

        public void Show(Action onHide = null)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            
            _coroutine = StartCoroutine(FadeIn(onHide));
        }

        public void Hide(Action onHide = null)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            
            _coroutine = StartCoroutine(FadeOut(onHide));
        }

        private IEnumerator FadeIn(Action onHide)
        {
            _alpha = 0;
            
            while (_alpha <= 1)
            {
                _alpha += 0.04f;
                
                foreach (var sr in _spriteRenderer)
                {
                    sr.color = new Color(1, 1, 1, _alpha);
                }
                
                yield return new WaitForSeconds(0.01f);
            }
            
            onHide?.Invoke();
        }

        private IEnumerator FadeOut(Action onHide)
        {
            _alpha = 1;
            
            while (_alpha >= 0)
            {
                _alpha -= 0.04f;
                
                foreach (var sr in _spriteRenderer)
                {
                    sr.color = new Color(1, 1, 1, _alpha);
                }
                
                yield return new WaitForSeconds(0.01f);
            }
            
            onHide?.Invoke();
        }
    }
}