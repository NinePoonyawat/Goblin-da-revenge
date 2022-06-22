using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandlingWeaponManagement : HandlingWeaponManagement
{

    protected override void Start()
    {
        base.Start();
        entityToAttack = "Enemy";
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space) && !isOnAttackCooldown)
            {
                weaponLogic.attack();
                attackCooldownCount = weaponInHand.cooldownTime;
                isOnAttackCooldown = true;
            }
    }
}
