using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandlingWeaponManagement : HandlingWeaponManagement
{
    [SerializeField]
    public GameObject playerToDetected;
    protected Transform playerTransform;
    protected Transform thisTransform;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerTransform = playerToDetected.GetComponent<Transform>();
        thisTransform = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(playerTransform.position, thisTransform.position)) <= weaponInHand.detectedRange && !isOnAttackCooldown)
            {
                weaponInHand.attack("Player");
                attackCooldownCount = weaponInHand.cooldownTime;
                isOnAttackCooldown = true;
            }
    }
}