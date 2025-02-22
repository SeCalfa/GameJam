using System.Collections;
using UnityEngine;

namespace Game.Code.Logic.GUI.FadeIn
{
    public class FadeInRenderer : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        
        private void Awake() => 
            _spriteRenderer = GetComponent<SpriteRenderer>();

        private void Show()
        {
            _spriteRenderer.enabled = true;
            _spriteRenderer.color = new Color(1, 1, 1, 0);
        }

        private void Hide() => 
            StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {

            while (_spriteRenderer.color.a >= 0)
            {
                float alpha = _spriteRenderer.color.a - 0.01f;
                
                _spriteRenderer.color = new Color(1, 1, 1, alpha);

                yield return new WaitForSeconds(0.01f);
            }
            
            gameObject.SetActive(false);
        }
    }
}