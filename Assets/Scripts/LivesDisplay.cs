using UnityEngine;
using UnityEngine.UI;

//This should be working but just isnt for some reason.
//MUST FIX!!

public class LivesDisplay : MonoBehaviour
{
    public LivesSystem livesSystem; // Reference to the LivesSystem script
    private Text livesText; // Reference to the Text component

    private void Start()
    {
        // Get a reference to the Text component
        livesText = GetComponent<Text>();
    }

    private void Update()
    {
        // Update the text to display the current number of lives
        if (livesSystem != null)
        {
            livesText.text = "Lives: " + livesSystem.CurrentLives.ToString();
        }
        else
        {
            // Add some debug information or handle the case where livesSystem is null.
            // For example, you can display an error message or set livesText to something like "Lives: N/A".
            Debug.LogError("LivesSystem is not assigned to LivesDisplay.");
        }
    }
}
