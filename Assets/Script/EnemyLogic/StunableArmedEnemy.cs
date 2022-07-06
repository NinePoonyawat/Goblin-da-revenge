using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is logic of armed enemy which stanable.
public class StunableArmedEnemy : ArmedEnemy
{
    public override void takeDamage(float damage,HashSet<DamageType> damageType)
    {
        if (isOnAlertCooldown)
        {
            Stunt stunt = gameObject.AddComponent<Stunt>();
            stunt.perform(10f);
            attackAlert.SetActive(false);
            isOnAlertCooldown = false;
            alertCooldownCount = 0;
        }
        base.takeDamage(damage,damageType);
    }
}
