using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entities.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class AttackHandler : MonoBehaviour
{
    private Vector2 facing = Vector2.zero;
    private TransformMovement movementBehavior;

    private void Awake()
    {
        movementBehavior = GetComponent<TransformMovement>();
    }

    protected void Attack(InputAction.CallbackContext context)
    {
        var weapons = GetComponents<WeaponBase>();
        if (weapons.Length == 0) return;
        var index = Random.Range(0, weapons.Length);
        weapons[index].AttackAt(facing);
    }

    private void Update()
    {
        UpdateFacing();
    }

    private void UpdateFacing()
    {
        var newFacing = movementBehavior.MovementVector;
        if (newFacing.magnitude == 0) return;
        facing = newFacing;
    }
}
