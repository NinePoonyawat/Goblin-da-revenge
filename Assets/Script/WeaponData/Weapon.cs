using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class Weapon : ScriptableObject
{
    public GameObject weaponPrefab;
    protected GameObject weaponObject;
    public WeaponLogic weaponLogic;

    public string weaponName;
    public int damage;
    public float cooldownTime = 1.0f;

    [SerializeField]
    public Sprite image;

    public float size = 1;
    public Vector3 pickPosition;
    public float detectedRange;

    [SerializeField]
    [field: TextArea]
    public string description;
}
