using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandlingWeaponManagement : HandlingWeaponManagement
{
    [SerializeField]
    public GameObject playerToDetected;
    protected Transform playerTransform;
    protected Transform thisTransform;

    protected GameObject attackAlert;
    public float alertCooldown = .5f;
    private float alertCooldownCount = 0;
    private bool isOnAlertCooldown = false;

    private bool hasAttack = false;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerTransform = playerToDetected.GetComponent<Transform>();
        thisTransform = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Transform>();
        attackAlert = gameObject.transform.parent.parent.gameObject.transform.Find("AttackAlert").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(playerTransform.position, thisTransform.position)) <= weaponInHand.detectedRange && !isOnAlertCooldown && !isOnAttackCooldown && !hasAttack)
            {
                attackAlert.SetActive(true);
                alertCooldownCount = alertCooldown;
                isOnAlertCooldown = true;
            }
        if (hasAttack)
        {
            if (Mathf.Abs(Vector3.Distance(playerTransform.position, thisTransform.position)) <= weaponInHand.detectedRange)
            {
                weaponInHand.attack("Player");
                attackCooldownCount = weaponInHand.cooldownTime;
                isOnAttackCooldown = true;
            }
            hasAttack = false;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
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
}