using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class Weapon : ScriptableObject
{
    public string weaponName;
    public float damage;
    
    public float cooldownTime = 1.0f;

    [SerializeField]
    public string description;

    // Start is called before the first frame update
    public abstract void attack();

}
