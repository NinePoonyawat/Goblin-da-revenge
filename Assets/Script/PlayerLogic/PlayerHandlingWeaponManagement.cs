using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandlingWeaponManagement : HandlingWeaponManagement
{

    protected override void Start()
    {
        base.Start();
        Debug.Log(weaponInHand);
        entityToAttack = "Enemy";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isOnAttackCooldown)
            {
                weaponLogic.attack("Enemy");
                attackCooldownCount = weaponInHand.cooldownTime;
                isOnAttackCooldown = true;
            }
    }
}
