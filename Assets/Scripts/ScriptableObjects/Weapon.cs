using System;
using Entities;
using UnityEngine;
using static Tags.Tag;
using static Tags;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        public GameObject Projectile;
        public float ProjectileSpeed;
        public float WeaponCooldown;
        public MonoBehaviour Behavior;

        public Collider2D Source { get; set; }
        public int damage;
        
        
    }
}