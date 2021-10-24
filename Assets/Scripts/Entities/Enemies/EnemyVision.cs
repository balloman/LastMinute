using System;
using System.Linq;
using UnityEngine;

using static Tags.Tag;

namespace Entities.Enemies
{
    public class EnemyVision : MonoBehaviour
    {
        public enum Targeting
        {
            None,
            Physical,
            Ethereal,
            Both
        }
        
        public float viewDist;
        public Targeting targetingSelection = Targeting.Both;

        public bool CanSeePlayer => VisiblePlayer != null;
        
        public GameObject VisiblePlayer => targetingSelection switch
        {
            Targeting.None => null,
            Targeting.Physical => VisiblePhysical,
            Targeting.Ethereal => VisibleEthereal,
            Targeting.Both => VisiblePhysical ? VisiblePhysical : VisibleEthereal,
            _ => throw new ArgumentOutOfRangeException()
        };

        private GameObject VisibleEthereal => GameObject.FindGameObjectsWithTag(Tags.GetTag[Wisp]).ToList().Find(go =>
            Vector2.Distance(go.transform.position, transform.position) < viewDist);
        
        private GameObject VisiblePhysical => GameObject.FindGameObjectsWithTag(Tags.GetTag[Body]).ToList().Find(go =>
            Vector2.Distance(go.transform.position, transform.position) < viewDist);
    }
}
