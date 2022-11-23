using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource musicControl;
    private bool isAudio;

    private void Start() {
       musicControl=GetComponent<AudioSource>();
   int numMusicPlayers = GameObject.FindGameObjectsWithTag("Audio").GetLength(0);
      if(numMusicPlayers!=1)
      {
         Destroy(this.gameObject);
      }
      else
      {
       DontDestroyOnLoad(this);
      }
       
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
