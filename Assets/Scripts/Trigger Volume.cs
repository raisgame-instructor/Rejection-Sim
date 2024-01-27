using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolume : MonoBehaviour
{

    public Canvas ButtonCanvas;
    public Canvas MyInteractCanvas;
    public PlayerMoverment PlayerMovermentScript;
    private bool Intrigger;


    //on trigger enter, check if the players is the one that collided with us. if true turn on UI Canvas to tell player they have the option to interact with this person. if button is clicked close Button canvas & turn on interacting canvas
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("you did it");
            ButtonCanvas.enabled = true;
            Intrigger = true;
        }
    }

    public void Update()
    {
        if (PlayerMovermentScript.CanInteract && Intrigger)
        {
            ButtonCanvas.enabled = false;
            MyInteractCanvas.enabled = true;
            //disable input when interact canvas is up. need alternate way to exit out of the interact canvas
        }
    }


    //on trigger exit turn off the buttons canvas
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("you stopped doing it");
            ButtonCanvas.enabled = false;
            MyInteractCanvas.enabled = false;
            Intrigger = false;
            PlayerMovermentScript.CanInteract = false;

        }
    }
}
