using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatManagement : StatManagement
{
    public HealthBar healthBar;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        healthBar.SetMaxHealth(maxHealth);
    }

    public override void takeDamage(float damage)
    {
        base.takeDamage(damage);
        healthBar.SetHealth(currentHealth);
    }
}
