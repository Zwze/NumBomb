using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip bombExplode;
    public static AudioClip bgm;
    public static AudioClip click;


    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        bombExplode = Resources.Load<AudioClip>("explode");
        bgm = Resources.Load<AudioClip>("bgm_low");
        click = Resources.Load<AudioClip>("click");
        
        audioSrc.clip = bgm;
        audioSrc.loop=true;
        audioSrc.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayClickClip()
    {
        audioSrc.PlayOneShot(click);
    }
    public static void PlayBombExplodeClip()
    {
        audioSrc.PlayOneShot(bombExplode);
    }

    public static void PlaybgmClip()
    {
        audioSrc.clip = bgm;
        audioSrc.Play();
    }


    public static void PausebgmClip()
    {
        audioSrc.clip = bgm;
        audioSrc.Pause();
    }



}
