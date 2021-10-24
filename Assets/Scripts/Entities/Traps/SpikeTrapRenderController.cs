using UnityEngine;

namespace Entities.Traps
{
    public class SpikeTrapRenderController : MonoBehaviour
    {
        public Sprite[] spikeTextures;
        public float animWait;

        private SpriteRenderer spriteRenderer;
        private AudioSource sound;
        private bool soundPlayed = false;
    
        private static readonly Color Transparent = new Color(0, 0, 0, 0);

        private float wait = 0;
        private int texture = 0;
    
        public enum SpikeTrapState
        {
            Hidden,
            Standby,
            Triggered
        }

        public SpikeTrapState trapState = SpikeTrapState.Hidden;
    
        // Start is called before the first frame update
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            sound = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        private void Update()
        {
            spriteRenderer.color = trapState == SpikeTrapState.Hidden ? Transparent : Color.white;
            if (trapState == SpikeTrapState.Hidden) return;

            if (trapState == SpikeTrapState.Triggered && !soundPlayed)
            {
                soundPlayed = true;
                sound.Play();
            }

            wait -= Time.deltaTime;
            if (wait < 0) wait = 0;
            if (wait != 0) return;
        
            var textureTarget = trapState switch
            {
                SpikeTrapState.Standby => 0,
                SpikeTrapState.Triggered => spikeTextures.Length - 1,
                _ => -1
            };

            if (textureTarget == -1) return;
            if (texture == textureTarget) return;

            if (textureTarget < texture) texture--;
            if (textureTarget > texture) texture++;

            spriteRenderer.sprite = spikeTextures[texture];

            wait = animWait;
        }
    }
}
