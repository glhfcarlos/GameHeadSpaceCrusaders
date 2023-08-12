using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckManager : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public float speed;
    public float delayBeforeStart;
    public GameObject SkillCheckCanvas; 

    Vector3 targetPos;
    private bool isMoving; 
    void Start()
    {
        targetPos = posB.position;
        isMoving = false;

        Invoke("StartSkillCheckMovement", delayBeforeStart); 
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.position;
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        /*if (GameManager.instance.currentHackingValue > 20)
        {
            SkillCheckCanvas.enabled = true;
        }
        else
        {
            SkillCheckCanvas.enabled = false; 
        }*/
    }

    public void CheckskillcheckPos()
    {
        float posXL = -488.15f;
        float posXR = -486.76f; 

        if (transform.localPosition.x >posXL && transform.localPosition.x < posXR)
        {
            Debug.Log("Awesome hit!!!");
            GameManager.instance.currentHackingValue += 10; 
        }
        else
        {
            Debug.Log("Loser you suck!!!");
            GameManager.instance.currentHackingValue -= 30; 
        }

        SkillCheckCanvas.SetActive(false);
        Debug.Log("Turn off"); 
    }




}
