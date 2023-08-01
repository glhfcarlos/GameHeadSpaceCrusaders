using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckManager : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public float speed;
    public float delayBeforeStart;
    //public Canvas SkillCheckCanvas; 

    Vector3 targetPos;
    private bool isMoving; 
    void Start()
    {
        targetPos = posB.position;
        isMoving = false;
        //SkillCheckCanvas.enabled = false;

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
    }

    public void CheckskillcheckPos()
    {
        float posXL = -488.18f;
        float posXR = -486.76f; 

        if (transform.localPosition.x >posXL && transform.localPosition.x < posXR)
        {
            Debug.Log("Awesome hit!!!");
            GameManager.instance.currentHackingValue += 5; 
        }
        else
        {
            Debug.Log("Loser you suck!!!");
            GameManager.instance.currentHackingValue -= 5; 
        }



    }




}
