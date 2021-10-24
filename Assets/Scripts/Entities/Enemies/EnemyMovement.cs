using Extensions;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        public float moveTolerance;
        public float moveSpeed;
        public float rotationSpeed;
        private Vector2 target;

        // Start is called before the first frame update
        private void Start()
        {
            target = transform.position;
        }

        // Update is called once per frame
        private void Update()
        {
            if(DoneMoving) return;
            var direction = target - (Vector2) transform.position;
            direction.Normalize();
            transform.Translate(direction * (Time.deltaTime * moveSpeed));
        }

        private float DistanceToTarget => Vector2.Distance(target, gameObject.transform.position);

        public bool DoneMoving => DistanceToTarget < moveTolerance;

        public void MoveTo(int x, int y) 
        {
            MoveTo(new Vector2(x, y));
        }

        public void MoveTo(Vector2 location) {
            target = location;
        }
    }
}
