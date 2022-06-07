using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/MeleeWeapon/SlashableWeapon")]
public class SlashableWeapon : MeleeWeapon
{

    public override void attack()
    {
        Debug.Log("attack!!! tatakae!!!!");
    }
}
