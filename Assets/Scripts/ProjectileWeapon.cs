using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class ProjectileWeapon : WeaponBase
{
    public Weapon weapon;

    public override void AttackAt(Vector2 facing)
    {
        if (IsOnCooldown) return;
        weapon.Source = gameObject.GetComponent<Collider2D>();
        var projectile = Instantiate(weapon.Projectile, transform.position, Quaternion.identity);
        projectile.GetComponent<ProjectileController>().Setup(weapon);
        projectile.GetComponent<Rigidbody2D>().AddForce(facing.normalized * weapon.ProjectileSpeed);
        cooldown = weapon.WeaponCooldown;
    }
}
