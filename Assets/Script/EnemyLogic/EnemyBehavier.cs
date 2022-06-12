using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavier : MonoBehaviour
{
    public float stalkSpeed;

    public float distance;

    private IEnumerator coroutine;
    
    public Rigidbody2D rb;
    [SerializeField] private Transform target;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    public bool isFacingRight = false;
    public bool isMoving = false;
    public bool isForward = false;

    void Start()
    {
        StartCoroutine(aggroState());
    }

    void Update()
    {
        if (isMoving && isForward) {
            rb.velocity = new Vector2(-100 * stalkSpeed * Time.deltaTime, 0f);
            distance = Vector3.Distance(target.position, transform.position);
        }
        if (isMoving && !isForward) {
            rb.velocity = new Vector2(100 * stalkSpeed * Time.deltaTime, 0f);
            distance = Vector3.Distance(target.position, transform.position);
        }
        
        if (isFacingRight && target.position.x > transform.position.x) {
            isFacingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
        if (!isFacingRight && target.position.x < transform.position.x) {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
    }

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
