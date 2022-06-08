using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float projectileSpeed = 20f;
    public float lifetime = 30f;

    public int projectileDamage;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * projectileSpeed;
        StartCoroutine(countdown());
    }

    // Update is called once per frame
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(2f);
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
