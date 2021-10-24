using System.Linq;
using UnityEngine;

namespace Entities
{
    [ExecuteInEditMode]
    public class GateRenderController : MonoBehaviour
    {
        public RenderState renderState = RenderState.Closed;
        public GameObject openGate;
        public GameObject closedGate;

        public AudioClip openSound;
        public AudioClip closeSound;

        private AudioSource sound;

        public enum RenderState
        {
            Open,
            Closed,
            Hidden
        }
        
        private RenderState lastRenderState = RenderState.Closed;
    
        // Start is called before the first frame update
        private void Start()
        {
            sound = GetComponent<AudioSource>();
            UpdateRender(true);
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateRender();
        }

        private void UpdateRender(bool force = false)
        {
            if (renderState == lastRenderState && !force) return;
            if (renderState != lastRenderState)
            {
                sound.clip = lastRenderState == RenderState.Hidden ? null : renderState switch
                {
                    RenderState.Closed => closeSound,
                    RenderState.Open => openSound,
                    _ => null
                };
                sound.Play();
            }
            closedGate.SetActive(renderState == RenderState.Closed);
            openGate.SetActive(renderState == RenderState.Open);
            lastRenderState = renderState;
        }
    }
}
