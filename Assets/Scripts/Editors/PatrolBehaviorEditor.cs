using Entities.Enemies;
using UnityEditor;
using UnityEngine;

namespace Editors
{
    [CustomEditor(typeof(PatrolBehavior))]
    public class PatrolBehaviorEditor : Editor {

        private void OnSceneGUI() {
            var patrol = (PatrolBehavior) target;

            for(int i = 0; i < patrol.patrolPoints.Length; i++) 
            {
                patrol.patrolPoints[i] = Handles.PositionHandle(patrol.patrolPoints[i], Quaternion.identity);
            }
        }
    }
}