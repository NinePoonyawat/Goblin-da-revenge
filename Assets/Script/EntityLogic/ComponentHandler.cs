using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentHandler : MonoBehaviour
{
    [SerializeField]
    public Transform characterTransform;
    [SerializeField]
    public CharacterController2D characterController2D;
    [SerializeField]
    public PlayerMovement playerMovement;
}
