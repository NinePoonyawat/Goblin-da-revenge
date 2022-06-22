using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatManagement : StatManagement
{
    public HealthBar healthBar;

   // private int EXPAfterKilled;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        healthBar.SetMaxHealth(maxHealth);

        //EXPAfterKilled = gameObject.GetComponent<MainEnemyLogic>().enemyData.getEXPAfterKilled();
    }

    public override void takeDamage(float damage,DamageType damageType)
    {
        base.takeDamage(damage,damageType);
        healthBar.SetHealth(currentHealth);
    }

    public override void die()
    {
        //GameObject.Find("PlayingGoblin").GetComponent<MainPlayerLogic>().experienceSystem.addEXP(EXPAfterKilled);
        base.die();
    }
}