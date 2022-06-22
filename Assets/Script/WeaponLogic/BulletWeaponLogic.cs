using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeaponLogic : WeaponLogic
{
    [SerializeField]
    private Transform gunPoint;

    public GameObject bulletPrefab;

    public LayerMask entityLayers;

    void Start()
    {
        //damage = gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand.damage;
        //entityToAttack = gameObject.GetComponent<PlayerWeaponLogic>().entityToAttack;

        //gunPoint.localPosition = ((BulletWeapon) gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand).gunPoint;
    }

    public override void attack()
    {
        GameObject GO = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        GO.GetComponent<Bullet>().damage = damage;
        GO.GetComponent<Bullet>().entityToAttack = entityToAttack;
    }
}
