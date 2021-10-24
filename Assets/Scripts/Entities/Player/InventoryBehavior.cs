using System;
using System.Collections.Generic;
using System.Linq;
using HUD;
using JetBrains.Annotations;
using ScriptableObjects;
using UnityEngine;

namespace Entities.Player
{
    public class InventoryBehavior : MonoBehaviour
    {
        private List<LootScriptable> Inventory { get; set; } = new List<LootScriptable>();
        private HudLootRenderer ui;

        public event EventHandler LootModified;

        public IEnumerable<Sprite> Sprites => Inventory.Select(scriptable => scriptable.icon);

        private void Start()
        {
            ui = GameObject.FindObjectOfType<HudLootRenderer>();
        }

        public void AddLoot(LootScriptable loot)
        {
            Inventory.Add(loot);
            LootModified?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveLoot(LootScriptable loot)
        {
            Inventory.Remove(loot);
            LootModified?.Invoke(this, EventArgs.Empty);
        }

        [Pure]
        public LootScriptable GetLootByName(string name) => Inventory.FirstOrDefault(scriptable => scriptable.name == name);

    }
}