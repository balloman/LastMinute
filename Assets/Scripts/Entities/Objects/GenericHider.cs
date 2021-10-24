using UnityEngine;

namespace Entities.Objects
{
    public class GenericHider : MonoBehaviour, IRevealable
    {
        public void Reveal()
        {
            gameObject.SetActive(false);
        }
    }
}