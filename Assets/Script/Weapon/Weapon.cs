using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public string weaponName;

    // Start is called before the first frame update
    public abstract void attack();
}
