using System;
using UnityEngine;
using static Utils.Utils;
using static Tags.Tag;
using static Tags;

namespace Levels
{
    public class Room2Script : MonoBehaviour
    {

        private void Start()
        {
            SetControls(GameObject.FindWithTag(GetTag[Wisp]), GameObject.FindWithTag(GetTag[Body]));
        }
    }
}
