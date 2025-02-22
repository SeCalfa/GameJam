using UnityEngine;

namespace Game.Code.Logic.Character
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private const float MovementSpeed = 1f;

        private float _horizontal, _vertical;
        private Vector2 _currentVelocity = Vector2.zero;
        private Vector2 _velocitySmooth;
        private float _currentAngularVelocity;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            
            LookAtMovement();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            var input = new Vector2(_horizontal, _vertical);
            var targetVelocity = input.normalized * MovementSpeed;
            
            _currentVelocity = Vector2.SmoothDamp(_currentVelocity, targetVelocity, ref _velocitySmooth, 0.5f);
            
            _rb.velocity = _currentVelocity;
        }

        private void LookAtMovement()
        {
            var moveDirection = new Vector2(_horizontal, _vertical);

            if (moveDirection.sqrMagnitude > 0.01f)
            {
                var targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
                var smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref _currentAngularVelocity, 0.4f);
                transform.rotation = Quaternion.Euler(0, 0, smoothAngle);
            }
        }
    }
}