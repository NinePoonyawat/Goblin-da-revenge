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

    protected override void takeDamage(int damage)
    {
        base.takeDamage(damage);
        healthBar.SetHealth(currentHealth);
    }
}
