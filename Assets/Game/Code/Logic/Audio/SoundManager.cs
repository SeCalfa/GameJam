using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Logic.Audio
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;

        [System.Serializable]
        public struct SceneMusicData
        {
            public string SceneName;
            public AudioClip Clip;
        }

        [SerializeField] private SceneMusicData[] _sceneMusics;

        private void Awake()
        {
            if (FindObjectsOfType<SoundManager>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;

            var activeScene = SceneManager.GetActiveScene();
            PlayMusicForScene(activeScene.name);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            PlayMusicForScene(scene.name);
            Debug.Log($"New music");
        }

        private void PlayMusicForScene(string sceneName)
        {
            foreach (var data in _sceneMusics)
            {
                if (data.SceneName == sceneName)
                {
                    _musicSource.Stop();
                    Debug.Log($"Music stopped");
                    _musicSource.clip = data.Clip;
                    if (data.Clip != null)
                    {
                        _musicSource.Play();
                    }

                    return;
                }
            }
        }
    }
}