using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGlass : MonoBehaviour
{
    public EntityStatusSO entityStatus;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EntityStatus status = collision.gameObject.AddComponent<EntityStatus>() as EntityStatus;
            status.initial(entityStatus,collision.gameObject.GetComponent<StatManagement>());
            Destroy(gameObject);
        }
    }
}
