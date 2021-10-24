using UnityEngine;

namespace Entities.Enemies
{
    public class FollowBehavior : AIBehavior
    {
        private EnemyVision vision;
        private EnemyMovement movement;

        private void Start()
        {
            vision = GetComponent<EnemyVision>();
            movement = GetComponent<EnemyMovement>();
        }
        
        public override void Setup()
        {
        }

        public override void Process()
        {
            var visiblePlayer = vision.VisiblePlayer;
            if (visiblePlayer == null) return;
            movement.MoveTo(visiblePlayer.transform.position);
        }
    }
}
