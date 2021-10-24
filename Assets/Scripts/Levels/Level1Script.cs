using System;
using Entities;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.XInput;

namespace Levels
{
    public class Level1Script : MonoBehaviour
    {
        private PlateBehavior Plate { get; set; }
        [field: SerializeField]
        private GameObject CombinedPlayer { get; set; }
        [field: SerializeField]
        private GameObject Wisp { get; set; }
        [field: SerializeField]
        private GameObject Player { get; set; }
        [field: SerializeField]
        private Light2D Light { get; set; }
        [field: SerializeField]
        private float Darkness { get; set; }

        public event EventHandler<BigBangArgs> TheBigBang; 

        // Start is called before the first frame update
        private void Start()
        {
            Plate = GameObject.FindObjectOfType<PlateBehavior>();
            Plate.Interacted += BigBang;
            CombinedPlayer = GameObject.FindWithTag(Tags.GetTag[Tags.Tag.Body]);
        }

        
        private void BigBang(object sender, PlateBehavior.PlateEventArgs e)
        {
            Plate.Interacted -= BigBang;
            if (!e.Depressed) return;
            GameObject.Destroy(CombinedPlayer);
            var wisp = GameObject.Instantiate(Wisp);
            wisp.transform.position = Plate.transform.position;
            GameObject player;
            if (Gamepad.all.Count < 1)
            {
                player = GameObject.Instantiate(Player);
                player.GetComponent<PlayerInput>().SwitchCurrentControlScheme("Keyboard", Keyboard.current);
                player.gameObject.transform.position = Plate.transform.position;
            } else
            {
                player = GameObject.Instantiate(Player);
                player.GetComponent<PlayerInput>().SwitchCurrentControlScheme("Controller", Gamepad.current);
                player.gameObject.transform.position = Plate.transform.position;

            }
            Light.intensity = Darkness;
            TheBigBang?.Invoke(this, new BigBangArgs{Wisp = wisp, Body = player});
        }

        public class BigBangArgs : EventArgs
        {
            /// <summary>
            /// The Wisp
            /// </summary>
            public GameObject Wisp { get; set; }
            /// <summary>The Body/player</summary>
            public GameObject Body { get; set; }
        }
    }
}
