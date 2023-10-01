using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesSystem : MonoBehaviour
{
    public int startingLives = 3;
    private int currentLives;

    public int CurrentLives // Public property to access the current lives count
    {
        get { return currentLives; }
    }

    private void Start()
    {
        currentLives = startingLives;
    }

    // This function is called when the player loses a life
    public void LoseLife()
    {
        currentLives--;

        // Check if the player has run out of lives
        if (currentLives <= 0)
        {
            // Load the "EndScene" when the player runs out of lives
            SceneManager.LoadScene("End");
        }
    }
}

