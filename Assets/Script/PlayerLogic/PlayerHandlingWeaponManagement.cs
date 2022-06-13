using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandlingWeaponManagement : HandlingWeaponManagement
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isOnAttackCooldown)
            {
                weaponInHand.attack("Enemy");
                attackCooldownCount = weaponInHand.cooldownTime;
                isOnAttackCooldown = true;
            }
    }
}
