using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashableWeaponLogic : WeaponLogic
{
    [SerializeField]
    private Transform attackPoint;

    public float attackRange;
    public LayerMask entityLayers;
    private int damage;

    void Start()
    {
        attackPoint.localPosition = ((MeleeWeapon) gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand).attackPoint;
        attackRange = ((SlashableWeapon) gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand).attackRange;
        damage = gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand.damage;
    }

    public override void attack(string entityToAttack)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, entityLayers);

        foreach(Collider2D entity in hitEnemies)
        {
            if (entity.CompareTag(entityToAttack))
            {
                entity.GetComponent<StatManagement>().takeDamage(damage,DamageType.Normal);
            }
        }
    }
}
