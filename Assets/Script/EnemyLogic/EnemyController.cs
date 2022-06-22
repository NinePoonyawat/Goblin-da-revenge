using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public float stalkSpeed;

    public float distance;

    protected IEnumerator coroutine;
    
    protected GameObject targetToDetected;
    protected Transform targetTransform;

    protected Transform mainTransform;
    protected Transform thisObjectTransform;

    public bool isFacingRight = false;
    public bool isMoving = false;
    public bool isForward = false;

    protected string entityToAttack;

    protected virtual void Start()
    {
        entityToAttack = "Player";
        targetToDetected = GameObject.Find("PlayingGoblin");
        targetTransform = targetToDetected.transform;
        mainTransform = this.transform.parent.transform;
        thisObjectTransform = this.transform;

        if (!isFacingRight && targetTransform.position.x > transform.position.x)
        {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (isFacingRight && targetTransform.position.x < transform.position.x)
        {
            isFacingRight = false;
            transform.Rotate(0f, 180f ,0f);
        }
        isForward = true;
        isMoving = true;
        //StartCoroutine(aggroState());
    }

    protected virtual void Update()
    {
        if (targetToDetected == null)
            return;
        float xDistance = transform.position.x - targetTransform.position.x;
        if (Math.Abs(targetTransform.position.x - transform.position.x) > 0.1)
        {
            updateMoving();
        }
        if (isFacingRight && xDistance > 0) {
            isFacingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
        if (!isFacingRight && xDistance < 0) {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void updateMoving()
    {
        if (isMoving && isForward) {
            if (isFacingRight)
            {
                moveForward();
            }
            else
            {
                moveBackward();
            }
        }
        if (isMoving && !isForward) {
            if (isFacingRight)
            {
                moveBackward();
            }
            else
            {
                moveBackward();
            }
        }
    }

    public void moveForward()
    {
        mainTransform.position = new Vector2(mainTransform.position.x + Time.deltaTime * stalkSpeed,
             mainTransform.position.y);
        distance = Vector3.Distance(targetTransform.position, transform.position);
    }

    public void moveBackward()
    {
        mainTransform.position = new Vector2(mainTransform.position.x - Time.deltaTime * stalkSpeed,
             mainTransform.position.y);
        distance = Vector3.Distance(targetTransform.position, transform.position);
    }

    // public void updateAfterAttack()
    // {
    //     StartCoroutine(fleeState);
    // }
}
