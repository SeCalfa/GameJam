using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Code.Logic.GUI
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private Image brainBar;
        [SerializeField] private Image oxygenBar;
        [Space]
        [SerializeField] private Image rune1;
        [SerializeField] private Image rune2;
        [SerializeField] private Image rune3;
        [Space]
        [SerializeField] private Image interactionTip; 
        
        private float _oxygen = 100;
        private float _brainHp = 100;
        
        public bool DarkSideOn => _brainHp <= 60;

        private void Update()
        {
            OxygenCalculator();
        }

        private void OxygenCalculator()
        {
            _oxygen -= Time.deltaTime / 2;
            Infrastructure.Game.Instance.Hud.FillOxygenBar(_oxygen);
            
            if (_oxygen <= 0)
            {
                LoseGame();
            }
        }

        public void FillBrainBar(float hp)
        {
            brainBar.fillAmount = hp / 100f;
        }
        
        public void TakeDamage(int damage)
        {
            _brainHp -= damage;
            Infrastructure.Game.Instance.Hud.FillBrainBar(_brainHp);

            if (Mathf.Approximately(_brainHp, 60))
            {
                Infrastructure.Game.Instance.SpriteRendererFade.Show();
            }

            if (_brainHp <= 0)
            {
                LoseGame();
            }
        }

        public void FillOxygenBar(float hp)
        {
            oxygenBar.fillAmount = hp / 100f;
        }

        public void TakeRune1()
        {
            rune1.enabled = true;
        }

        public void TakeRune2()
        {
            rune2.enabled = true;
        }

        public void TakeRune3()
        {
            rune3.enabled = true;
        }

        public void ShowInteractionTip(bool show)
        {
            if (interactionTip != null)
            {
                interactionTip.gameObject.SetActive(show);
            }
        }

        public void LoseGame()
        {
            Infrastructure.Game.Instance.Curtain.Show(() =>
            {
                Infrastructure.Game.Instance.ClearGame();
                SceneManager.LoadScene("Intro");
            });
        }
    }
}
