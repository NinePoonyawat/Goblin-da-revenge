using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponLogic : MonoBehaviour
{
    [SerializeField]
    public GameObject weaponPrefab;
    private bool isWeaponInHand;

    [SerializeField]
    public Transform handPos;

    private GameObject GO;
    private WeaponLogic weaponLogic;

    protected float attackCooldownCount = .0f;
    protected bool isOnAttackCooldown = false;

    public string entityToAttack;

    protected Transform mainTransform;

    protected virtual void Start()
    {
        entityToAttack = "Enemy";
        mainTransform = gameObject.transform;
        if (weaponPrefab == null)
        {
            isWeaponInHand = false;
            return;
        }
        setWeapon(weaponPrefab);
    }

    protected virtual void Update()
    {
        if (!isWeaponInHand)
            return;
        if (Input.GetKeyDown(KeyCode.Space) && !isOnAttackCooldown)
            {
                weaponLogic.attack();
                attackCooldownCount = weaponPrefab.GetComponent<WeaponLogic>().getCooldownTime();
                isOnAttackCooldown = true;
            }
    }

    protected virtual void FixedUpdate()
    {
        if (!isWeaponInHand)
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

    public virtual void setWeapon(GameObject weaponPrefab)
    {
        if (weaponPrefab == null)
        {
            return;
        }
        // weaponInHand = newWeaponInHand;
        isWeaponInHand = true;
        // gameObject.GetComponent<SpriteRenderer>().sprite = newWeaponInHand.image;
        // gameObject.transform.localScale = new Vector3(newWeaponInHand.size, newWeaponInHand.size, 1);
        // gameObject.transform.localPosition = newWeaponInHand.pickPosition;

        GameObject GO = Instantiate(weaponPrefab) as GameObject;
        GO.transform.SetParent(handPos);
        Vector3 distanceToMove = GO.transform.Find("HandlePos").position - handPos.position;
        GO.transform.position -= distanceToMove;
        //GO.transform.Find("HandlePos").position = handPos.position;

        GO.transform.rotation = mainTransform.rotation;
        GO.GetComponent<WeaponLogic>().entityToAttack = "Enemy";
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
            Destroy(GO);
        }
        catch (System.Exception)
        {
        }
        isWeaponInHand = false;
        weaponPrefab = null;
        weaponLogic = null;
    }

    public void changeWeapon(GameObject weaponPrefab)
    {
        releaseCurrentWeapon();
        setWeapon(weaponPrefab);
    }
}
