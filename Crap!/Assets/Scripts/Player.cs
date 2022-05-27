using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpStrength = 10;
    [SerializeField] private float gravityScale = -20;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool canDoubleJump = true;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool isLanding = false;
    [SerializeField] private Transform _characterModel;
    private Animator _animator;

    private Vector3 direction;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        direction.x = horizontalInput * speed;
        _animator.SetFloat("speed", Mathf.Abs(horizontalInput));

        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

        if (isGrounded)
        {
            direction.y = 0;
            canDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                _animator.SetBool("isJumping", true);
                direction.y = jumpStrength;
            }
        }
        else
        {
            direction.y += gravityScale * Time.deltaTime;
            if (canDoubleJump && Input.GetButtonDown("Jump"))
            {
                direction.y = jumpStrength;
                canDoubleJump = false;
            }
        }
        
        if (horizontalInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, 0));
            _characterModel.rotation = newRotation;
        }
        controller.Move(direction * Time.deltaTime);

    }
}
