using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITakeDamageable
{
    public void takeDamage(float damage,HashSet<DamageType> damageType);
}

public enum DamageType
{
    Normal
}