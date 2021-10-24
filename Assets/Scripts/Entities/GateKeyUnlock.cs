using System;
using Entities.Player;
using UnityEngine;

namespace Entities
{
    public class GateKeyUnlock : MonoBehaviour, IInteractable
    {
        private GateLockController lockController;

        private void Awake()
        {
            lockController = GetComponent<GateLockController>();
        }

        public void Interact(GameObject interactor)
        {
            var inventory = interactor.GetComponent<InventoryBehavior>();
            var key = inventory.GetLootByName("Key");
            if (key is null) return;
            inventory.RemoveLoot(key);
            lockController.Unlock();
        }
    }
}