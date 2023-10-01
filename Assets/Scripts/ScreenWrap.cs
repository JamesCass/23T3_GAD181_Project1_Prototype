using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrap : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Camera mainCamera;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        // Get the size of the object (assuming it has a BoxCollider2D)
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            objectWidth = collider.size.x;
            objectHeight = collider.size.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get the screen position of the object in pixels
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

        // Get the screen dimensions in pixels
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Check if the object is out of the screen bounds
        if (screenPos.x < 0 - objectWidth / 2)
        {
            // Wrap to the right side of the screen
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(screenWidth + objectWidth / 2, screenPos.y, screenPos.z));
        }
        else if (screenPos.x > screenWidth + objectWidth / 2)
        {
            // Wrap to the left side of the screen
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(0 - objectWidth / 2, screenPos.y, screenPos.z));
        }

        if (screenPos.y < 0 - objectHeight / 2)
        {
            // Wrap to the top side of the screen
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenHeight + objectHeight / 2, screenPos.z));
        }
        else if (screenPos.y > screenHeight + objectHeight / 2)
        {
            // Wrap to the bottom side of the screen
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, 0 - objectHeight / 2, screenPos.z));
        }
    }
}
