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

    public virtual void statusStart(Player character)
    {
    }

    public virtual void action(Player character)
    {
    }

    public virtual void statusFinish(Player character)
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
