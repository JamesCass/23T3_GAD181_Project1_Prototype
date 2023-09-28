using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


//Working but not really, going through the bottom part of the map works however it doesn't recognize the rest of the positioning correctly not sure why.
//My guess it that it has to do with the 0's in the if satements but this is yet to be fully tested, I will come back to this. However for the time being leave this script unattached

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrap : MonoBehaviour
{

    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the screen position of object in Pixels
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);


        //Get the right & left side of the screen in world units
        float rightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;

        float topOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

        //If player is moving through the left side of the screen
        if (screenPos.x <= 0 && myRigidBody.velocity.x < 0)
        {
            transform.position = new Vector2(rightSideOfScreenInWorld, transform.position.y);
        }

        //If player is moving through the right side of the screen
        else if (screenPos.x <= Screen.width && myRigidBody.velocity.x > 0)
        {
            transform.position = new Vector2(leftSideOfScreenInWorld, transform.position.y);
        }

        //If the player is moving through the top of the screen
        else if (screenPos.x <= Screen.height && myRigidBody.velocity.y > 0)
        {
            transform.position = new Vector2(transform.position.x, bottomOfScreenInWorld);
        }

        //If player is moving through the bottom of the screen
        else if (screenPos.y <= 0 && myRigidBody.velocity.y < 0)
        {
            transform.position = new Vector2(transform.position.x, topOfScreenInWorld);
        }
    }
}