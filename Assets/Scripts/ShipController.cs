using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 3;
    [SerializeField] private float rotationSpeed = 3;
    private Rigidbody2D rb;
    private bool isPackageGone = false; 
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isPackageGone = false;
        
    }
    private void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        ThrustForward(yAxis);
        Rotate(transform, xAxis * -rotationSpeed);
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Package"))
        {
            Destroy(other.gameObject);
        }
        isPackageGone = true; 
    }
}
