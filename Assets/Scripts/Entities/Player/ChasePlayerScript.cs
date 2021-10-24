using Extensions;
using UnityEngine;

namespace Entities.Player
{
    public class ChasePlayerScript : MonoBehaviour
    {
        [field: SerializeField] 
        public Transform Target { get; set; }

        [SerializeField]
        private float rotationSpeed = 0.75f;
        [SerializeField] 
        private float moveSpeed = 1f;

        private void Update()
        {
            transform.SlowLookAt2D(Target, rotationSpeed);
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
    }
}