using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player MainPlayer; 

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
        if (controllingRobot)
        {
            Multiplecamera.targets[0] = Robot.transform;

            // 激活 BoxVolume 游戏对象
            if (UserInput.instance != null && UserInput.instance.boxVolume != null)
            {
                UserInput.instance.boxVolume.SetActive(true);
            }
        }
        else
        {
            Multiplecamera.targets[0] = GameObject.FindWithTag("Player").transform;

            // 隐藏 BoxVolume 游戏对象
            if (UserInput.instance != null && UserInput.instance.boxVolume != null)
            {
                UserInput.instance.boxVolume.SetActive(false);
            }
        }


    }








}
