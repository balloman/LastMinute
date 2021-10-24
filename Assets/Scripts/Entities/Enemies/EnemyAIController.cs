using System;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemyAIController : MonoBehaviour
    {

        public enum AITask 
        {
            None,
            Patrol,
            Idle,
            Follow
        }

        // Don't modify this in editor, its only public to make it easy to see
        public AITask task = AITask.None;

        private PatrolBehavior patrolBehavior;
        private FollowBehavior followBehavior;
        private EnemyVision vision;
        private EnemyMovement movement;

        // Start is called before the first frame update
        private void Start()
        {
            patrolBehavior = GetComponent<PatrolBehavior>();
            followBehavior = GetComponent<FollowBehavior>();
            
            vision = GetComponent<EnemyVision>();
            movement = GetComponent<EnemyMovement>();
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateTask();
            TaskTransition();
        }

        private void UpdateTask()
        {
            switch(task) {
                case AITask.Patrol:
                    patrolBehavior.Process();
                    break;
                case AITask.None:
                    break;
                case AITask.Idle:
                    break;
                case AITask.Follow:
                    followBehavior.Process();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TaskTransition()
        {
            var newTask = GetNewTask();
            if(newTask == AITask.None || newTask == task) return; // No change
            task = newTask;

            switch(task) {
                case AITask.Patrol:
                    patrolBehavior.Setup();
                    break;
                case AITask.None:
                    break;
                case AITask.Idle:
                    break;
                case AITask.Follow:
                    followBehavior.Setup();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private AITask GetNewTask()
        {
            // if (vision.CanSeePlayer) return AITask.Follow;
            return task switch
            {
                AITask.None => AITask.Patrol,
                AITask.Patrol => vision.CanSeePlayer ? AITask.Follow : AITask.None,
                AITask.Follow => vision.CanSeePlayer || !movement.DoneMoving ? AITask.None : AITask.Patrol,
                _ => AITask.None
            };
        }
    }
}