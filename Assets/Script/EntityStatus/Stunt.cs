using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunt : MonoBehaviour
{
    private Enemy stuntedEnemy;

    public void perform(float stuntTime)
    {
        stuntedEnemy = gameObject.GetComponent<Enemy>();
        stuntedEnemy.transform.Find("StunIcon").gameObject.SetActive(true);

        StartCoroutine(stunt(stuntTime));
    }

    public IEnumerator stunt(float stuntTime)
    {
        stuntedEnemy.setIsMoving(false);
        stuntedEnemy.setIsRotatable(false);
        stuntedEnemy.setIsAttackable(false);

        yield return new WaitForSeconds(stuntTime);
        
        stuntedEnemy.setIsMoving(true);
        stuntedEnemy.setIsRotatable(true);
        stuntedEnemy.setIsAttackable(true);
        stuntedEnemy.transform.Find("StunIcon").gameObject.SetActive(false);
        Destroy(this);
    }
}
