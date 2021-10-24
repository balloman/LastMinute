using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ChestStateControl : MonoBehaviour
    {
        
        public enum ChestState
        {
            Open,
            Closed
        }

        [SerializeField]
        private Sprite openTexture;
        
        [SerializeField]
        private Sprite closeTexture;
        
        [SerializeField]
        private ChestState state = ChestState.Closed;

        public AudioSource sound;
        
        public ChestState State
        {
            get => state;
            set
            {
                if(state != value) sound.Play();
                state = value;
                UpdateSprite();
            }
        }
        
        private readonly Dictionary<ChestState, Sprite> stateTextures = new Dictionary<ChestState, Sprite>();

        private SpriteRenderer spriteRenderer;
    
        // Start is called before the first frame update
        private void Start()
        {
            stateTextures.Add(ChestState.Open, openTexture);
            stateTextures.Add(ChestState.Closed, closeTexture);

            spriteRenderer = GetComponent<SpriteRenderer>();
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            spriteRenderer.sprite = stateTextures[State];
        }
    }
}
