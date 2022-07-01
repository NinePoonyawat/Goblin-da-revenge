using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EntityStatus/FootHurtedStatus")]
public class FootHurtedStatusSO : EntityStatusSO
{
    [SerializeField]
    private float speed,walkingDamage;
    private HashSet<DamageType> normalDamageType = new HashSet<DamageType>() {DamageType.Normal};

    public override void statusStart(Player character)
    {
        character.setRunSpeed(speed);
    }

    public override void action(Player character)
    {
        if (character.controller.hasXMove())
        {
            character.takeDamage(walkingDamage,normalDamageType);
        }
    }

    public override void statusFinish(Player character)
    {
        character.setDefaultRunSpeed();
    }
}
