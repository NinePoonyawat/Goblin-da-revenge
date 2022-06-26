using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour,ITakeDamageable
{
    [Header("Enemy Data")]
    [SerializeField] private string enemyName;

    [Header("Enemy Status")]
    public float stalkSpeed;
    public float visionDistance;
    [SerializeField] private float maxHealth,currentHealth;
    private SpriteRenderer sprite;
    private Color defaultColor;
    public HealthBar healthBar;

    public float distance;

    protected IEnumerator coroutine;
    
    protected GameObject targetToDetected;
    protected Transform targetTransform;

    protected Transform mainTransform;

    public bool isFacingRight = false;
    public bool isMoving = false;
    public bool isForward = false;
    protected bool isRotatable = true;

    protected EnemyBehavior enemyBehavior = EnemyBehavior.FaceTarget;
    protected float recommendedRange = 0.1f;

    protected string entityToAttack;

    protected virtual void Start()
    {
        entityToAttack = "Player";
        targetToDetected = GameObject.Find("PlayingGoblin");
        enemyBehavior =EnemyBehavior.FaceTarget;
        targetTransform = targetToDetected.transform;
        mainTransform = this.transform.parent.transform;

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

        currentHealth = maxHealth;
        defaultColor = sprite.color;
        //StartCoroutine(aggroState());
    }

    protected virtual void Update()
    {
        if (targetToDetected == null)
            return;
        updateMoving();
        float xDistance = transform.position.x - targetTransform.position.x;
        UpdateRotating(xDistance);
    }

    protected virtual void updateMoving()
    {
        float distance = Math.Abs(targetTransform.position.x - transform.position.x);
        
        //TEST | Vision Check
        if (distance > visionDistance) return;

        if (enemyBehavior == EnemyBehavior.FaceTarget)
        {
            if (distance > recommendedRange / 2 )
            {
                isMoving = true;
                isForward = true;
                move();
            }
        }
        else if (enemyBehavior == EnemyBehavior.NibbleTarget)
        {
            if (distance < recommendedRange / 2)
            {
                isMoving = true;
                isForward = false;
                move();
            }
            else if (distance > recommendedRange)
            {
                isMoving = true;
                isForward = true;
                move();
            }
        }
    }

    protected virtual void move()
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
                moveForward();
            }
        }
    }

    protected virtual void UpdateRotating(float xDistance)
    {
        if (isFacingRight && xDistance > 0 & isRotatable) {
            isFacingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
        if (!isFacingRight && xDistance < 0 & isRotatable) {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
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

    public virtual void takeDamage(float damage,DamageType damageType)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            die();
        }

        StartCoroutine(flashRed());

        healthBar.SetHealth(currentHealth);
    }

    public virtual void die()
    {
        Destroy(gameObject);
    }

    public IEnumerator flashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = defaultColor;
    }
}

public enum EnemyBehavior
{
    FaceTarget,
    NibbleTarget,
}