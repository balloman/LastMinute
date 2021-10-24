using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;
using static InputActions.Actions;

namespace Entities.Player
{
    public class TransformMovement : MonoBehaviour
    {
        [SerializeField] protected float maxSpeed;
        protected PlayerInput PlayerInput;
        protected InputAction MoveAction;
        protected MovementAnimation MovementAnimation;
        protected Rigidbody2D Rb;
        protected bool IsAnimated = false;
        protected bool IsRigidbody = false;

        public Vector2 MovementVector { get; set; }
    
        protected void Awake()
        {
            PlayerInput = GetComponent<PlayerInput>();
            MovementAnimation = GetComponent<MovementAnimation>();
            Rb = GetComponent<Rigidbody2D>();
            IsAnimated = MovementAnimation != null;
            IsRigidbody = Rb != null;
            MoveAction = PlayerInput.currentActionMap[GetAction[Movement]];
        }

        private void Update()
        {
            MovementVector = MoveAction.ReadValue<Vector2>();
            if (IsAnimated)
            {
                MovementAnimation.Animate(MovementVector);
            }
        }

        protected void FixedUpdate()
        {
            var movement = MoveAction.ReadValue<Vector2>();
            if (IsRigidbody) Rb.MovePosition(transform.position + (Vector3) movement *Time.deltaTime * maxSpeed);
            else transform.Translate(movement * maxSpeed * Time.deltaTime);
        }
    }
}
