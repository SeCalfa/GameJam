using UnityEngine;
using UnityEngine.SceneManagement;
using Game.Code;
using Game.Code.Logic.GUI.Fade;

namespace Game.Code.Logic.GUI.Menu
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject creditsCanvas;
       
        public void OnStartButtonClicked()
        {
            //Debug.Log("Start button clicked, switching scene.");
            Infrastructure.Game.Instance.Curtain.Show(() => SceneManager.LoadSceneAsync(LevelType.Intro.ToString()));
        }

        public void OnCreditsButtonClicked()
        {
            //Debug.Log("Credits button clicked, showing credits popup.");
            creditsCanvas.SetActive(true);
        }

        public void OnExitButtonClicked()
        {
            //Debug.Log("Exit button clicked, attempting to exit game.");
            Application.Quit();
        }

        public void OnHideCreditsButtonClicked()
        {
            creditsCanvas.SetActive(false);
        }

        private void Update()
        {
            if (creditsCanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                OnHideCreditsButtonClicked();
            }
        }
    }
}
