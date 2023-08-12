using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            die();
        }
    }

    private void die()
    {
       
        rb.bodyType = RigidbodyType2D.Static;
        anim.Play("die");
    }
    public void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

