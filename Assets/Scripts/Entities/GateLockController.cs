using UnityEngine;
using static Entities.GateRenderController.RenderState;

namespace Entities
{
    public class GateLockController : MonoBehaviour, IInteractable
    {
        private bool locked = true;

        public bool Locked
        {
            get => locked;
            set
            {
                locked = value;
                if (openWhenUnlocked && !locked) renderController.renderState = Open;
            }
        }
        
        public bool openWhenUnlocked = true;

        private GateRenderController renderController;

        private void Start()
        {
            renderController = GetComponent<GateRenderController>();
        }
    
        public void Interact(GameObject interactor)
        {
            if (!locked && renderController.renderState != Hidden) 
                renderController.renderState = renderController.renderState == Closed ? Open : Closed;
        }

        public void Unlock()
        {
            locked = false;
            if (!locked && renderController.renderState != Hidden) 
                renderController.renderState = renderController.renderState == Closed ? Open : Closed;
        }
    }
}
