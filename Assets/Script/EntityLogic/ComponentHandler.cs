using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentHandler : MonoBehaviour
{
    [SerializeField]
    public Transform characterTransform;
    [SerializeField]
    public HandlingWeaponManagement handlingWeaponManagement;
    [SerializeField]
    public CharacterController2D characterController2D;
    [SerializeField]
    public PlayerMovement playerMovement;

    private Vector3 thisPosition,previusPosition,deltaPosition;

    void Start()
    {
        try
        {
            thisPosition = characterTransform.position;
        }
        catch (System.Exception)
        {
        }
    }

    void FixedUpdate()
    {
        try
        {
            previusPosition = thisPosition;
        thisPosition = characterTransform.position;
        deltaPosition = thisPosition - previusPosition;
        }
        catch (System.Exception)
        {
        }
    }

    public bool hasMove()
    {
        return deltaPosition != Vector3.zero;
    }

    public bool hasXMove()
    {
        return deltaPosition.x != 0;
    }

    public bool hasYMove()
    {
        return deltaPosition.y != 0;
    }
}
