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

    protected virtual void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = weaponInHand.image;
        gameObject.GetComponent<Transform>().localScale = new Vector3(weaponInHand.size, weaponInHand.size, 1);
        gameObject.GetComponent<Transform>().localPosition = weaponInHand.pickPosition;

        weaponInHand.initialize();

        GO = Instantiate(weaponInHand.weaponPrefab) as GameObject;
        GO.transform.SetParent(this.transform);
        GO.GetComponent<Transform>().localPosition = Vector3.zero;

        if (gameObject.transform.parent.parent.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            GO.transform.Rotate(0, 180, 0);
        }

        weaponLogic = GO.GetComponent<WeaponLogic>();

        weaponInHand.initializeWeaponObject(GO);

        // if (!isPlayerControl)
        // {
        //     playerTransform = playerToDetected.GetComponent<Transform>();
        //     thisTransform = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Transform>();
        // }
    }

    void Update()
    {
        // if (isPlayerControl)
        // {
        //     if (Input.GetKeyDown(KeyCode.Space) && !isOnAttackCooldown)
        //     {
        //         weaponInHand.attack("Enemy");
        //         attackCooldownCount = weaponInHand.cooldownTime;
        //         isOnAttackCooldown = true;
        //     }
        // }
        // else
        // {
        //     if (Mathf.Abs(Vector3.Distance(playerTransform.position, thisTransform.position)) <= weaponInHand.detectedRange && !isOnAttackCooldown)
        //     {
        //         weaponInHand.attack("Player");
        //         attackCooldownCount = weaponInHand.cooldownTime;
        //         isOnAttackCooldown = true;
        //     }
        // }
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
}
