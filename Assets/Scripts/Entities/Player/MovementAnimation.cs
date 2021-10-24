using UnityEngine;

namespace Entities.Player
{
    public class MovementAnimation : MonoBehaviour
    {
        private Animator animator;

        private float directionX = 0.0f;
        private float directionY = 0.0f;
        private bool idle = true;
        private static readonly int moveX = Animator.StringToHash("MoveX");
        private static readonly int moveY = Animator.StringToHash("MoveY");
        private static readonly int speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        internal void Animate(Vector2 movement)
        {
            if (!idle)
            {
                directionX = animator.GetFloat(moveX);
                directionY = animator.GetFloat(moveY);
            }
            animator.SetFloat(moveX, movement.x);
            animator.SetFloat(moveY, movement.y);
            animator.SetFloat(speed, movement.sqrMagnitude);
            if (movement.sqrMagnitude < 0.1)
            {
                idle = true;
                animator.SetFloat(moveX, directionX);
                animator.SetFloat(moveY, directionY);
            }
            else
            {
                idle = false;
            }
        }
    }
}