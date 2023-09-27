using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidController : MonoBehaviour
{
    //When the game object tagged player collides the scene is reloaded as a respawn system.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
