using UnityEngine;
using TMPro; // For TextMeshPro
using Game.Code; // For Constants
using Game.Code.Infrastructure.GameObjectsLocator;
using GameClass = Game.Code.Infrastructure.Game; // Alias for Game class

public class TriggerObjectInteraction : MonoBehaviour
{
    [SerializeField] private TMP_Text interactPrompt;
    [SerializeField] private string promptMessage = "Press E to interact";

    private bool isPlayerNearby = false;

    private void Start()
    {
        if (interactPrompt != null)
        {
            interactPrompt.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!GameClass.Instance.Container.Contains(Constants.HudName))
            {
                GameClass.Instance.Container.RegisterGameObject(Constants.HudName, Constants.HudPath);
            }

            var hud = GameClass.Instance.Container.GetGameObjectByName<GameObject>(Constants.HudName);
            hud.SetActive(true);
        }
    }

    // When player is nearby
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactPrompt != null)
            {
                interactPrompt.text = promptMessage;
                interactPrompt.gameObject.SetActive(true);
            }
        }
    }

    // When player is not nearby
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactPrompt != null)
            {
                interactPrompt.gameObject.SetActive(false);
            }
            if (GameClass.Instance.Container.Contains(Constants.HudName))
            {
                var hud = GameClass.Instance.Container.GetGameObjectByName<GameObject>(Constants.HudName);
                hud.SetActive(false);
                GameClass.Instance.Container.RemoveGameObject(Constants.HudName); // Removing object to prevent memory leak
            }
        }
    }
}
