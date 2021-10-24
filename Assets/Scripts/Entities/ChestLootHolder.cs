using ScriptableObjects;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Entities
{
    public class ChestLootHolder : MonoBehaviour
    {
        public LootScriptable loot;
        
        public GameObject lootSprite;

        public float animCycles = 1;
        public float animSpeed = 1;
        public float amplitude = 1;

        public AudioSource sound;
        
        private float animationTime;
        private bool animating;

        private float yInitial;
        private GameObject player;
        
        public void GrantLoot(GameObject targetPlayer)
        {
            if (loot == null) return;
            player = targetPlayer;
            StartAnimation();
        }

        private void StartAnimation()
        {
            lootSprite.GetComponent<SpriteRenderer>().sprite = loot.icon;
            yInitial = lootSprite.transform.localPosition.y;
            animationTime = 0;
            animating = true;
            lootSprite.transform.localScale = Vector3.one * loot.scale;
        }

        private void StopAnimation()
        {
            lootSprite.GetComponent<SpriteRenderer>().sprite = null;
            lootSprite.transform.localPosition = Vector3.up * yInitial;
            animating = false;
            lootSprite.transform.localScale = Vector3.one;
        }

        private void Update()
        {
            if (!animating) return;
            animationTime += Time.deltaTime * animSpeed;
            if (animationTime > animCycles)
            {
                StopAnimation();
                loot.GiveToPlayer(player);
                if(loot.sound != null)
                {
                    sound.clip = loot.sound;
                    sound.Play();
                }
                return;
            }

            lootSprite.transform.localPosition =
                Vector3.up * (yInitial + amplitude * (1 + -Mathf.Cos(2 * Mathf.PI * animationTime)));
        }
    }
}
