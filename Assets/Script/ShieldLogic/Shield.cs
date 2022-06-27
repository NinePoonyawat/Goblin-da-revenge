using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour,ITakeDamageable
{
    [SerializeField]
    private float maxHealth;

    public float currentHealth;

    private bool isDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        isDestroyed = false;    
    }

    public virtual void takeDamage(float damage,DamageType damageType)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isDestroyed = true;
        }
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public bool getIsDestroyed()
    {
        return isDestroyed;
    }
}
