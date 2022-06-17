using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThrowingWeaponLogic : WeaponLogic
{
    [SerializeField]
    private Transform gunPoint;

    public GameObject bulletPrefab;

    public LayerMask entityLayers;
    private int damage;
    private string entityToAttack;

    private Transform target;

    private float Xvelocity,Yvelocity;

    void Start()
    {
        target = GameObject.Find("PlayingGoblin").GetComponent<Transform>();

        bulletPrefab = ((ThrowingWeapon) gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand).bulletPrefab;
        damage = gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand.damage;
        entityToAttack = "Player";

        gunPoint.localPosition = ((ThrowingWeapon) gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand).gunPoint;
    }

    public override void attack(string entityToAttack)
    {
        calculateVelocity();
        GameObject GO = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        GO.GetComponent<ThrowingBullet>().damage = damage;

        GO.GetComponent<ThrowingBullet>().rb.velocity = new Vector2(3*Xvelocity,3*Yvelocity);
    }

    private void calculateVelocity()
    {
        float x = target.position.x - gunPoint.position.x;
        float y = target.position.y - gunPoint.position.y;
        if (x <= 0)
        {
            Xvelocity = (float) (x/(Math.Sqrt(2*(y - x))));
            Yvelocity = (float) (-x/(Math.Sqrt(2*(y - x))));
        }
        else
        {
            if (x < y)
            {
                x = y;
            }
            Xvelocity = (float) (x/(Math.Sqrt(2*(y - x))));
            Yvelocity = (float) (x/(Math.Sqrt(2*(y - x))));
        }
    }
}
