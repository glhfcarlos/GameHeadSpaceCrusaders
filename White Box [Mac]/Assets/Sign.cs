using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Swich") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Debug.Log("Player entered with CapsuleCollider2D");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Code for when the player exits the trigger zone can go here
    }
}