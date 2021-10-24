using UnityEngine;

namespace Entities.Enemies
{
    public abstract class AIBehavior : MonoBehaviour
    {
        // Start is called before the first frame update
        public abstract void Setup();

        public abstract void Process();
    }
}
