using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeaponLogic : WeaponLogic
{
    [SerializeField]
    private Transform gunPoint;

    [SerializeField]
    private CharacterController2D characterController;

    public GameObject bulletPrefab;

    public LayerMask entityLayers;
    private int damage;

    void Start()
    {
        bulletPrefab = ((BulletWeapon) gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand).bulletPrefab;
        damage = gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand.damage;
        bulletPrefab.GetComponent<Bullet>().entityToAttack = gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().entityToAttack;
    }

    public override void attack(string entityToAttack)
    {
        GameObject GO = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        GO.GetComponent<Bullet>().damage = damage;
    }
}
