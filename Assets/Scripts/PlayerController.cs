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

    public Animator anim;

    public float knockBackForce;
    public float knockBackTime;
    public float knockBackCounter;

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

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        if (knockBackCounter <= 0)
        {



            float ystore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = ystore;

            if (controller.isGrounded)
            {

                moveDirection.y = 0f;

                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = Jump;

                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
 
        controller.Move(moveDirection * Time .deltaTime);

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    }

    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        direction = new Vector3(1f, 1f, 1f);

        moveDirection = direction * knockBackForce;
        
    }
}
