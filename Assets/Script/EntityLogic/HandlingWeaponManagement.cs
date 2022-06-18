using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlingWeaponManagement : MonoBehaviour
{
    [SerializeField]
    public Weapon weaponInHand;
    private bool isWeaponInHand;

    [SerializeField]
    public Transform whereIsHand;

    public GameObject GO;
    public WeaponLogic weaponLogic;

    protected float attackCooldownCount = .0f;
    protected bool isOnAttackCooldown = false;

    public string entityToAttack;

    protected virtual void Start()
    {
        if (weaponInHand == null)
        {
            isWeaponInHand = false;
            return;
        }
        setWeapon(weaponInHand);
    }

    protected virtual void Update()
    {
        if (!isWeaponInHand)
            return;
    }

    protected virtual void FixedUpdate()
    {
        if (!weaponInHand)
            return;
        if (attackCooldownCount > 0)
        {
            attackCooldownCount -= Time.deltaTime;
        }
        if (attackCooldownCount <= 0 && isOnAttackCooldown)
        {
            isOnAttackCooldown = false;
        }
    }

    public virtual void setWeapon(Weapon newWeaponInHand)
    {
        if (newWeaponInHand == null)
        {
            return;
        }
        weaponInHand = newWeaponInHand;
        isWeaponInHand = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = newWeaponInHand.image;
        gameObject.GetComponent<Transform>().localScale = new Vector3(newWeaponInHand.size, newWeaponInHand.size, 1);
        gameObject.GetComponent<Transform>().localPosition = newWeaponInHand.pickPosition;

        GO = Instantiate(newWeaponInHand.weaponPrefab) as GameObject;
        GO.transform.SetParent(this.transform);
        GO.GetComponent<Transform>().localPosition = Vector3.zero;

        GO.transform.rotation = gameObject.transform.parent.parent.transform.rotation;
        // if (gameObject.transform.parent.parent.gameObject.GetComponent<SpriteRenderer>().flipX)
        // {
        //     Debug.Log("do this line");
        //     GO.transform.Rotate(0, 180, 0);
        // }

        weaponLogic = GO.GetComponent<WeaponLogic>();
    }

    public void releaseCurrentWeapon()
    {
        try
        {
            Destroy(gameObject.transform.GetChild(0));
        }
        catch (System.Exception)
        {
        }
        isWeaponInHand = false;
        weaponInHand = null;
        weaponLogic = null;
    }

    public void changeWeapon(Weapon weapon)
    {
        releaseCurrentWeapon();
        setWeapon(weapon);
    }

}
