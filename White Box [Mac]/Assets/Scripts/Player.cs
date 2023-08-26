using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private float groundDist = 100f;
    AudioSource audioS;
    public AudioClip jump;

    public bool isRobot;
    public bool Grounded;
    public Transform groundCheck;
    public Animator Animation;
    public bool MovingUpandDown; 

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

        if (isRobot && hasJumped)
        {
            AnimatorStateInfo info = Animation.GetCurrentAnimatorStateInfo(0);
            if ( info.normalizedTime > 1.0f && info.IsName("up"))
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


    private void MoveSideways()
    {
        if ((!isRobot && !GameManager.instance.controllingRobot))
        {
            
            moveInput = UserInput.instance.moveInput.x;

            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            Animation.SetFloat("Moving", Mathf.Abs(moveInput));

            if (moveInput > 0.1f)
            {
                
                // Face right
                Animation.transform.localScale = new Vector3(Mathf.Abs(Animation.transform.localScale.x), Animation.transform.localScale.y, Animation.transform.localScale.z);
            }
            else if (moveInput < -0.1f)
            {
                // Face left
                Animation.transform.localScale = new Vector3(-Mathf.Abs(Animation.transform.localScale.x), Animation.transform.localScale.y, Animation.transform.localScale.z);
            }
        }
        if ((isRobot && GameManager.instance.controllingRobot && GameManager.instance.Robot == gameObject))
        {
            moveInput = UserInput.instance.moveInput.x;

            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            Animation.SetFloat("Moving", Mathf.Abs(moveInput));

            // Same flipping logic for robot if needed
        }
        
    
    }

    private void MovingRobotUpandDowm()
{
        if ((!isRobot && !GameManager.instance.controllingRobot))
        { 
            moveInput = UserInput.instance.moveInput.y;

            rb.velocity = new Vector2(0, moveInput * moveSpeed);
            Animation.SetFloat("Moving", Mathf.Abs(moveInput));

        }
        if ((isRobot && GameManager.instance.controllingRobot && GameManager.instance.Robot == gameObject))
        {

            moveInput = UserInput.instance.moveInput.y;

            rb.velocity = new Vector2(0, moveInput * moveSpeed);
            Animation.SetFloat("Moving", Mathf.Abs(moveInput));

            // Same flipping logic for robot if needed
        }
        
    }


    private void Jump()
    {
       
        if (Grounded && UserInput.instance.controls.Movement.Jump.triggered && !hasJumped)
        {
            if (GameManager.instance.controllingRobot && isRobot)
            {
                Animation.SetBool("up", true);
                hasJumped = true;
            }
            else if(!isRobot)
            {
                audioS.clip = jump;
                audioS.Play();
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                hasJumped = true;

                Animation.SetTrigger("takeoff");
                Animation.SetBool("isjumping", true);
            }
        }

    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && hasJumped)
        {
            hasJumped = false;
            Animation.SetBool("isjumping", false);

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDist);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            collision.transform.parent = this.transform;
        }
        if ((!isRobot && !GameManager.instance.controllingRobot) || (isRobot && GameManager.instance.controllingRobot))
        {
            //collision.transform.parent = this.transform;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }

}
