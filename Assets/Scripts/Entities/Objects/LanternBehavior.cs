using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Entities.Objects
{
    public class LanternBehavior : MonoBehaviour
    {
        [field: SerializeField]
        public float Intensity { get; set; }
        
        public GameObject[] revealables;
        
        private Light2D Light { get; set; }

        private Animator animator;
        private static readonly int Lit = Animator.StringToHash("Lit");
        private static readonly int Lit1 = Shader.PropertyToID("Lit");

        private void Awake()
        {
            Light = GetComponentInChildren<Light2D>();
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(Tags.GetTag[Tags.Tag.Wisp])) return;
            Light.intensity = Intensity;
            animator.SetBool(Lit,true);
            var a = GetComponent<ActivatableBehavior>();
            if (a != null)
            {
                a.IsActive = true;
            }
            GetComponent<SpriteRenderer>().material.SetInt(Lit1, 1);
            foreach (var revealable in revealables.SelectMany(go => go.GetComponents<IRevealable>()))
            {
                revealable.Reveal();
            }
        }
    }
}
