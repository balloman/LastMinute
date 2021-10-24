using UnityEngine.InputSystem;
using static InputActions;

namespace Entities.Player
{
    public class PlayerAttackHandler : AttackHandler
    {
        private PlayerInput playerInput;
    
        // Start is called before the first frame update
        private void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            playerInput.currentActionMap[GetAction[Actions.Attack]].performed += Attack;
        }
    }
}
