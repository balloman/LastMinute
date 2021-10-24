using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Objects;
using UnityEngine;
using UnityEngine.Serialization;
using static Tags.Tag;
using static Tags;

namespace Entities
{
    public class PlateBehavior : MonoBehaviour
    {
        [FormerlySerializedAs("sprites")] [SerializeField]
        private Sprite[] Sprites;

        private ActivatableBehavior activatableBehavior;

        public AudioClip pressClip;
        public AudioClip unpressClip;

        [Serializable]
        public struct Picker
        {
            public Tag Trigger;
            public bool Active;
        }

        public Picker[] pickers;
        //public EntityTrigger trigger = EntityTrigger.Both;
        
        public event EventHandler<PlateEventArgs> Interacted;

        private void Awake()
        {
            var r = GetComponent<SpriteRenderer>();
            var s = GetComponent<AudioSource>();
            activatableBehavior = GetComponent<ActivatableBehavior>();
            Interacted += (_, args) =>
            {
                r.sprite = Sprites[args.Depressed ? 1 : 0];
                r.flipY = args.Depressed;
                s.clip = args.Depressed ? pressClip : unpressClip;
                s.Play();
            };
        }

        private bool CanTrigger(Collider2D other)
        {
            var tag = other.tag;
            return Enum.TryParse<Tag>(tag, false, out var e) && 
                pickers.Any(p => p.Active && p.Trigger == e);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!CanTrigger(other)) return;
            activatableBehavior.IsActive = true;
            Interacted?.Invoke(this, new PlateEventArgs{Depressed = true, Other = other});
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!CanTrigger(other)) return;
            var otherObject = other.gameObject;
            if (!otherObject.CompareTag(Tags.GetTag[Body])) return;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!CanTrigger(other)) return;
            activatableBehavior.IsActive = false;
            Interacted?.Invoke(this, new PlateEventArgs{Depressed = false, Other = other});
        }

        public class PlateEventArgs : EventArgs
        {
            /// <summary>
            /// Whether the plate is depressed or not
            /// </summary>
            public bool Depressed { get; set; }
            /// <summary>
            /// What it's being Depressed by
            /// </summary>
            public Collider2D Other { get; set; }
        }
    }
}
