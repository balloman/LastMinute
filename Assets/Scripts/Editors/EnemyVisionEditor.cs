using Entities.Enemies;
using UnityEditor;
using UnityEngine;

namespace Editors
{
    [CustomEditor(typeof(EnemyVision))]
    public class EnemyVisionEditor : Editor
    {
        private void OnSceneGUI() {
            var vision = (EnemyVision) target;

            Handles.DrawWireDisc(vision.transform.position, Vector3.forward, vision.viewDist, 0);
        }
    }
}