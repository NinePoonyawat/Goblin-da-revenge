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
    // Start is called before the first frame update
    void Start()
    {
        goblinToDetected = GameObject.Find("PlayingGoblin").GetComponent<Transform>();
    }

    void Update()
    {
        if(Vector3.Distance(goblinToDetected.position,whereIsDoor.position) <= rangeToDetected && isHostInTheHouse)
        {
            Instantiate(hostPrefab,whereIsDoor.position,whereIsDoor.rotation);
            isHostInTheHouse = false;
        }
    }

}
