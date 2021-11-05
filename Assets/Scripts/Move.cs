using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Move : MonoBehaviour
{

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector2 moveDirection = Vector2.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
     
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
    }