using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManagement : StatManagement
{
    public HealthBar healthBar;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        healthBar.SetMaxHealth(maxHealth);
    }

    public override void takeDamage(float damage,DamageType damageType)
    {
        base.takeDamage(damage,damageType);
        healthBar.SetHealth(currentHealth);
    }
}
