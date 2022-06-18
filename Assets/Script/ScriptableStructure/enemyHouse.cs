using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemyHouse : MonoBehaviour
{
    [SerializeField]
    private Transform whereIsDoor;

    [SerializeField]
    private GameObject hostPrefab;

    [SerializeField]
    private MemberGroup[] peopleInHouse;

    [SerializeField]
    private bool isHostInTheHouse = true;

    [SerializeField]
    private float rangeToDetected;

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
        if(Vector3.Distance(goblinToDetected.position,whereIsDoor.position) <= rangeToDetected && isHostInTheHouse)
        {
            emitAllEnemy();
            isHostInTheHouse = false;
            this.enabled = false;
        }
    }

    void emitAllEnemy()
    {
        foreach (var memberGroup in peopleInHouse)
        {
            for (int i=0 ; i < memberGroup.enemyCount; i++)
            {
                GameObject GO = Instantiate(hostPrefab,whereIsDoor.position,new Quaternion(0,180,0,0));
                GO.transform.SetParent(enemyRoot);
                if (memberGroup.enemyWeapon != null)
                {
                    GO.GetComponent<ComponentHandler>().handlingWeaponManagement.changeWeapon(memberGroup.enemyWeapon);
                }
            }
        }
    }

    [Serializable]
    public struct MemberGroup
    {
        public GameObject enemyPrefab;
        public Weapon enemyWeapon;
        public int enemyCount;
    }

}
