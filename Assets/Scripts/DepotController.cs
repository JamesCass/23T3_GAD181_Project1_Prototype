using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DepotController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI packageText;
    [SerializeField] GameObject package;
    
    //When a 2D collider enters the trigger AKA "Player" checks to see if the set gameobject is active or not AKA "The Package"
    //... if the package is still active enables some text telling the player they still need to pick it up or if the package is collected the scene tagged (2) is loaded.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (package.activeSelf)
            {
                packageText.SetText("You must pick up the package!");
                Debug.Log("THE PACKAGE MUST BE PICKED UP");
            }
            else
            {
                SceneManager.LoadScene(2);
                Debug.Log("THE PACKAGE HAS BEEN PICKED UP");
            }
        }
    }
  
}
