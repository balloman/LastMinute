using UnityEngine;
using static Tags.Tag;
using static Tags;
using static Utils.Utils;

public class ControlFix : MonoBehaviour
{
    private void Start()
    {
        SetControls(GameObject.FindWithTag(GetTag[Wisp]), GameObject.FindWithTag(GetTag[Body]));
    }
}