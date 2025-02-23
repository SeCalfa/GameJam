using UnityEngine;

namespace Game.Code.Logic.Enemies
{
    public class BombFish : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _animator.SetTrigger("Explosion");
                Infrastructure.Game.Instance.Hud.TakeDamage(20);
                
                Destroy(GetComponent<CircleCollider2D>());
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
