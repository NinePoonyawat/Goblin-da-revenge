using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavier : MonoBehaviour
{
    public float stalkSpeed;

    public float distance;

    private IEnumerator coroutine;
    
    [SerializeField] private Transform target;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private Transform mainTransform;

    public bool isFacingRight = false;
    public bool isMoving = false;
    public bool isForward = false;

    void Start()
    {
        target = GameObject.Find("PlayingGoblin").transform.GetComponent<Transform>();
        mainTransform = this.transform.parent.transform;

        if (!isFacingRight && target.transform.position.x > transform.position.x)
        {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (isFacingRight && target.transform.position.x < transform.position.x)
        {
            isFacingRight = false;
            transform.Rotate(0f, 180f ,0f);
        }
        isForward = true;
        isMoving = true;
        //StartCoroutine(aggroState());
    }

    void Update()
    {
        if (target == null)
            return;
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
        
        if (isFacingRight && target.position.x < transform.position.x) {
            isFacingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
        if (!isFacingRight && target.position.x > transform.position.x) {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void moveForward()
    {
        mainTransform.position = new Vector2(mainTransform.position.x + Time.deltaTime * stalkSpeed,
             mainTransform.position.y);
        distance = Vector3.Distance(target.position, transform.position);
    }

    public void moveBackward()
    {
        mainTransform.position = new Vector2(mainTransform.position.x - Time.deltaTime * stalkSpeed,
             mainTransform.position.y);
        distance = Vector3.Distance(target.position, transform.position);
    }

    // public void updateAfterAttack()
    // {
    //     StartCoroutine(fleeState);
    // }

    IEnumerator fleeState()
    {
        isMoving = true;
        isForward = false;
        
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(aggroState());
    }

    IEnumerator aggroState()
    {
        isMoving = true;
        isForward = true;

        yield return null;
    }

    IEnumerator attackingState()
    {
        isMoving = false;
        Shoot();
        yield return new WaitForSeconds(0.2f);
        Shoot();

        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(fleeState());
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
