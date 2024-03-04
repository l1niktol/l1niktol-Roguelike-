using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float boostMultiplier = 2;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    
   
    void Update()
    {
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
      

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance );
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

       Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            
            speed *= boostMultiplier;
        }
        else
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= boostMultiplier;
            
        }
        if (speed < 12f || speed > speed * boostMultiplier)
            speed = 12f;






    }

   
}
