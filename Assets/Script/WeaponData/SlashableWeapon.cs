using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/MeleeWeapon/SlashableWeapon")]
public class SlashableWeapon : MeleeWeapon
{
    void Start()
    {

    }

    public override void attack()
    {
        Debug.Log("attack!!! tatakae!!!!");
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
        }
    }

}