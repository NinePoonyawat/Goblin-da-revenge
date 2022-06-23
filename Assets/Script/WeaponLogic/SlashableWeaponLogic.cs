using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashableWeaponLogic : WeaponLogic
{
    public GameObject meleeEffectPrefab;

    [SerializeField]
    private Transform attackPoint;

    public float attackRange;
    public LayerMask hitLayers;

    void Start()
    {
        hitLayers = LayerMask.GetMask("Entity") | LayerMask.GetMask("Shield");
        // attackPoint.localPosition = ((MeleeWeapon) gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand).attackPoint;
        // attackRange = ((SlashableWeapon) gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand).attackRange;
        // damage = gameObject.transform.parent.gameObject.GetComponent<HandlingWeaponManagement>().weaponInHand.damage;
    }

    public override void attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, hitLayers);

        Instantiate(meleeEffectPrefab, attackPoint.position, attackPoint.rotation);

        foreach(Collider2D entity in hitEnemies)
        {
            if (entity.CompareTag(entityToAttack))
            {
                ITakeDamageable attackedEntity = entity.GetComponent<ITakeDamageable>();
                if (attackedEntity != null)
                {
                    attackedEntity.takeDamage(damage,DamageType.Normal);
                }
            }
        }
    }
}
