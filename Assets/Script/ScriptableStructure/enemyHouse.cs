using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHouse : MonoBehaviour
{
    [SerializeField]
    private Transform whereIsDoor;

    [SerializeField]
    private GameObject hostPrefab;

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
            GameObject GO = Instantiate(hostPrefab,whereIsDoor.position,new Quaternion(0,180,0,0));
            GO.transform.SetParent(enemyRoot);
            isHostInTheHouse = false;
            this.enabled = false;
        }
    }

}
