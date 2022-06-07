using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;

    private bool isJump;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJump = false;
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = .0f;
        if(!isJump)
        {
            y = Input.GetAxis("Jump");
            isJump = true;
        }
        movement = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        movePlayer(movement);
    }

    void movePlayer(Vector2 direction)
    {
        rb.velocity = direction*speed;
    }
}
