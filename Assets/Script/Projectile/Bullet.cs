using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float projectileSpeed = 20f;
    public float lifetime = 30f;

    public int projectileDamage;

    public float damage = 0;
    public string entityToAttack = "";

    private bool isTriggered = false;

    private HashSet<DamageType> normalDamageType = new HashSet<DamageType>() {DamageType.Normal};

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * projectileSpeed;
        StartCoroutine(countdown());
    }

    protected virtual void OnTriggerEnter2D(Collider2D entity)
    {
        if(entity.CompareTag(entityToAttack) && !isTriggered)
        {
            ITakeDamageable attackedEntity = entity.GetComponent<ITakeDamageable>();
            if (attackedEntity != null)
            {
                attackedEntity.takeDamage(damage,normalDamageType);
                isTriggered = true;
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    protected IEnumerator countdown()
    {
        yield return new WaitForSeconds(2f);
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
