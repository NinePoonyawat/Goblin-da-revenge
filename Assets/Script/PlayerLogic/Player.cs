using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,ITakeDamageable
{
    [SerializeField]
    [Header("Player Status")]
    private CharacterController2D controller;
    public float runSpeed = 40f;
    private float defaultRunSpeed;
    [SerializeField] private float maxHealth,currentHealth;
    [SerializeField] private HealthBar healthBar;

    public SpriteRenderer sprite;
    public Color defaultColor;

    float horizontalMove = 0f;
    bool jump = false;

    void Start()
    {
        defaultRunSpeed = runSpeed;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime,false,jump);
        jump = false;
    }

    public void setRunSpeed(float runSpeed)
    {
        this.runSpeed = runSpeed;
    }

    public void setDefaultRunSpeed()
    {
        this.runSpeed = defaultRunSpeed;
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
        GameObject.Find("GameLogic").GetComponent<LevelGameLogic>().gameLoss();
    }

    public IEnumerator flashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = defaultColor;
    }
}
