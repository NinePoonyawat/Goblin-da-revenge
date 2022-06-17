using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    private float defaultRunSpeed;

    float horizontalMove = 0f;
    bool jump = false;

    void Start()
    {
        defaultRunSpeed = runSpeed;
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
}