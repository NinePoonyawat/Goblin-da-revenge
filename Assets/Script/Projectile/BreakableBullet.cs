using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBullet : ThrowingBullet
{
    [SerializeField]
    private GameObject objectAfterBreakingPrefab;

    // Start is called before the first frame update
    protected override void hitGroundEvent()
    {
        Instantiate(objectAfterBreakingPrefab,transform.position,new Quaternion(0,0,0,0));
        Destroy(gameObject);
    }
}
