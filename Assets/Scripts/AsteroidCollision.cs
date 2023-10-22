using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private Animator myAnimation;
    [SerializeField] private bool shipInsideCollider = false;
    private void Start()
    {
        myAnimation = GetComponent<Animator>();
        shipInsideCollider = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            //triggers explosion animation
            myAnimation.SetTrigger("ExplosionTrigger");
            shipInsideCollider = true;

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        shipInsideCollider = false;
    }
}
