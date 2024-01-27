using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Romanceperson : MonoBehaviour
{
    public PlayerMoverment PlayerMovermentScript;
    public TriggerVolume TriggerVolumeScript;

    //this script is to deal with the Interact canvas and the options for the player and showing text and playing audio from the romance partner.
    public Canvas InteractCanvas;
    public TextMeshProUGUI TextOption1;
    public TextMeshProUGUI TextOption2;
    public TextMeshProUGUI TextOption3;
    public string Fillin1;
    public string Fillin2;
    public string Fillin3;

    //
    private void Start()
    {
        TextUpdate1();   
    }

    //
    void TextUpdate1()
    {
        TextOption1.text = Fillin1;
        TextOption2.text = Fillin2;
        TextOption3.text = Fillin3;
    }

    public void LoadTextOption()
    {
        Debug.Log("benis");
    }

    //When you do this you get the auto response
    public void DoneEnteringText()
    {
        Debug.Log("asd");
    }

    //when the conversation is over, close the UICanvas
    public void ConvoOver()
    {
        TriggerVolumeScript.ButtonCanvas.enabled = false;
        TriggerVolumeScript.MyInteractCanvas.enabled = false;
        PlayerMovermentScript.CanInteract = false;
        PlayerMovermentScript.CanMove = true;
    }
}
