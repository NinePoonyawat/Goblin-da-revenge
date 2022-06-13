using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponLogic : MonoBehaviour
{
    public abstract void attack(string entityToAttack);
}