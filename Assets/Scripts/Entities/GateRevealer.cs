using System;
using UnityEngine;

namespace Entities
{
    public class GateRevealer : MonoBehaviour, IRevealable
    {
        /// <summary>
        /// Not sure when this would ever be false, but its here just in case
        /// </summary>
        public bool startHidden = true;

        public bool unlockDoor = true;

        public GateRenderController.RenderState revealState = GateRenderController.RenderState.Closed;
        
        private GateRenderController renderController;
        private GateLockController lockController;
        
        private void Awake()
        {
            renderController = GetComponent<GateRenderController>();
            lockController = GetComponent<GateLockController>();

            if (startHidden) renderController.renderState = GateRenderController.RenderState.Hidden;
        }

        public void Reveal()
        {
            if (renderController.renderState == GateRenderController.RenderState.Hidden)
            {
                renderController.renderState = revealState;
            }

            if (unlockDoor) lockController.Locked = false;
        }
    }
}