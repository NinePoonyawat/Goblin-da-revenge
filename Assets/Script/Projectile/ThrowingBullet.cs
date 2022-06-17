using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        entityToAttack = "Player";
        StartCoroutine(countdown());
    }

    protected override void OnTriggerEnter2D(Collider2D entity)
    {
        Debug.Log(entity.tag);
        Debug.Log(entityToAttack);
        base.OnTriggerEnter2D(entity);
        if(entity.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

}
