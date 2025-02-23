using UnityEngine;
// For Constants
using GameClass = Game.Code.Infrastructure.Game; // Alias for Game class
using Game.Code.Logic.GUI; // For Hud class
using Game.Code.Infrastructure; // For LevelManager and LevelType

namespace Game.Code.Logic.ObjectsInteraction
{
    public class TriggerObjectInteraction : MonoBehaviour
    {
        [SerializeField] private Animator animator; // Reference to the Animator component
        [SerializeField] private bool isRuneHere;   // Boolean to indicate if a rune is present

        private bool isPlayerNearby = false;
        private Hud hud;

        private void Start()
        {
            // Get the HUD component from the Game instance
            hud = GameClass.Instance.Hud;
            if (hud != null)
            {
                hud.ShowInteractionTip(false);
            }
            // Removed code that overwrites isRuneHere
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

                // Gain the rune if it is present
                if (isRuneHere && hud != null)
                {
                    LevelType currentLevel = LevelManager.Instance.GetLevelType;
                    if (currentLevel == LevelType.Map1)
                    {
                        hud.TakeRune1();
                    }
                    else if (currentLevel == LevelType.Map2)
                    {
                        hud.TakeRune2();
                    }
                    else if (currentLevel == LevelType.Map3)
                    {
                        hud.TakeRune3();
                    }
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
