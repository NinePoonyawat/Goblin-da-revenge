using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStatus : MonoBehaviour
{
    private bool hasSetStatus = false;

    [SerializeField]
    private EntityStatusSO entityStatus;
    [SerializeField]
    private Player statManagement;

    public bool isInfinite;
    public float cooldown;
    private float cooldownCounter;

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!hasSetStatus)
            return;
        if(!isInfinite && cooldownCounter <= 0)
        {
            entityStatus.statusFinish(statManagement);
            Destroy(this);
        }
        entityStatus.action(statManagement);
    }

    void FixedUpdate()
    {
        if (!hasSetStatus)
            return;
        cooldownCounter -= Time.deltaTime;
    }

    public void initial(EntityStatusSO entityStatus,Player statManagement)
    {
        this.entityStatus = entityStatus;
        this.statManagement = statManagement;
        this.isInfinite = entityStatus.getIsInfinite();
        this.cooldown = entityStatus.getCooldown();

        if(!isInfinite)
        {
            cooldownCounter = cooldown;
        }

        entityStatus.statusStart(statManagement);
        hasSetStatus = true;
    }
}
