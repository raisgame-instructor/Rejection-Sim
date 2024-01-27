using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Romanceperson : MonoBehaviour
{
    /*Each romance partner will be a prefab of the original
     * All you need to change for them on the game object is the image labeled "picture of RP" and the background for it if you want and then drag the player onto "PLayer Movement Script" to asign that.
     * then in the variables everything should be set for you, and there you can change your "Fillin 1,2,3", the "ResponseText" and the "RPVoiceLines"
     * because each RP has their own canvas it should be fine
     * Finally check the notation at the top of the "Trigger Volume" script to see what you need to do for that if you don't know
    */
    //Script references
    public PlayerMoverment PlayerMovermentScript;
    public TriggerVolume TriggerVolumeScript;
    public RizzMeter RizzMeterScript;
    //this script is to deal with the Interact canvas and the options for the player and showing text and playing audio from the romance partner.
    public Canvas InteractCanvas;
    public TextMeshProUGUI TextOption1;
    public TextMeshProUGUI TextOption2;
    public TextMeshProUGUI TextOption3;
    public List<string> Fillin1;
    public List<string> Fillin2;
    public List<string> Fillin3;
    //this is what the romance partner says
    public TextMeshProUGUI Response;
    public List<string> ResponseText1;
    public bool WillTalk = true;
    //audio
    public AudioSource ASource;
    public List<AudioClip> RPVoiceLines;

    //set the text for this romance partner at the start of the game
    private void Start()
    {
        TextUpdate();
    }

    void TextUpdate()
    {
        //take the first list text option and display it
        TextOption1.text = Fillin1[0];
        TextOption2.text = Fillin2[0];
        TextOption3.text = Fillin3[0];
        //delete that option from each list
        Fillin1.RemoveAt(0);
        Fillin2.RemoveAt(0);
        Fillin3.RemoveAt(0);
    }

    //Here we will update what the romance parter says and update the button text options
    public void LoadTextOption()
    {
        if(ResponseText1.Count > 0)
        {
            Response.text = ResponseText1[0];
            ResponseText1.RemoveAt(0);
            //play audioclip
            ASource.PlayOneShot(RPVoiceLines[0]);
            RPVoiceLines.RemoveAt(0);
        }
        if(ResponseText1.Count == 0)
        {
            Debug.Log("done");
            Invoke("ConvoOver", 2);
            WillTalk = false;
        }
        if (Fillin1.Count > 0)
        {
            TextOption1.text = Fillin1[0];
            Fillin1.RemoveAt(0);
        }
        if (Fillin2.Count > 0)
        {
            TextOption2.text = Fillin2[0];
            Fillin2.RemoveAt(0);
        }
        if (Fillin3.Count > 0)
        {
            TextOption3.text = Fillin3[0];
            Fillin3.RemoveAt(0);
        }
    }

    //When you do this you get the auto response, similar to LoadTextOption
    public void DoneEnteringText()
    {
        LoadTextOption();
    }

    //when the conversation is over, close the UICanvas
    public void ConvoOver()
    {
        TriggerVolumeScript.ButtonCanvas.enabled = false;
        TriggerVolumeScript.MyInteractCanvas.enabled = false;
        PlayerMovermentScript.CanInteract = false;
        PlayerMovermentScript.CanMove = true;
        RizzMeterScript.NegUpdateRizz();
    }
}
