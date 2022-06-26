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
    [SerializeField] private float maxHealth;
    public float currentHealth;
    [SerializeField] private HealthBar healthBar;

    public SpriteRenderer sprite;
    public Color defaultColor;

    float horizontalMove = 0f;
    bool jump = false;

    public ComponentHandler allComponent;

    [Header("Weapon Management")]
    [SerializeField]
    public GameObject weaponPrefab;
    private bool isWeaponInHand;

    [SerializeField]
    public Transform handPos;

    private GameObject GO;
    private WeaponLogic weaponLogic;

    protected float attackCooldownCount = .0f;
    protected bool isOnAttackCooldown = false;

    public string entityToAttack;

    protected Transform mainTransform;

    void Start()
    {
        defaultRunSpeed = runSpeed;

        currentHealth = maxHealth;
        defaultColor = sprite.color;

        healthBar.SetMaxHealth(maxHealth);

        entityToAttack = "Enemy";
        mainTransform = gameObject.transform;
        if (weaponPrefab == null)
        {
            isWeaponInHand = false;
            return;
        }
        setWeapon(weaponPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isOnAttackCooldown)
        {
            weaponLogic.attack();
            attackCooldownCount = weaponPrefab.GetComponent<WeaponLogic>().getCooldownTime();
            isOnAttackCooldown = true;
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime,false,jump);
        jump = false;

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

    public virtual void setWeapon(GameObject weaponPrefab)
    {
        if (weaponPrefab == null)
        {
            return;
        }
        // weaponInHand = newWeaponInHand;
        isWeaponInHand = true;
        // gameObject.GetComponent<SpriteRenderer>().sprite = newWeaponInHand.image;
        // gameObject.transform.localScale = new Vector3(newWeaponInHand.size, newWeaponInHand.size, 1);
        // gameObject.transform.localPosition = newWeaponInHand.pickPosition;

        GameObject GO = Instantiate(weaponPrefab) as GameObject;
        GO.transform.SetParent(handPos);
        Vector3 distanceToMove = GO.transform.Find("HandlePos").position - handPos.position;
        GO.transform.position -= distanceToMove;
        //GO.transform.Find("HandlePos").position = handPos.position;

        GO.transform.rotation = mainTransform.rotation;
        GO.GetComponent<WeaponLogic>().entityToAttack = "Enemy";
        // if (gameObject.transform.parent.parent.gameObject.GetComponent<SpriteRenderer>().flipX)
        // {
        //     Debug.Log("do this line");
        //     GO.transform.Rotate(0, 180, 0);
        // }

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
        weaponPrefab = null;
        weaponLogic = null;
    }

    public void changeWeapon(GameObject weaponPrefab)
    {
        releaseCurrentWeapon();
        setWeapon(weaponPrefab);
    }
}
