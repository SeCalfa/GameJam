using Game.Code.Logic.GUI.FadeIn;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Logic.GUI.Menu
{
    public class MenuManager : MonoBehaviour
    {
        //[SerializeField] private FadeInCanvasGroup fadeInCanvasGroup;
        [SerializeField] private GameObject creditsPopup;

        private void Start()
        {
            creditsPopup.SetActive(false);
        }

        public void OnStartButtonClicked()
        {
            Debug.Log("Start button clicked, switching scene.");
            StartCoroutine(SwitchScene("ExampleScene"));
        }

        public void OnCreditsButtonClicked()
        {
            Debug.Log("Credits button clicked, showing credits popup.");
            creditsPopup.SetActive(true);
        }

        public void OnExitButtonClicked()
        {
            Debug.Log("Exit button clicked, attempting to exit game.");
            StartCoroutine(ExitGame());
        }

        private IEnumerator SwitchScene(string sceneName)
        {
            //yield return fadeInCanvasGroup.FadeOut(); // can't use due to its protection level
            SceneManager.LoadScene(sceneName);
            yield return null; // Ensure all code paths return an IEnumerator
        }

        private IEnumerator ExitGame()
        {
            // yield return fadeInCanvasGroup.FadeOut(); // can't use due to its protection level
            Application.Quit();
            Debug.Log("Exit game called. Note: Application.Quit() does not work in the editor.");
            yield return null; // Ensure all code paths return an IEnumerator
        }
    }
}
