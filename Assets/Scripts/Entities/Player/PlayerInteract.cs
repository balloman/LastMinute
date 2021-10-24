using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;
using static InputActions.Actions;
using static Tags;

namespace Entities.Player
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField]
        private float interactRange;
    
        private PlayerInput playerInput;
    
        // Start is called before the first frame update
        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            playerInput.actions[GetAction[Interact]].performed += PerformInteract;
        }

        private void PerformInteract(InputAction.CallbackContext context)
        {
            NearbyInteractables
                .ToList()
                .ForEach(go => go.GetComponentsInChildren<IInteractable>()
                    .ToList()
                    .ForEach(interactable => interactable.Interact(gameObject)));
        }

        private IEnumerable<GameObject> NearbyInteractables => GameObject
            .FindGameObjectsWithTag(GetTag[Tag.Interactable])
            .Where(o => Vector2.Distance(transform.position, o.transform.position) < interactRange);
    }
}
