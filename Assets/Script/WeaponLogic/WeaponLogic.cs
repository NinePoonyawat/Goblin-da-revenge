using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponLogic : MonoBehaviour
{
    [SerializeField]
    protected float damage, cooldownTime;

    public string entityToAttack;

    public abstract void attack();

    public float getDamage()
    {
        return damage;
    }

    public float getCooldownTime()
    {
        return cooldownTime;
    }
}