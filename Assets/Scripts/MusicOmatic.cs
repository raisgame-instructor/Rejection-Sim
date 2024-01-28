using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOmatic : MonoBehaviour
{




    bool mybool;


    public AudioClip otherClip;
    public AudioClip otherClip2;
    public AudioClip otherClip3;
    public AudioClip GameOverMusic;
    public AudioClip GameOverMusic2;
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
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip3;
        audio.Play();
    }

    public void StartEndMusic()
    {
        StartCoroutine(EndMusicplayer());
    }
    IEnumerator EndMusicplayer()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = GameOverMusic;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = GameOverMusic2;
        audio.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
        


    }
}
