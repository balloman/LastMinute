using System.Linq;
using Entities;
using Entities.Player;
using Levels;
using UnityEngine;
using static Tags;

namespace HUD
{
    public class HudController : MonoBehaviour
    {
        private GameObject player;

        private InventoryBehavior playerData;
        private HealthHandler playerHealth;
        private HudLootRenderer lootRenderer;
        private HudHealthRenderer healthRenderer;

        // Start is called before the first frame update
        private void Start()
        {
            lootRenderer = GetComponent<HudLootRenderer>();
            healthRenderer = GetComponent<HudHealthRenderer>();
            
            BindToPlayer(GameObject.FindGameObjectWithTag(GetTag[Tag.Body]));

            var level1Script = GameObject.FindObjectOfType<Level1Script>();
            if (level1Script == null) return;
            level1Script.TheBigBang += (_, args) =>
            {
                BindToPlayer(GameObject.FindGameObjectWithTag(GetTag[Tag.Body]));
            };
        }

        public void BindToPlayer(GameObject newPlayer)
        {
            player = newPlayer;
            playerData = player.GetComponent<InventoryBehavior>();
            playerHealth = player.GetComponent<HealthHandler>();
            playerData.LootModified += (_, args) => 
                lootRenderer.SetSprites(playerData.Sprites);
            lootRenderer.SetSprites(playerData.Sprites);
            playerHealth.HealthUpdated += (_, args) =>
                healthRenderer.UpdateHealth(playerHealth.CurrentHealth);
            healthRenderer.UpdateHealth(playerHealth.CurrentHealth);
        }
    }
}
