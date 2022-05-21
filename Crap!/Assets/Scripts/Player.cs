using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    private Vector3 direction;
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpStrength = 10;
    [SerializeField] private float gravityScale = -20;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool canDoubleJump = true;
    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        direction.x = horizontalInput * speed;

        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        direction.y += gravityScale * Time.deltaTime;

        if (isGrounded)
        {
            canDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpStrength;
            }
        }
        else
        {
            if (canDoubleJump && Input.GetButtonDown("Jump"))
            {
                direction.y = jumpStrength;
                canDoubleJump = false;
            }
        }
        controller.Move(direction * Time.deltaTime);

    }
}
