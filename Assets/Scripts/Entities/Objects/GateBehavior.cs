using System;
using System.Linq;
using Entities.Player;
using UnityEngine;

using static Tags.Tag;
using static Tags;

namespace Entities.Objects
{
    public class GateBehavior : MonoBehaviour, IInteractable
    {
        public RenderState renderState = RenderState.Closed;
        public GameObject openGate;
        public GameObject closedGate;
        public AudioClip openSound;
        public ActivatableBehavior[] conditions;
        public bool requireKey = true;
        
        public bool CanBeOpened => conditions.All(c => c.IsActive);
        
        private void Start()
        {
            ChangeGate(renderState);
        }

        public void Interact(GameObject i)
        {
            if (!i.CompareTag(GetTag[Body])) return;
            var inventory = i.GetComponent<InventoryBehavior>();
            if (CanBeOpened) TryUnlock(inventory);
        }

        private void TryUnlock(InventoryBehavior inventory)
        {
            var key = inventory.GetLootByName("Key");
            if (key is null && requireKey) return;
            if (requireKey) inventory.RemoveLoot(key);
            Unlock();
        }

        public void Unlock()
        {
            ChangeGate(RenderState.Open);
            PlaySound();
        }

        private void PlaySound()
        {
            if (openSound == null) return;
            var source = GetComponent<AudioSource>();
            if (source == null) return;
            source.clip = openSound;
            source.Play();
        }

        private void ChangeGate(RenderState state)
        {
            if (state == RenderState.Hidden)
            {
                closedGate.SetActive(false);
                openGate.SetActive(false);
                return;
            }
            var closed = state == RenderState.Closed;
            closedGate.SetActive(closed);
            openGate.SetActive(!closed);
        }
        
        public enum RenderState
        {
            Open,
            Closed,
            Hidden
        }
    }
}