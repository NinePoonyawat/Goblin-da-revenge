using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyEdifice : MonoBehaviour,IWaveObstacle
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
    private bool isWaveObstacle = true;

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
                    GO.GetComponent<ArmedEnemy>().changeWeapon(memberGroup.enemyWeapon);
                }
                if (memberGroup.enemyShield != null)
                {
                    GO.GetComponent<ArmedEnemyWithShield>().setShield(memberGroup.enemyShield);
                }
                GameObject.Find("GameLogic").GetComponent<LevelWaveLogic>().addNewWaveObstacle(GO);
                yield return new WaitForSeconds(emitCooldown);
            }
        }
        Debug.Log("end");
        isWaveObstacle = false;
    }

    public bool getIsWaveStacle()
    {
        return isWaveObstacle;
    }

    [Serializable]
    public struct MemberGroup
    {
        public GameObject enemyPrefab;
        public GameObject enemyWeapon;
        public GameObject enemyShield;
        public int enemyCount;
        public bool isBossEnemy;
    }
}
