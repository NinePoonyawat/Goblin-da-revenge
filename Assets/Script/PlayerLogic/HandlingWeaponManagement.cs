using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlingWeaponManagement : MonoBehaviour
{
    [SerializeField]
    public Weapon weaponInHand;

    private float attackCooldownCount = .0f;
    private bool isOnAttackCooldown = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isOnAttackCooldown)
        {
            weaponInHand.attack();
            attackCooldownCount = weaponInHand.cooldownTime;
            isOnAttackCooldown = true;
        }
    }

    void FixedUpdate()
    {
        if (attackCooldownCount > 0)
        {
            attackCooldownCount -= Time.deltaTime;
        }
        if (attackCooldownCount <= 0)
        {
            isOnAttackCooldown = false;
        }
    }
}
