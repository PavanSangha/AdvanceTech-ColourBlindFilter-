using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    //public Rigidbody Player;
    public float Jump;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale; 

    void Start()
    {
       // Player = GetComponent<Rigidbody>();

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
       // Player.velocity = new Vector3 (Input.GetAxis("Horizontal") * moveSpeed, Player.velocity.y,Input.GetAxis("Vertical") * moveSpeed);


        if (Input.GetButtonDown("Jump"))
        {
          //  Player.velocity = new Vector3(Player.velocity.x, Jump, Player.velocity.z);
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        if (controller.isGrounded)
        {

            moveDirection.y= 0f;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = Jump;

            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
 
        controller.Move(moveDirection * Time .deltaTime);
    }
}
