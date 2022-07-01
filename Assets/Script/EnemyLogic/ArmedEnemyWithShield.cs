using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemyWithShield : ArmedEnemy
{
    [Header("Shield Management")]
    [SerializeField]
    public GameObject shieldPrefab;
    private bool isShieldExist;

    [SerializeField]
    public Transform handPos2;

    private GameObject shieldGO;
    private Shield shieldLogic;

    [Header("Shield UI")]
    [SerializeField]
    private GameObject shieldHealthBarUI;
    private HealthBar shieldHealthBar;

    protected void Awake()
    {
        shieldHealthBar = shieldHealthBarUI.GetComponent<HealthBar>();
    }

    protected override void Start()
    {
        base.Start();
        if (shieldPrefab != null)
        {
            setShield(shieldPrefab);
        }
        else
        {
            isShieldExist = false;
        }
    }

    public override void takeDamage(float damage,HashSet<DamageType> damageType)
    {
        if (!isShieldExist)
        {
            base.takeDamage(damage,damageType);
        }
        else
        {
            shieldLogic.takeDamage(damage,damageType);
            shieldHealthBar.SetHealth(shieldLogic.getCurrentHealth());
            if (shieldLogic.getIsDestroyed())
            {
                isShieldExist = false;
                Destroy(shieldGO);
                shieldLogic = null;
                shieldHealthBarUI.SetActive(false);
            }
        }
    }

    public void setShield(GameObject prefab)
    {
        if (prefab == null)
        {
            return;
        }
        if (shieldGO != null)
        {
            Destroy(shieldGO);
        }
        Debug.Log("do this2");
        shieldPrefab = prefab;

        shieldGO = Instantiate(prefab) as GameObject;
        shieldGO.transform.SetParent(handPos2);
        shieldGO.transform.rotation = objectTransform.rotation;
        shieldLogic = shieldGO.GetComponent<Shield>();
        isShieldExist = true;

        Vector3 distanceToMove = shieldGO.transform.Find("HandlePos").position - handPos2.position;
        shieldGO.transform.position -= distanceToMove;

        shieldHealthBarUI.SetActive(true);
        shieldHealthBar.SetMaxHealth(shieldLogic.getMaxHealth());
    }
}
