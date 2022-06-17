using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityStatusSO : ScriptableObject
{
    [SerializeField]
    private bool isInfinite;
    [SerializeField]
    private float cooldown;

    public abstract void statusStart(StatManagement character);
    public abstract void action(StatManagement character);
    public abstract void statusFinish(StatManagement character);
}
