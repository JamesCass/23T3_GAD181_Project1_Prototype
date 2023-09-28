using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    //When start game button is pressed scene marked "1" is loaded
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //When quit game button is pressed the application is quit
    public void QuitGame()
    {
        Application.Quit();
    }

    //When the return to menu button is pressed scene marked "0" is loaded
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
