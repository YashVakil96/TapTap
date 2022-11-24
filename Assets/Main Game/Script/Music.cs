using System;
using UnityEngine;

public class Music : MonoBehaviour
{

   public static Music instance;
    private AudioSource musicControl;
    private bool isAudio;


    private void Awake()
    {
       if (instance!=this && instance!=null)
       {
          Destroy(gameObject);
       }
       else
       {
          instance = this;
          DontDestroyOnLoad(gameObject);
       }
    }

    private void Start() {
       musicControl=GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
       if(musicControl.isPlaying) return;
       musicControl.Play();
    }
     public void StopMusic()
     {
       musicControl.Stop();

     }
}
