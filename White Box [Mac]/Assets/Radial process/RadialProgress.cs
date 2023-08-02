using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RadialProgress : MonoBehaviour
{
    [SerializeField] Text text;

    [SerializeField] Image image;

    [SerializeField] float speed;

    public GameObject skillCheckUI;


    private void Start()
    {
        skillCheckUI.SetActive(false);
    }

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

        if (GameManager.instance.currentHackingValue >= 20f)
        {
            skillCheckUI.SetActive(true);
        }
        
        if (GameManager.instance.currentHackingValue / 100 >= 0.999f)
        {
            GameManager.instance.HackingComplete = true;
            text.text = "Hack Compeleted";
            skillCheckUI.SetActive(false);
        }
    }
}
