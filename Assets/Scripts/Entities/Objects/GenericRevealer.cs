using System;
using UnityEngine;

namespace Entities.Objects
{
    public class GenericRevealer : MonoBehaviour, IRevealable
    {
        public bool startHidden = true;

        private void Awake()
        {
            if(startHidden) gameObject.SetActive(false);
        }

        public void Reveal()
        {
            gameObject.SetActive(true);
        }
    }
}