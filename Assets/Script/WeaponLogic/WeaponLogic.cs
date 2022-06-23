using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponLogic : MonoBehaviour
{
    [SerializeField]
    protected float damage, cooldownTime, detectedRange;

    public string entityToAttack;

    protected WeaponType weaponType;

    public abstract void attack();

    public float getDamage()
    {
        return damage;
    }

    public float getCooldownTime()
    {
        return cooldownTime;
    }

    public float getDetectedRange()
    {
        return detectedRange;
    }

    public WeaponType getWeaponType()
    {
        return weaponType;
    }
}

public enum WeaponType
{
    Melee,
    Range
}