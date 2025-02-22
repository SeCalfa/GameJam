using System.Collections;
using UnityEngine;
using Game.Code.Infrastructure.GameObjectsLocator;
using GameClass = Game.Code.Infrastructure.Game; // Alias for Game class

public class Bubble : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    private static readonly int Pop = Animator.StringToHash("Pop");
    private static readonly int Appear = Animator.StringToHash("Appear");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();

        // Register the bubble in the game container
        GameClass.Instance.Container.RegisterGameObject(gameObject.name, gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PopBubble());
        }
    }

    private IEnumerator PopBubble()
    {
        // Trigger the pop animation
        _animator.SetTrigger(Pop);

        // Wait for the pop animation to finish
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        // Hide the bubble
        _spriteRenderer.enabled = false;
        _collider.enabled = false;

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Show the bubble again
        _spriteRenderer.enabled = true;
        _collider.enabled = true;

        // Trigger the appear animation
        _animator.SetTrigger(Appear);
    }

}

