using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHammerLogic : SlashableWeaponLogic
{
    [SerializeField]
    protected GameObject explosionPrefab;
    [SerializeField]
    protected int explosionDamage,explosionTime;
    [SerializeField]
    protected Vector3 explodeDistance;

    protected void Awake()
    {
        hitLayers = LayerMask.GetMask("Entity") | LayerMask.GetMask("Shield");
        weaponType = WeaponType.Range;
    }

    public override void attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, hitLayers);

        //Instantiate(meleeEffectPrefab, attackPoint.position, attackPoint.rotation);
        StartCoroutine(ExplodeEvent());

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

    private IEnumerator ExplodeEvent()
    {
        Vector3 startPosition = transform.position;
        for (int i = 0; i < explosionTime; i++)
        {
            if (i == 0)
            {
                Instantiate(explosionPrefab,startPosition,Quaternion.identity);
                explode(startPosition);
            }
            else
            {
                Instantiate(explosionPrefab,startPosition + explodeDistance * i, Quaternion.identity);
                explode(startPosition + explodeDistance * i);
                Instantiate(explosionPrefab,startPosition - explodeDistance * i,Quaternion.identity);
                explode(startPosition - explodeDistance * i);
            }
            yield return new WaitForSeconds(0.7f);
        }
    }

    private void explode(Vector3 position)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(position, attackRange, hitLayers);

        foreach(Collider2D entity in hitEnemies)
        {
            if (entity.CompareTag("Player"))
            {
                ITakeDamageable attackedEntity = entity.GetComponent<ITakeDamageable>();
                if (attackedEntity != null)
                {
                    attackedEntity.takeDamage(explosionDamage,DamageType.Normal);
                }
            }
        }
    }
}
