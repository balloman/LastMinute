using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;
using static InputActions.Actions;

namespace Entities.Player
{
    public class TwoPlayerMovement : TransformMovement
    {
        // ReSharper disable once InconsistentNaming
        private InputAction MoveAction2;
        private bool twoController;

        private new void Awake()
        {
            base.Awake();
            PlayerInput.SwitchCurrentActionMap("Two Player");
            MoveAction = PlayerInput.currentActionMap[GetAction[Movement]];
            if (PlayerInput.currentControlScheme == "Controller")
            {
                twoController = true;
            }
            MoveAction2 = PlayerInput.currentActionMap[GetAction[PlayerTwoMovement]];
        }

        private new void FixedUpdate()
        {
            var movement = MoveAction.ReadValue<Vector2>() + MoveAction2.ReadValue<Vector2>();
            if (IsAnimated)
            {
                MovementAnimation.Animate(movement);
            }
            transform.Translate(movement * (maxSpeed * Time.deltaTime));
        }
    
    }
}