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

        entityToAttack = "Player";
        playerToDetected = GameObject.Find("PlayingGoblin");
        
        playerTransform = playerToDetected.GetComponent<Transform>();
        attackAlert = mainTransform.Find("AttackAlert").gameObject;
    }

    public override void setWeapon(Weapon newWeaponInHand)
    {
        base.setWeapon(newWeaponInHand);
        thisTransform = gameObject.transform.GetChild(0).GetChild(0).transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (playerToDetected == null)
            return;
        float range = Mathf.Abs(playerTransform.position.x - thisTransform.position.x);
        bool isOnAttackRange = range <= weaponInHand.detectedRange;
        if (isOnAttackRange && !isOnAlertCooldown && !isOnAttackCooldown && !hasAttack)
            {
                attackAlert.SetActive(true);
                alertCooldownCount = alertCooldown;
                isOnAlertCooldown = true;
            }
        if (hasAttack)
        {
            if (isOnAttackRange)
            {
                weaponLogic.attack("Player");
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