using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Logic.Triggers
{
    public class NextLevelTrigger : MonoBehaviour
    {
        [SerializeField] private string nextLevel;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Infrastructure.Game.Instance.Curtain.Show(() => { SceneManager.LoadScene(nextLevel); });
            }
        }
    }
}
