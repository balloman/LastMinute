using UnityEngine;

namespace Entities
{
    public abstract class ChestLoot : MonoBehaviour
    {
        public Sprite sprite;
        public float scale;
        public abstract void GiveToPlayer(GameObject player);
    }
}
