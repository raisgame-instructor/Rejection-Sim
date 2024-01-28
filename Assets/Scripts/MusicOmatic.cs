using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOmatic : MonoBehaviour
{
    
  

    

    public AudioClip otherClip;
    public AudioClip otherClip2;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Musicplayer());
    }


    

    IEnumerator Musicplayer()
    {

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip2;
        audio.Play();
    }




    // Update is called once per frame
    void Update()
    {
        
        


    }
}
