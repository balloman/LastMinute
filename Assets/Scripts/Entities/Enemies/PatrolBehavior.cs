using UnityEngine;

namespace Entities.Enemies
{
    public class PatrolBehavior : AIBehavior
    {

        public Vector2[] patrolPoints;
        public float holdTime;

        private int patrolIndex = 0;
        private EnemyMovement movement;
        private float heldTime = 0;

        private void Start()
        {
            movement = GetComponent<EnemyMovement>();
        }

        public override void Setup()
        {
            movement.MoveTo(patrolPoints[patrolIndex]);
        }

        public override void Process()
        {
            if (!movement.DoneMoving) return;
            heldTime += Time.deltaTime;
            var nextPatrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            if(heldTime < holdTime) return;
            heldTime = 0;
            patrolIndex = nextPatrolIndex;
            movement.MoveTo(patrolPoints[patrolIndex]);
        }
    }
}
