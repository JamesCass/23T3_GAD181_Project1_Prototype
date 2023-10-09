using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DepotControllerLevel1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI packageText;
    [SerializeField] GameObject package;
    [SerializeField] TextMeshProUGUI textBox;

    //When a 2D collider enters the trigger AKA "Player" checks to see if the set gameobject is active or not AKA "The Package"
    //... if the package is still active enables some text telling the player they still need to pick it up or if the package is collected the scene tagged (2) is loaded.
    private void Start()
    {
        textBox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.gameObject.CompareTag("Player"))
            {


                if (package.activeSelf)
                {
                    packageText.SetText("You must pick up the package!");
                    Debug.Log("THE PACKAGE MUST BE PICKED UP");
                    textBox.enabled = true;
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    Debug.Log("THE PACKAGE HAS BEEN PICKED UP");
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        textBox.enabled = false;
    }

}
