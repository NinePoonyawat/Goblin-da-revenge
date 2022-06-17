using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlingWeaponManagement : MonoBehaviour
{
    [SerializeField]
    public Weapon weaponInHand;

    [SerializeField]
    public Transform whereIsHand;

    public GameObject GO;
    public WeaponLogic weaponLogic;

    protected float attackCooldownCount = .0f;
    protected bool isOnAttackCooldown = false;

    public string entityToAttack;

    protected virtual void Start()
    {
        setWeapon(weaponInHand);
    }

    void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
        if (attackCooldownCount > 0)
        {
            attackCooldownCount -= Time.deltaTime;
        }
        if (attackCooldownCount <= 0 && isOnAttackCooldown)
        {
            isOnAttackCooldown = false;
        }
    }

    public void setWeapon(Weapon weaponInHand)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = weaponInHand.image;
        gameObject.GetComponent<Transform>().localScale = new Vector3(weaponInHand.size, weaponInHand.size, 1);
        gameObject.GetComponent<Transform>().localPosition = weaponInHand.pickPosition;

        GO = Instantiate(weaponInHand.weaponPrefab) as GameObject;
        GO.transform.SetParent(this.transform);
        GO.GetComponent<Transform>().localPosition = Vector3.zero;

        if (gameObject.transform.parent.parent.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            GO.transform.Rotate(0, 180, 0);
        }

        weaponLogic = GO.GetComponent<WeaponLogic>();
    }

}
