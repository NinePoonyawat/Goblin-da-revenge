using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static AttackManager instance {get; private set;}
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void attack(GameObject attackedEntity,int damage)
    {
        attackedEntity.GetComponent<StatManagement>().takeDamage(damage,DamageType.Normal);
    }
}
