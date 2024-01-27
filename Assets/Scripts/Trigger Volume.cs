using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    /*When the RP is created from the prefab you need to assign 2 variables for it to work right.
     * The "Button Canvas" and "Player Movement Script" if you did this in the right order you should be coming from the Romance person Script, and should know where to get the player and where to put them
     * then you need to grab the Button Canvas also found in the Hierarchy and drag that into the variable named the same thing
     * Thats all you need to do, now your set up and ready to go
     */
    public Canvas ButtonCanvas;
    public Canvas MyInteractCanvas;
    public PlayerMoverment PlayerMovermentScript;
    public Romanceperson romanceperson;
    private bool Intrigger;

    //On start set canvas to off
    private void Start()
    {
        MyInteractCanvas.enabled = false;
        ButtonCanvas.enabled = false;
    }

    //on trigger enter, check if the players is the one that collided with us. if true turn on UI Canvas to tell player they have the option to interact with this person. if button is clicked close Button canvas & turn on interacting canvas
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && romanceperson.WillTalk)
        {
            Debug.Log("you did it");
            ButtonCanvas.enabled = true;
            Intrigger = true;
        }
    }

    //check if we can interact with this person and then open the interact canvas
    public void Update()
    {
        if (PlayerMovermentScript.CanInteract && Intrigger && romanceperson.WillTalk)
        {
            ButtonCanvas.enabled = false;
            MyInteractCanvas.enabled = true;
            PlayerMovermentScript.CanMove = false;
            //trigger the voice line when the interact canvas turns on
            romanceperson.TriggerLines();
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

    //When the exit button is clicked we turn off the canvas' and let the player move again
    public void ExitButton()
    {
        ButtonCanvas.enabled = false;
        MyInteractCanvas.enabled = false;
        PlayerMovermentScript.CanInteract = false;
        PlayerMovermentScript.CanMove = true;
    }

}
