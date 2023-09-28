using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private float maxThrust;
    [SerializeField] private float maxTorque;
    [SerializeField] private Rigidbody2D rb;

   
    private void Start()
    {
        //On start moves the placed asteroids randomy in any direction with spin based on a set value in the serialized field. 
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }
    //When the game object tagged player collides the scene is reloaded as a respawn system.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            // Send a message to the "Player" object to call a method named "LoseLife"
            col.gameObject.SendMessage("LoseLife");
        }
    }
}
