using System;
using Entities.Player;
using UnityEditor.VersionControl;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Loot", order = 0)]
    public class LootScriptable : ScriptableObject
    {
        public enum BehaviorType
        {
            Key
        }
        
        public Sprite icon;
        public int scale;
        public BehaviorType behavior;
        public string lootName;
		public AudioClip sound;

        public void GiveToPlayer(GameObject player)
        {
            switch (behavior)
            {
                case BehaviorType.Key:
                    player.GetComponent<InventoryBehavior>().AddLoot(this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}