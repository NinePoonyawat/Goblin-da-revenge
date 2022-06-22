using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EntityStatus/FootHurtedStatus")]
public class FootHurtedStatusSO : EntityStatusSO
{
    [SerializeField]
    private float speed,walkingDamage;

    public override void statusStart(StatManagement character)
    {
        character.allComponent.playerMovement.setRunSpeed(speed);
    }

    public override void action(StatManagement character)
    {
        if (character.allComponent.characterController2D.hasXMove())
        {
            character.takeDamage(walkingDamage,DamageType.Normal);
        }
    }

    public override void statusFinish(StatManagement character)
    {
        character.allComponent.playerMovement.setDefaultRunSpeed();
    }
}
