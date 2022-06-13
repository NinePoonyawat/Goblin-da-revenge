using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/MeleeWeapon/SlashableWeapon")]
public class SlashableWeapon : MeleeWeapon
{
    void Start()
    {

    }

    public override void attack(string entityToAttack)
    {
        Debug.Log("attack!!! tatakae!!!!");
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        Debug.Log(attackPoint.position);
        foreach(Collider2D entity in hitEnemies)
        {
            if (entity.CompareTag(entityToAttack))
            {
                entity.GetComponent<StatManagement>().takeDamage(damage);
                Debug.Log("We hit" + entity.name);
            }
        }
    }

}