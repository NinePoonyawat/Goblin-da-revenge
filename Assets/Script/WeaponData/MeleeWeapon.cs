using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]//(menuName = "Weapon/MeleeWeapon")]
public abstract class MeleeWeapon : Weapon
{
    public Vector3 attackPos;
    private Transform attackPoint;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public override void initialize()
    {
        weaponPrefab.transform.GetChild(0).GetComponent<Transform>().position = attackPos;
    }
}
