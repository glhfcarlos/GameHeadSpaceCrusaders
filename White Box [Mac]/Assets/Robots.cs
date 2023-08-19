using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robots : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float jumpForce = 50f;
    public Animator Animation;

    public bool isRobot;
    public bool Grounded;
    public Transform groundCheck;

    private bool hasJumped = false;
    private float moveInput;
    private Rigidbody2D rb;
    public bool MovingUpandDown;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!MovingUpandDown)
        {
            MoveSideways();
        }
        else
        {
            MovingRobotUpandDown();
        }
        Jump();
        Grounded = Physics2D.Raycast(transform.position, groundCheck.position, LayerMask.GetMask("Ground"));
    }

    private void MoveSideways()
    {
        if ((isRobot && GameManager.instance.controllingRobot && GameManager.instance.Robot == gameObject))
        {
            moveInput = UserInput.instance.moveInput.x;

            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            Animation.SetFloat("Moving", Mathf.Abs(moveInput));

            // Same flipping logic for robot if needed
        }
    }
    private void MovingRobotUpandDown()
    {
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
            if (isRobot && GameManager.instance.controllingRobot)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                hasJumped = true;
                //Animation.SetTrigger("takeoff");
                Animation.SetBool("up", true);
            }
            Animation.SetTrigger("takeoff");
            Animation.SetBool("isjumping", true);
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

}


