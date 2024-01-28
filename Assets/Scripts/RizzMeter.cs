using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RizzMeter : MonoBehaviour
{
    //Drag the Main Camera into the "Main Audio Source" Variable on the HUD 
    public Slider Rizzmeter;
    public float CurrentValue;
    public Canvas GameOverCanvas;
    public MusicOmatic MusicAudioSource;
    public GameOverScript GameOverScript;
    //public AudioSource soundplayer;
    public AudioClip downrizz;
    public AudioClip uprizz;
    /*on update we want the bar to go down by a very small amount and check to see if the value is zero
    When the bar gets to Zero we want to trigger the end of the game*/
    void Update()
    {
        ConstantUpdateRizz();
        //once the value is Zero its game over. we will turn on the game over canvas, play the game over music and have a restart and quit button
        if(Rizzmeter.value == 0)
        {
            Debug.Log("end game");
            this.enabled = false;
            GameOverCanvas.enabled = true;
            MusicAudioSource.StartEndMusic();
            GameOverScript.PlayAnim();
        }
        
    }

    private void ConstantUpdateRizz()
    {
        CurrentValue = CurrentValue - 0.01f;
        Rizzmeter.value = CurrentValue;
    }
    //will happen when you pick up items
    public void PosUpdateRizz()
    {
        CurrentValue = CurrentValue + 15f;
        Rizzmeter.value = CurrentValue;
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = uprizz;
        audio.Play();
    }
    //at the end of every conversation we want the bar to go down by a drastic amount
    public void NegUpdateRizz()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = downrizz;
        audio.Play();
        CurrentValue = CurrentValue - 20f;
        Rizzmeter.value = CurrentValue;
    }
    
}
