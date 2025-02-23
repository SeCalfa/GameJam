using UnityEngine;
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
        [SerializeField] private Image interactionTip; // Add reference to the interaction tip image

        public void FillBrainBar(float hp)
        {
            brainBar.fillAmount = hp / 100f;
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

        // Method to activate the interaction tip image
        public void ShowInteractionTip(bool show)
        {
            if (interactionTip != null)
            {
                interactionTip.gameObject.SetActive(show);
            }
        }
    }
}
