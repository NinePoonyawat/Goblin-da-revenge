using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManagement : MonoBehaviour,ITakeDamageable
{
    public float maxHealth;
    public float currentHealth;

    public SpriteRenderer sprite;
    public Color defaultColor;

    public ComponentHandler allComponent;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        defaultColor = sprite.color;
    }

    public virtual void takeDamage(float damage,DamageType damageType)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            die();
        }

        StartCoroutine(flashRed());
    }

    public virtual void die()
    {
        Destroy(gameObject);
    }

    public IEnumerator flashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = defaultColor;
    }
}
