using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyEdifice : MonoBehaviour
{
    [SerializeField]
    private Transform whereIsDoor;

    [SerializeField]
    private MemberGroup[] peopleInHouse;

    [SerializeField]
    private float rangeToDetected;

    [SerializeField]
    private float emitCooldown = 2f;

    private Transform goblinToDetected;
    private Transform enemyRoot;
    // Start is called before the first frame update
    void Start()
    {
        goblinToDetected = GameObject.Find("PlayingGoblin").GetComponent<Transform>();
        enemyRoot = GameObject.Find("Enemy").transform;
    }

    void Update()
    {
        if(Vector3.Distance(goblinToDetected.position,whereIsDoor.position) <= rangeToDetected)
        {
            StartCoroutine(emitAllEnemy());
            this.enabled = false;
        }
    }

    IEnumerator emitAllEnemy()
    {
        foreach (var memberGroup in peopleInHouse)
        {
            for (int i=0 ; i < memberGroup.enemyCount; i++)
            {
                GameObject GO = Instantiate(memberGroup.enemyPrefab,whereIsDoor.position,new Quaternion(0,0,0,0));
                GO.transform.SetParent(enemyRoot);
                if (memberGroup.enemyWeapon != null)
                {
                    GO.GetComponent<ComponentHandler>().handlingWeaponManagement.changeWeapon(memberGroup.enemyWeapon);
                }
                yield return new WaitForSeconds(emitCooldown);
            }
        }
    }

    [Serializable]
    public struct MemberGroup
    {
        public GameObject enemyPrefab;
        public Weapon enemyWeapon;
        public int enemyCount;
        public bool isBossEnemy;
    }
}
