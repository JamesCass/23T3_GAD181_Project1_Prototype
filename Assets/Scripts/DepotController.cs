using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DepotController : MonoBehaviour
{
    //When any collider makes contact with the depo the game complete scene is loaded. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(2);
    }

}
