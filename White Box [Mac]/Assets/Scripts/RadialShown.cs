using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialShown : MonoBehaviour
{

    public GameObject RadialObject;
    public GameObject Robot;
    public SkillCheckManager SkillCheck; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RadialObject.SetActive(true);
            GameManager.instance.currentHackingValue = 0f;
            GameManager.instance.Robot = Robot;
            collision.transform.SetParent(Robot.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RadialObject.SetActive(false);
            GameManager.instance.currentHackingValue = 0f;
            collision.transform.SetParent(null);
        }
    }




}
