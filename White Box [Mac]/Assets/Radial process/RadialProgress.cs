using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RadialProgress : MonoBehaviour
{
    [SerializeField] Text text;

    [SerializeField] Image image;

    [SerializeField] float speed;

     
    
    void Update()
    {
        if (GameManager.instance.currentHackingValue < 100 && GameManager.instance.startHacking)
        {
            GameManager.instance.currentHackingValue += speed * Time.deltaTime;
            text.text = ((int)GameManager.instance.currentHackingValue).ToString() + "%"; 
        }
        else
        {
            text.text = "Hack";
        }
        image.fillAmount = GameManager.instance.currentHackingValue / 100;

        if (GameManager.instance.currentHackingValue / 100 >= 0.999f)
        {
            GameManager.instance.HackingComplete = true;
            text.text = "Hack Compeleted";
        }
    }
}
