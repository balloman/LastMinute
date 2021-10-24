using System;
using UnityEngine;

namespace Entities.Objects
{
    public class RevealableBehavior : MonoBehaviour
    {
        private bool isRevealed = false;
        public bool IsRevealed
        {
            get => isRevealed;
            set
            {
                isRevealed = true;
                if (value) Revealed?.Invoke(this.gameObject, EventArgs.Empty);
            }
        }
        /// <summary>
        /// When this event is invoked, the sender is always the game object that the behavior is attached to
        /// </summary>
        public event EventHandler Revealed;
    }
}