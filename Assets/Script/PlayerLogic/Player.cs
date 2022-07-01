using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,ITakeDamageable
{
    [SerializeField]
    [Header("Player Status")]
    public CharacterController2D controller;
    public float runSpeed = 40f;
    private float defaultRunSpeed;
    [SerializeField] private float maxHealth;
    public float currentHealth;
    [SerializeField] private HealthBar healthBar;

    public SpriteRenderer sprite;
    public Color defaultColor;

    float horizontalMove = 0f;
    bool jump = false;

    [Header("Weapon Management")]
    [SerializeField]
    public WeaponInventory weaponInventory;
    private bool isWeaponInHand;

    private float changeWeaponCooldownCount;
    private float changeWeaponCooldown = 10f;
    private bool isOnChangeWeaponCooldown = false;

    [SerializeField]
    public Transform handPos;

    private GameObject GO;
    private WeaponLogic weaponLogic;

    protected float attackCooldownCount = .0f;
    protected bool isOnAttackCooldown = false;

    public string entityToAttack;

    protected Transform mainTransform;

    void Awake()
    {
        defaultRunSpeed = runSpeed;

        currentHealth = maxHealth;
        defaultColor = sprite.color;
    }

    void Start()
    {

        healthBar.SetMaxHealth(maxHealth);

        entityToAttack = "Enemy";
        mainTransform = gameObject.transform;
        setWeapon(weaponInventory.getWeapon1());
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("NormalAttack") && !isOnAttackCooldown)
        {
            weaponLogic.attack();
            attackCooldownCount = GO.GetComponent<WeaponLogic>().getCooldownTime();
            isOnAttackCooldown = true;
        }
        if (Input.GetButtonDown("SelectWeapon1") && !isOnChangeWeaponCooldown)
        {
            if (weaponInventory.getWeapon1() == null)
                return;
            changeWeapon(weaponInventory.getWeapon1());
            isOnChangeWeaponCooldown = true;
            changeWeaponCooldownCount = changeWeaponCooldown;
        }
        if (Input.GetButtonDown("SelectWeapon2") && !isOnChangeWeaponCooldown)
        {
            if (weaponInventory.getWeapon2() == null)
                return;
            changeWeapon(weaponInventory.getWeapon2());
            isOnChangeWeaponCooldown = true;
            changeWeaponCooldownCount = changeWeaponCooldown;
        }
        if (Input.GetButtonDown("SelectWeapon3") && !isOnChangeWeaponCooldown)
        {
            if (weaponInventory.getWeapon3() == null)
                return;
            changeWeapon(weaponInventory.getWeapon3());
            isOnChangeWeaponCooldown = true;
            changeWeaponCooldownCount = changeWeaponCooldown;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime,false,jump);
        jump = false;

        attackFixedUpdate();
        changeWeaponFixedUpdate();
    }

    void attackFixedUpdate()
    {
        if (!isWeaponInHand)
            return;
        if (attackCooldownCount > 0)
        {
            attackCooldownCount -= Time.deltaTime;
        }
        if (attackCooldownCount <= 0 && isOnAttackCooldown)
        {
            isOnAttackCooldown = false;
        }
    }

    void changeWeaponFixedUpdate()
    {
        if (!isOnChangeWeaponCooldown)
            return;
        if (changeWeaponCooldownCount > 0)
        {
            changeWeaponCooldownCount -= Time.deltaTime;
        }
        if (changeWeaponCooldownCount <= 0)
        {
            isOnChangeWeaponCooldown = false;
        }
    }

    public void setRunSpeed(float runSpeed)
    {
        this.runSpeed = runSpeed;
    }

    public void setDefaultRunSpeed()
    {
        this.runSpeed = defaultRunSpeed;
    }

    public virtual void takeDamage(float damage,HashSet<DamageType> damageType)
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

    public virtual void setWeapon(GameObject weaponPrefab)
    {
        if (weaponPrefab == null)
        {
            return;
        }
        // weaponInHand = newWeaponInHand;
        isWeaponInHand = true;

        GO = Instantiate(weaponPrefab) as GameObject;
        GO.transform.SetParent(handPos);
        Vector3 distanceToMove = GO.transform.Find("HandlePos").position - handPos.position;
        GO.transform.position -= distanceToMove;
        //GO.transform.Find("HandlePos").position = handPos.position;

        GO.transform.rotation = mainTransform.rotation;
        GO.GetComponent<WeaponLogic>().entityToAttack = "Enemy";

        weaponLogic = GO.GetComponent<WeaponLogic>();
    }

    public void releaseCurrentWeapon()
    {
        try
        {
            Destroy(GO);
        }
        catch (System.Exception)
        {
        }
        isWeaponInHand = false;
        weaponLogic = null;
    }

    public void changeWeapon(GameObject weaponPrefab)
    {
        releaseCurrentWeapon();
        setWeapon(weaponPrefab);
    }
}
