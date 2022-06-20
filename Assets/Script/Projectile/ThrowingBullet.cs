using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBullet : Bullet
{
    public float rotationSpeed = 10.0f;
    private Vector3 rotationVector;

    // Start is called before the first frame update
    void Start()
    {
        entityToAttack = "Player";
        StartCoroutine(countdown());
    }

    protected override void OnTriggerEnter2D(Collider2D entity)
    {
        base.OnTriggerEnter2D(entity);
        if(entity.CompareTag("Ground"))
        {
            hitGroundEvent();
        }
    }

    protected virtual void hitGroundEvent()
    {
        Destroy(gameObject);
    }

}
