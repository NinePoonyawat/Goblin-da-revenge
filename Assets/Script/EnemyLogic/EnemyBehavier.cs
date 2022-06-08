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

    public bool isFacingRight = false;
    public bool isMoving = false;

    void Start()
    {
        StartCoroutine(fleeState());
    }

    void Update()
    {
        if (isMoving) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, - stalkSpeed * Time.deltaTime);
            distance = Vector3.Distance(target.position, transform.position);

            if(isFacingRight && target.position.x > transform.position.x) {
                isFacingRight = false;
                transform.Rotate(0f, 180f, 0f);
            }
            if(!isFacingRight && target.position.x < transform.position.x) {
                isFacingRight = true;
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    IEnumerator fleeState()
    {
        isMoving = true;

        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(fireState());
    }

    IEnumerator fireState()
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
