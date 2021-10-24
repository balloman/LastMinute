using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.XR;
using InputDevice = UnityEngine.XR.InputDevice;

namespace Utils
{
    public static class Utils
    {
        public static void SetControls(GameObject wisp, GameObject body)
        {
            var wispInput = wisp.GetComponent<PlayerInput>();
            var bodyInput = body.GetComponent<PlayerInput>();
            ReadOnlyArray<Gamepad> gamePads = Gamepad.all;
            var j = new List<InputDevice>();
            InputDevices.GetDevices(j);
            switch (gamePads.Count)
            {
                case 0:
                    bodyInput.SwitchCurrentControlScheme("Keyboard", Keyboard.current);
                    break;
                case 1:
                    wispInput.SwitchCurrentControlScheme("Controller", gamePads[0]);
                    bodyInput.SwitchCurrentControlScheme("Keyboard", Keyboard.current);
                    break;
                default:
                    wispInput.SwitchCurrentControlScheme("Controller", gamePads[gamePads.Count - 2]);
                    bodyInput.SwitchCurrentControlScheme("Controller", gamePads[gamePads.Count - 1]);
                    break;
            }
        }
    }
}