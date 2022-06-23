using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour,ITakeDamageable
{
    [SerializeField]
    private float maxHealth;

    public float currentHealth;

    [SerializeField]
    private Transform handlePos;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;    
    }

    public virtual void takeDamage(float damage,DamageType damageType)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
