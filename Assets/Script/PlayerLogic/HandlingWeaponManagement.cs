using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlingWeaponManagement : MonoBehaviour
{
    [SerializeField]
    public Weapon weaponInHand;

    [SerializeField]
    public Transform whereIsHand;

    public bool isPlayerControl = false;

    private float attackCooldownCount = .0f;
    private bool isOnAttackCooldown = false;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = weaponInHand.image;
        gameObject.GetComponent<Transform>().localScale = new Vector3(weaponInHand.size, weaponInHand.size, 1);
        gameObject.GetComponent<Transform>().localPosition = weaponInHand.pickPosition;

        weaponInHand.initialize();

        GameObject GO = Instantiate(weaponInHand.weaponPrefab) as GameObject;
        GO.transform.SetParent(this.transform);
        GO.GetComponent<Transform>().localPosition = Vector3.zero;

        weaponInHand.initializeWeaponObject(GO);
    }

    void Update()
    {
        if (isPlayerControl)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isOnAttackCooldown)
            {
                weaponInHand.attack("Enemy");
                attackCooldownCount = weaponInHand.cooldownTime;
                isOnAttackCooldown = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (attackCooldownCount > 0)
        {
            attackCooldownCount -= Time.deltaTime;
        }
        if (attackCooldownCount <= 0)
        {
            isOnAttackCooldown = false;
        }
    }
}
