using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 3;
    [SerializeField] private float thrustForce = 1;
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject package;

    private Vector3 initialPosition; // Store the initial position

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Store the initial position on start
    }

    private void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        ThrustForward(yAxis);
        Rotate(transform, xAxis * -rotationSpeed * Time.deltaTime);

        // Check if the "r" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPosition(); // Call the function to reset the position
        }
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount * thrustForce * Time.deltaTime;

        rb.AddForce(force);
    }

    //private void Boost()
    //{
     //   if(Input.GetKeyDown(KeyCode.Space))
     //   {
     //       Vector2 force = transform.up * 3 * thrustForce * Time.deltaTime;
     //       rb.AddForce(force);
     //   }
   // }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    // Function to reset the player's position to the initial position
    private void ResetPosition()
    {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero; // Reset velocity
        rb.angularVelocity = 0f;    // Reset angular velocity
    }

    //When the game object with the tag "Package" is collided with, the object is destroyed. 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Package"))
        {
            package.SetActive(false);
        }
    }
}

