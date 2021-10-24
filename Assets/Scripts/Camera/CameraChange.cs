using Cinemachine;
using Levels;
using UnityEngine;

namespace Camera
{
    public class CameraChange : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var go = GameObject.FindObjectOfType<Level1Script>();
            var cam = GetComponent<CinemachineTargetGroup>();
            go.TheBigBang += (_, args) =>
            {
                cam.AddMember(args.Body.transform, 1, 3);
                cam.AddMember(args.Wisp.transform, 0.5f, 3);
            };
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
