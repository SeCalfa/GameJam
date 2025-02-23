using UnityEngine;
// For Constants
using GameClass = Game.Code.Infrastructure.Game; // Alias for Game class
using Game.Code.Logic.GUI; // For Hud class

namespace Game.Code.Logic.ObjectsInteraction
{
    public class TriggerObjectInteraction : MonoBehaviour
    {
        [SerializeField] private Animator animator; // Reference to the Animator component

        private bool isPlayerNearby = false;
        private Hud hud;

        private void Start()
        {
            //// Ensure the HUD is created
            //if (!GameClass.Instance.Container.Contains(Constants.HudName))
            //{
            //    GameClass.Instance.CreateHud();
            //}

            // Get the HUD component from the Game instance
            hud = GameClass.Instance.Hud;
            if (hud != null)
            {
                hud.ShowInteractionTip(false);
            }
        }

        private void Update()
        {
            if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
            {
                // Trigger the disappearing animation
                if (animator != null)
                {
                    animator.SetTrigger("Disappear");
                }
            }
        }

        // When player is nearby
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Constants.PlayerName))
            {
                isPlayerNearby = true;
                if (hud != null)
                {
                    hud.ShowInteractionTip(true);
                }
            }
        }

        // When player leaves the area
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Constants.PlayerName))
            {
                isPlayerNearby = false;
                if (hud != null)
                {
                    hud.ShowInteractionTip(false);
                }
            }
        }

        // Method to destroy the game object
        private void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}
