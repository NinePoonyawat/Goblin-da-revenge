using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityStatus : ScriptableObject
{
    [SerializeField]
    private EntityStatusSO entityStatus;
    [SerializeField]
    private StatManagement statManagement;

    public bool isInfinite;
    public float cooldown;
    private float cooldownCounter;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if(!isInfinite)
        {
            cooldownCounter = cooldown;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(!isInfinite && cooldownCounter <= 0)
        {
            Destroy(this);
        }
        entityStatus.action(statManagement);
    }

    void FixedUpdate()
    {
        cooldownCounter -= Time.deltaTime;
    }
}
