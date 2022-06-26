using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemy : Enemy
{
    [Header("Weapon Management")]
    [SerializeField]
    public GameObject weaponPrefab;
    private bool isWeaponInHand;

    [SerializeField]
    public Transform handPos;

    private GameObject GO;
    private WeaponLogic weaponLogic;
    private Transform weaponTransform;

    protected float attackCooldownCount = .0f;
    protected bool isOnAttackCooldown = false;

    [Header("UI")]
    [SerializeField]
    protected GameObject attackAlert;
    protected bool isOnAlertCooldown = false;

    public float alertCooldown = .5f;
    private float alertCooldownCount = 0;

    private bool hasAttack = false;

    protected override void Start()
    {
        base.Start();

        if (weaponPrefab == null)
        {
            isWeaponInHand = false;
            return;
        }
        setWeapon(weaponPrefab);
    }

    protected override void Update()
    {
        base.Update();

        if (GO == null)
            return;
        if (targetToDetected == null)
            return;
        float range = Mathf.Abs(targetTransform.position.x - weaponTransform.position.x);
        bool isOnAttackRange = range <= weaponPrefab.GetComponent<WeaponLogic>().getDetectedRange();
        if (isOnAttackRange && !isOnAlertCooldown && !isOnAttackCooldown && !hasAttack)
            {
                attackAlert.SetActive(true);
                alertCooldownCount = alertCooldown;
                isOnAlertCooldown = true;
                isRotatable = false;
            }
        if (hasAttack)
        {
            weaponLogic.attack();
            attackCooldownCount = weaponPrefab.GetComponent<WeaponLogic>().getCooldownTime();
            isOnAttackCooldown = true;
            hasAttack = false;
            isRotatable = true;
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

        if (alertCooldownCount > 0)
        {
            alertCooldownCount -= Time.deltaTime;
        }
        if (alertCooldownCount <= 0 && isOnAlertCooldown)
        {
            isOnAlertCooldown = false;
            attackAlert.SetActive(false);
            hasAttack = true;
        }
    }

    public virtual void setWeapon(GameObject weaponPrefab)
    {
        if (weaponPrefab == null)
        {
            return;
        }
        // weaponInHand = newWeaponInHand;
        this.weaponPrefab = weaponPrefab;
        isWeaponInHand = true;

        GO = Instantiate(weaponPrefab) as GameObject;
        GO.transform.SetParent(handPos);
        GO.transform.rotation = objectTransform.rotation;

        Vector3 distanceToMove = GO.transform.Find("HandlePos").position - handPos.position;
        GO.transform.position -= distanceToMove;
        weaponTransform = GO.transform;
        GO.GetComponent<WeaponLogic>().entityToAttack = "Player";

        weaponLogic = GO.GetComponent<WeaponLogic>();

        recommendedRange = weaponLogic.getDetectedRange();
        WeaponType weaponType = weaponLogic.getWeaponType();
        switch (weaponType)
        {
            case WeaponType.Range:
                enemyBehavior = EnemyBehavior.NibbleTarget;
                break;
            default:
                enemyBehavior = EnemyBehavior.FaceTarget;
                break;
        }
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
