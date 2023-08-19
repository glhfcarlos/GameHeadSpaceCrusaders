using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    public List<GameObject> HackedRobots = new List<GameObject>();

    [HideInInspector] public Controls controls;
    [HideInInspector] public Vector2 moveInput;
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        controls = new Controls();

        controls.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Hack.Hacking.performed += ctx => StartHacking();
        controls.Hack.Hacking.canceled += ctx => StartHacking();
        controls.Swap.Swap.performed += ctx => SwapCharacter();
        controls.SkillCheckAction.SkillCheckAction.performed += ctx => SkillCheck();  
    }

    private void OnEnable()
    {
        controls.Enable();
    }


    private void OnDisable()
    {
        controls.Disable(); 
    }

    private void StartHacking()
    {
        if (controls.Hack.Hacking.IsPressed())
        {
            GameManager.instance.startHacking = true;
            GameManager.instance.controllingRobot = false;
        }
        else
        {
            GameManager.instance.startHacking = false;
            GameManager.instance.currentHackingValue = 0f;
        }
        
    }

    private void EndHacking()
    {
     
        GameManager.instance.startHacking = false;
        GameManager.instance.currentHackingValue = 0f;

    }

    private void SwapCharacter()
    {
        if (GameManager.instance.HackingComplete && GameManager.instance.controllingRobot)
        {
            GameManager.instance.controllingRobot = false;
            GameManager.instance.MainPlayer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        else if (GameManager.instance.HackingComplete && !GameManager.instance.controllingRobot) 
        {
            GameManager.instance.controllingRobot = true;
            GameManager.instance.MainPlayer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }


    private void SkillCheck()
    {
        Debug.Log("Hit!!!");
        FindObjectOfType<SkillCheckManager>().CheckskillcheckPos(); 
    }








}

