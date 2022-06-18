using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGlass : MonoBehaviour
{
    public float lifeTime = 7.0f;
    public EntityStatusSO entityStatus;

    void Start()
    {
        StartCoroutine(countdown());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EntityStatus status = collision.gameObject.AddComponent<EntityStatus>() as EntityStatus;
            status.initial(entityStatus,collision.gameObject.GetComponent<StatManagement>());
            Destroy(gameObject);
        }
    }

    private IEnumerator countdown()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
