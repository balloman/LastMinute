using System;
using UnityEngine;

namespace Entities
{
    public class ChestController : MonoBehaviour, IInteractable
    {

        private ChestStateControl stateControl;

        private void Start()
        {
            stateControl = GetComponent<ChestStateControl>();
        }

        public void Interact(GameObject interactor)
        {
            if (stateControl.State != ChestStateControl.ChestState.Closed) return;
            stateControl.State = ChestStateControl.ChestState.Open;
            GetComponent<ChestLootHolder>().GrantLoot(interactor);
        }
    }
}
