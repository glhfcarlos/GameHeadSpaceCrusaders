using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.5f;

    AudioSource audioS;
    public AudioClip jump;

    public bool Grounded;
    public Transform groundCheck;
    public bool MovingUpandDown;
    public Animator Animation;
    
    private bool hasJumped = false;
    private Rigidbody2D rb;
    private float moveInput;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if ( GameManager.instance.Robot == gameObject && GameManager.instance.controllingRobot && GameManager.instance.HackingComplete)
        {
            if (!MovingUpandDown)
            {
                MoveSideways();
            }
            else
            {
                MovingRobotUpandDowm();
            }

            Jump();
            Grounded = Physics2D.Raycast(transform.position, groundCheck.position, LayerMask.GetMask("Ground"));


            if (hasJumped)
            {
                AnimatorStateInfo info = Animation.GetCurrentAnimatorStateInfo(0);
                if (info.normalizedTime > 1.0f && info.IsName("up"))
                {
                    Animation.SetBool("up", false);
                    hasJumped = false;
                }
                else
                {
                    Debug.Log(string.Format("Animation State length: {0}, Animation State Time: {1}", info.length, info.normalizedTime));
                }

            }
        }
    }

    private void MoveSideways() //for robot script as well 
    {
        if ( GameManager.instance.controllingRobot && GameManager.instance.Robot == gameObject)
        {
            moveInput = UserInput.instance.moveInput.x;
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            Animation.SetFloat("Moving", Mathf.Abs(moveInput));

            // Same flipping logic for robot if needed
        }
    } // end 


    private void Jump()
    {

        if (Grounded && UserInput.instance.controls.Movement.Jump.triggered && !hasJumped)
        {
            if (GameManager.instance.controllingRobot )
            {
                Animation.SetBool("up", true);
                hasJumped = true;
            }
        }

    }

    private void MovingRobotUpandDowm() //robot script 
    {
        if (( GameManager.instance.controllingRobot && GameManager.instance.Robot == gameObject))
        {

            moveInput = UserInput.instance.moveInput.y;

            rb.velocity = new Vector2(0, moveInput * moveSpeed);
            Animation.SetFloat("Moving", Mathf.Abs(moveInput));

            // Same flipping logic for robot if needed
        }

    }//end 

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && hasJumped)
        {
            hasJumped = false;
            Animation.SetBool("isjumping", false);

        }
    }

}
