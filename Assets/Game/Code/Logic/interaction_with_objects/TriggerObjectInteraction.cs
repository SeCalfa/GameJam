using UnityEngine;
using UnityEngine.UI;
using Game.Code;
using Game.Code.Infrastructure;
using Game.Code.Infrastructure.GameObjectsLocator;

public class TriggerObjectInteraction : MonoBehaviour
{
    [SerializeField] private string interactButton = "E";
    [SerializeField] private Text interactPrompt;
    [SerializeField] private string promptMessage = "Press E to interact";

    private bool isPlayerNearby = false;

    private void Start()
    {
        if (interactPrompt != null)
        {
            interactPrompt.gameObject.SetActive(false);
        }
    }
    // during frames updates
    private void Update()
    {
        if (isPlayerNearby && Input.GetButtonDown(interactButton))
        {
            if (!Game.Instance.Container.Contains(Constants.HudName))
            {
                Game.Instance.Container.RegisterGameObject(Constants.HudName, Constants.HudPath);
            }

            var hud = Game.Instance.Container.GetGameObjectByName<GameObject>(Constants.HudName);
            hud.SetActive(true);
        }
    }
    // when player is nearby
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactPrompt != null)
            { // dont forget to add action after interaction ( minigame or item obtaining)

                interactPrompt.text = promptMessage;
                interactPrompt.gameObject.SetActive(true);
            }
        }
    }
    // when player is not nearby
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactPrompt != null)
            {
                interactPrompt.gameObject.SetActive(false);
            }
            if (Game.Instance.Container.Contains(Constants.HudName))
            {
                var hud = Game.Instance.Container.GetGameObjectByName<GameObject>(Constants.HudName);
                hud.SetActive(false);
                Game.Instance.Container.RemoveGameObject(Constants.HudName);//removing object to prevent memory leak
            }
        }
    }
}
