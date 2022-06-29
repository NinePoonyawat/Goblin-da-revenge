using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponInventory : ScriptableObject
{
    [SerializeField]
    private GameObject weapon1,weapon2,weapon3;

    private GameObject selectedWeapon;

    public GameObject getWeapon1()
    {
        selectedWeapon = weapon1;
        return weapon1;
    }

    public GameObject getWeapon2()
    {
        selectedWeapon = weapon2;
        return weapon2;
    }

    public GameObject getWeapon3()
    {
        selectedWeapon = weapon3;
        return weapon3;
    }
}
