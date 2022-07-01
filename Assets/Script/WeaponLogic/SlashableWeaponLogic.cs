using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashableWeaponLogic : WeaponLogic
{
    public GameObject meleeEffectPrefab;

    [SerializeField]
    protected Transform attackPoint;

    public float attackRange;
    public LayerMask hitLayers;

    private HashSet<DamageType> normalDamageType = new HashSet<DamageType>() {DamageType.Normal};

    void Awake()
    {
        hitLayers = LayerMask.GetMask("Entity") | LayerMask.GetMask("Shield");
        weaponType = WeaponType.Melee;
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
                    attackedEntity.takeDamage(damage,normalDamageType);
                }
            }
        }
    }
}
