using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float setTime = 1f; // Initial countdown time in seconds
    private float currentTime;

    private void Start()
    {
        //on start sets the current time of the countdown to the set countdown time. 
        currentTime = setTime;
    }

    private void Update()
    {
        // Update the timer and display it
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("F1");

        // Check if the timer has reached zero
        //if (currentTime <= 0)
        //{
        //    // Load the next scene (replace "YourNextSceneName" with your actual scene name)
        //    SceneManager.LoadScene(2);
        //}
    }
}
