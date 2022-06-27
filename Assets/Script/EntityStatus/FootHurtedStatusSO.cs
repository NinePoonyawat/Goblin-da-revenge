using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EntityStatus/FootHurtedStatus")]
public class FootHurtedStatusSO : EntityStatusSO
{
    [SerializeField]
    private float speed,walkingDamage;

    public override void statusStart(Player character)
    {
        character.setRunSpeed(speed);
    }

    public override void action(Player character)
    {
        if (character.controller.hasXMove())
        {
            character.takeDamage(walkingDamage,DamageType.Normal);
        }
    }

    public override void statusFinish(Player character)
    {
        character.setDefaultRunSpeed();
    }
}
