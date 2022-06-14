using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/BulletWeapon")]
public class BulletWeapon : Weapon
{
    [SerializeField]
    public GameObject bulletPrefab;

    public Vector3 gunPoint;
    public LayerMask enemyLayers;
}
