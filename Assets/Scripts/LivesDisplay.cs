using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public LivesSystem livesSystem; // Reference to the LivesSystem script
    private TextMeshProUGUI livesText; // Reference to the Text component

    private void Start()
    {
        // Get a reference to the Text component
        livesText = GetComponent<TextMeshProUGUI>();

        if (livesText == null)
        {
            Debug.LogError("Text component not found on this GameObject.");
        }

        // Check if livesSystem is assigned in the Inspector
        if (livesSystem == null)
        {
            Debug.LogError("LivesSystem is not assigned in the Inspector.");
        }
    }

    private void Update()
    {
        // Check if livesSystem and livesText exist
        if (livesSystem != null && livesText != null)
        {
            livesText.text = "Lives: " + livesSystem.CurrentLives.ToString();
        }
        else
        {
            Debug.LogError("LivesSystem or Text component is not assigned.");
        }
    }
}
