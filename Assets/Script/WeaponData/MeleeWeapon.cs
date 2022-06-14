using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]//(menuName = "Weapon/MeleeWeapon")]
public abstract class MeleeWeapon : Weapon
{
    protected Transform attackPoint;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

}
