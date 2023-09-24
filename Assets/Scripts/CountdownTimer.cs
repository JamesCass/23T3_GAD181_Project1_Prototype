using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 10f; // Initial countdown time in seconds
    private float currentTime;

    private void Start()
    {
        currentTime = countdownTime;
    }

    private void Update()
    {
        // Update the timer and display it
        currentTime -= Time.deltaTime;
        timerText.text = currentTime.ToString("F1");

        // Check if the timer has reached zero
        if (currentTime <= 0)
        {
            // Load the next scene (replace "YourNextSceneName" with your actual scene name)
            SceneManager.LoadScene(2);
        }
    }
}
