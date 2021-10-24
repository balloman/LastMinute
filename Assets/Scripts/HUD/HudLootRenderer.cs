using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HUD
{
    public class HudLootRenderer : MonoBehaviour
    {
        public Sprite[] lootSprites;
        public GameObject inventoryView;

        private bool attached = false;
        private GameObject imageClone;
        private readonly LinkedList<GameObject> createdObjects = new LinkedList<GameObject>();

        private void Awake()
        {
            attached = inventoryView != null;
            imageClone = GetComponentInChildren<Image>().gameObject;
        }

        public void SetSprites(IEnumerable<Sprite> sprites)
        {
            if (!attached) return;
            foreach (var obj in createdObjects)
            {
                Destroy(obj);
            }
            foreach (var sprite in sprites)
            {
                var obj = GameObject.Instantiate(imageClone, inventoryView.transform);
                var img = obj.GetComponent<Image>();
                img.sprite = sprite;
                img.color = Color.white;
                img.SetNativeSize();
                
                createdObjects.AddLast(obj);
            }
        }
    }
}
