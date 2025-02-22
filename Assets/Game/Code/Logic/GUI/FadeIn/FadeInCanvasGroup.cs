using System.Collections;
using UnityEngine;

namespace Game.Code.Logic.GUI.FadeIn
{
    public class FadeInCanvasGroup : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Awake() => 
            _canvasGroup = GetComponent<CanvasGroup>();

        private void Start()
        {
            Hide();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("I Pressed, Hide");
                Show();
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                Debug.Log("O Pressed, Show");
            }
        }

        public void Hide() => 
            StartCoroutine(FadeIn());

        public void Show() =>
            StartCoroutine(FadeOut());

        private IEnumerator FadeIn()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= 0.01f;
                
                yield return new WaitForSeconds(0.01f);
            }
            
            _canvasGroup.alpha = 0;
        }

        private IEnumerator FadeOut()
        {
            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += 0.01f;
                
                yield return new WaitForSeconds(0.01f);
            }
            
            _canvasGroup.alpha = 1;
        }
    }
}