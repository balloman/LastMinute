using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class HudHealthRenderer : MonoBehaviour
    {
        public Sprite healthSprite;
        public GameObject healthView;
        
        private bool attached;
        private GameObject imageClone;
        private readonly LinkedList<GameObject> createdObjects = new LinkedList<GameObject>();

        private void Awake()
        {
            attached = healthView != null;
            imageClone = GetComponentInChildren<Image>().gameObject;
        }

        public void UpdateHealth(int count)
        {
            if (!attached) return;
            foreach (var obj in createdObjects)
            {
                Destroy(obj);
            }

            for (var i = 0; i < count; i++) 
            {
                var obj = GameObject.Instantiate(imageClone, healthView.transform);
                var img = obj.GetComponent<Image>();
                img.sprite = healthSprite;
                img.color = Color.white;
                img.SetNativeSize();
                
                createdObjects.AddLast(obj);
            }
        }
    }
}