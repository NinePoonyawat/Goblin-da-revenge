using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class Weapon : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float cooldownTime = 1.0f;
    public Vector3 attackPos;

    [SerializeField]
    public Sprite image;

    public float size = 1;
    public Vector3 pickPosition;

    [SerializeField]
    [field: TextArea]
    public string description;

    // Start is called before the first frame update
    public abstract void attack();

}
