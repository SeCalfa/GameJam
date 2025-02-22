using System.Collections;
using UnityEngine;

namespace Game.Code.Logic.GUI.FadeIn
{
    public class FadeInCanvasGroup : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Awake() => 
            _canvasGroup = GetComponent<CanvasGroup>();


        private void Show()
        {
            _canvasGroup.alpha = 1;
            gameObject.SetActive(true);
        }
        
        private void Hide() => 
            StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= 0.001f;
                
                yield return new WaitForSeconds(0.01f);
            }
            
            gameObject.SetActive(false);
        }
    }
}