using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 15f;
    public float gravity = -35f;
    public float jumpHeight = 3f;
    public float maxNumOfJumps = 2f;
    public float sprintSpeedMultiplier = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask enemyMask;

    Vector3 velocity;
    bool isGrounded;
    bool isOnEnemy;
    float curNumOfJumps;
    bool isSprinting;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(11, 12, true);
        curNumOfJumps = maxNumOfJumps;
        isSprinting = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isOnEnemy = Physics.CheckSphere(groundCheck.position, groundDistance, enemyMask);

        if ((isGrounded||isOnEnemy) && velocity.y < 0) { velocity.y = -2f; }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right*x + transform.forward*z;

        // Sprinting mode: hold
        //if (Input.GetButton("Fire3")) {
        //    move = move * sprintSpeedMultiplier;
        //}

        // Sprinting mode: toggle
        if (Input.GetButtonDown("Fire3")) {
            isSprinting = !isSprinting;
        }
        // Disable sprint while not moving
        if (move == Vector3.zero) { isSprinting = false; }
        
        if (isSprinting) { move = move * sprintSpeedMultiplier; }


        controller.Move(move * speed * Time.deltaTime);

        // Equation for a jump {v = sqrt(h*-2*g)}
        if (Input.GetButtonDown("Jump") && (isGrounded||curNumOfJumps != 0)) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            curNumOfJumps--;
        }

        if (isGrounded && curNumOfJumps != maxNumOfJumps) {
            curNumOfJumps = maxNumOfJumps;
        }

        velocity.y += gravity * Time.deltaTime;

        // Equation for a free fall {delta(y) = 0.5g*t^2} so we need to multiplay by time again 
        controller.Move(velocity * Time.deltaTime);
    }
}
