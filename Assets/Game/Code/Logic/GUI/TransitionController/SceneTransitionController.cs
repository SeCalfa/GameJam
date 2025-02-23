using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Logic.GUI.TransitionController
{
    public class SceneTransitionController : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        
        public float FadeTime = 0.5f;
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            
            DontDestroyOnLoad(gameObject);
        }

        public void StartSceneTransition(int sceneIndex) => 
            StartCoroutine(FadeAndLoadScene(sceneIndex));

        public void StartSceneTransition(string sceneName) => 
            StartCoroutine(FadeAndLoadScene(sceneName));

        private IEnumerator FadeAndLoadScene(int sceneIndex)
        {
            // Затемнение, вкл занавес
            yield return StartCoroutine(Fade(1f));

            // Загрузка сцены асинхронно
            yield return StartCoroutine(LoadSceneAsync(sceneIndex));

            // Обратный фейд
            yield return StartCoroutine(Fade(0f));
        }

        private IEnumerator FadeAndLoadScene(string sceneName)
        {
            yield return StartCoroutine(Fade(1f));
            yield return StartCoroutine(LoadSceneAsync(sceneName));
            yield return StartCoroutine(Fade(0f));
        }

        private IEnumerator LoadSceneAsync(int sceneIndex)
        {
            AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneIndex);
            asyncOp.allowSceneActivation = false;

            while (!asyncOp.isDone)
            {
                // Когда прогресс достиг 0.9f, то сцена готова к активации
                if (asyncOp.progress >= 0.9f)
                {
                    asyncOp.allowSceneActivation = true;
                }
                yield return null;
            }
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName);
            
            if (asyncOp != null)
            {
                asyncOp.allowSceneActivation = false;

                while (!asyncOp.isDone)
                {
                    if (asyncOp.progress >= 0.9f)
                    {
                        asyncOp.allowSceneActivation = true;
                    }

                    yield return null;
                }
            }
        }

        private IEnumerator Fade(float targetAlpha)
        {
            float startAlpha = _canvasGroup.alpha;
            float time = 0f;
            
            if (targetAlpha > 0.5f)
            {
                _canvasGroup.blocksRaycasts = true;
                _canvasGroup.interactable = true;
            }

            while (!Mathf.Approximately(_canvasGroup.alpha, targetAlpha))
            {
                time += Time.deltaTime / FadeTime;
                _canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time);
                yield return null;
            }
            
            if (Mathf.Approximately(targetAlpha, 0f))
            {
                _canvasGroup.blocksRaycasts = false;
                _canvasGroup.interactable = false;
            }
        }
    }
}