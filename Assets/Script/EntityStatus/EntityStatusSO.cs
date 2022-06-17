using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EntityStatusSO : ScriptableObject
{
    [SerializeField]
    private string statusName;

    [SerializeField]
    private bool isInfinite;
    [SerializeField]
    private float cooldown;

    public virtual void statusStart(StatManagement character)
    {
    }

    public virtual void action(StatManagement character)
    {
    }

    public virtual void statusFinish(StatManagement character)
    {
    }

    public bool getIsInfinite()
    {
        return isInfinite;
    }

    public float getCooldown()
    {
        return cooldown;
    }
}
