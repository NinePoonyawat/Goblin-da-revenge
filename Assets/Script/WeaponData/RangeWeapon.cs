using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField]
    public GameObject bulletPrefab;

    public Vector3 gunPoint;
    public LayerMask enemyLayers;
}
