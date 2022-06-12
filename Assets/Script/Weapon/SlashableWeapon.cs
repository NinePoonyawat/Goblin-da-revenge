using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/MeleeWeapon/SlashableWeapon")]
public class SlashableWeapon : MeleeWeapon
{
    public override void attack()
    {
        Debug.Log("attack!!! tatakae!!!!");
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy);
        }
    }
}
