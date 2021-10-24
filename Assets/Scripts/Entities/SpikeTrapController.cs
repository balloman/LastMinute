using System;
using Entities.Traps;
using UnityEngine;
using static Tags;

namespace Entities
{
    public class SpikeTrapController : MonoBehaviour, IRevealable
    {
        public int damage = 1;
        
        private SpikeTrapRenderController strc;

        // Start is called before the first frame update
        private void Start()
        {
            strc = GetComponent<SpikeTrapRenderController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(GetTag[Tag.Body])) return;
            strc.trapState = SpikeTrapRenderController.SpikeTrapState.Triggered;

            other.GetComponent<HealthHandler>().CurrentHealth -= damage;
        }

        public void Reveal()
        {
            if (strc.trapState == SpikeTrapRenderController.SpikeTrapState.Hidden)
            {
                strc.trapState = SpikeTrapRenderController.SpikeTrapState.Standby;
            }
        }
    }
}
