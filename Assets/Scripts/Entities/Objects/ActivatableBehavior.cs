using System;
using UnityEngine;

namespace Entities.Objects
{
    public class ActivatableBehavior : MonoBehaviour
    {
        private bool isActive = false;
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = true;
                if (value) Activated?.Invoke(this.gameObject, EventArgs.Empty);
            }
        }
        /// <summary>
        /// When this event is invoked, the sender is always the game object that the behavior is attached to
        /// </summary>
        public event EventHandler Activated;
    }
}