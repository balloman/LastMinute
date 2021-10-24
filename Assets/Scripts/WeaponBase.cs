using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class WeaponBase : MonoBehaviour
{
    protected float cooldown = 0;

    protected bool IsOnCooldown => cooldown != 0;
    
    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown < 0) cooldown = 0;
    }
    
    public abstract void AttackAt(Vector2 facing);
}
