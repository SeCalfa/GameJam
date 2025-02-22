using UnityEngine;

namespace Game.Code.Logic.Character
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rb;
        
        private float _horizontal, _vertical;
        private Vector2 test;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            var input = new Vector2(_horizontal, _vertical);
            // var movement = _rb.position + input * (Time.fixedDeltaTime * 3f);
            var movement = Vector2.SmoothDamp(
                _rb.position,
                _rb.position + input * (Time.fixedDeltaTime * 8f),
                ref test,
                0.05f);
            
            _rb.MovePosition(movement);
        }
    }
}