using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyBehavior : MonoBehaviour
{
    [SerializeField] SwitchBehaviour _switchBehaviour;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Swich")) 
        {
            _switchBehaviour.DoorLockedStatus();
            Destroy (gameObject); 
           
        }
    }
}
