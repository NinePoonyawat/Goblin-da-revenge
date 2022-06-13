using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]//(menuName = "Weapon/MeleeWeapon")]
public abstract class MeleeWeapon : Weapon
{
    public Vector3 attackPos;
    protected Transform attackPoint;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public override void initialize()
    {
    }

    public override void initializeWeaponObject(GameObject GO)
    {
        base.initializeWeaponObject(GO);
        attackPoint = weaponObject.transform.GetChild(0).GetComponent<Transform>();
    }
}
