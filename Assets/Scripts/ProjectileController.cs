using Entities;
using ScriptableObjects;
using UnityEngine;
using static Tags.Tag;
using static Tags;

public class ProjectileController : MonoBehaviour
{
    private Weapon Weapon { get; set; }
    
    public void Setup(Weapon weapon)
    {
        Weapon = weapon;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == Weapon.Source) return;
        if (other.isTrigger && !other.CompareTag(GetTag[Enemy])) return;
        var health = other.gameObject.GetComponent<HealthHandler>();
        if (health != null)
            health.CurrentHealth -= Weapon.damage;
        Destroy(gameObject);
    }
}