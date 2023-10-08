using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private Animator myAnimation;
    private void Start()
    {
        myAnimation = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            // Send a message to the "Player" object to call a method named "LoseLife"
            col.gameObject.SendMessage("LoseLife");

            //triggers explosion animation
            myAnimation.SetTrigger("ExplosionTrigger");
        }
        
    }
}
