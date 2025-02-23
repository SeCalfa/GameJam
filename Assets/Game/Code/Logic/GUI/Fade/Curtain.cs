using System;
using System.Collections;
using UnityEngine;

namespace Game.Code.Logic.GUI.Fade
{
    public class Curtain : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        private Coroutine _coroutine;
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show(Action onFinish = null)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);
            
            _coroutine = StartCoroutine(ShowCoroutine(onFinish));
        }

        public void Hide(Action onFinish = null)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);
            
            _coroutine = StartCoroutine(HideCoroutine(onFinish));
        }

        private IEnumerator ShowCoroutine(Action onFinish)
        {
            float alpha = 0;
            _canvasGroup.alpha = alpha;
            
            while (_canvasGroup.alpha < 1)
            {
                alpha += 0.02f;
                _canvasGroup.alpha = alpha;
                
                yield return new WaitForSeconds(0.01f);
            }

            onFinish?.Invoke();
        }
        
        private IEnumerator HideCoroutine(Action onFinish)
        {
            float alpha = 1;
            _canvasGroup.alpha = alpha;
            
            while (_canvasGroup.alpha > 0)
            {
                alpha -= 0.02f;
                _canvasGroup.alpha = alpha;
                
                yield return new WaitForSeconds(0.01f);
            }

            onFinish?.Invoke();
        }
    }
}