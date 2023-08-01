using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool startHacking;

    public float currentHackingValue;

    public bool HackingComplete;

    public bool controllingRobot;

    public GameObject Robot; 

    public MultipleTargetCamera Multiplecamera; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (controllingRobot)
        {
            Multiplecamera.targets[0] = Robot.transform;
        }
        else
        {
            Multiplecamera.targets[0] = GameObject.FindWithTag("Player").transform; 
        }


    }








}
