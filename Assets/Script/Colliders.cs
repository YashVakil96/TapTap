using UnityEngine;
public class Colliders : MonoBehaviour
{
    public  static int scorePoints=0;
    
    private int blueScore=0;
    private int redScore=0;
    private int greenScore=0;
    private int yellowScore=0;
    private int pinkScore=0;
    private int limeScore=0;
    private ScreenManager screen;
    private AudioSource collideAudio;

    private void Start() {
        screen=FindObjectOfType<ScreenManager>();
        collideAudio=GetComponentInParent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(gameObject.GetComponent<Collider2D>().name=="Blue"){
            //CODE BLUE 

            if(other.gameObject.name=="blue_ball(Clone)"){
                
                blueScore++;
                scorePoints++;
                // Debug.Log("Blue:"+blueScore);
            }
            else{
                screen.DeadScreen();
                Debug.Log("GAME OVER");
            }
    
        }
        if(gameObject.GetComponent<Collider2D>().name=="Red"){
            //CODE RED
                if(other.gameObject.name=="red_ball(Clone)"){
                
                    redScore++;
                    scorePoints++;

                // Debug.Log("Red:"+redScore);
            }
            else{
                screen.DeadScreen();

                Debug.Log("GAME OVER");
            }        }
        if(gameObject.GetComponent<Collider2D>().name=="Green"){
            //CODE GREEN
            if(other.gameObject.name=="green_ball(Clone)"){
                
                greenScore++;
                scorePoints++;

                // Debug.Log("Green:"+greenScore);
            }
            else{
                screen.DeadScreen();
            }
        }

        if(gameObject.GetComponent<Collider2D>().name=="Yellow"){
            //CODE GREEN
            if(other.gameObject.name=="yellow_ball(Clone)"){
                
                yellowScore++;
                scorePoints++;

                // Debug.Log("Green:"+greenScore);
            }
            else{
                screen.DeadScreen();

                Debug.Log("GAME OVER");
            }
        }

        if(gameObject.GetComponent<Collider2D>().name=="Pink"){
            //CODE GREEN
            if(other.gameObject.name=="pink_ball(Clone)"){
                
                pinkScore++;
                scorePoints++;

                // Debug.Log("Green:"+greenScore);
            }
            else{
                screen.DeadScreen();

                Debug.Log("GAME OVER");
            }
        }

        if(gameObject.GetComponent<Collider2D>().name=="Lime"){
            //CODE GREEN
            if(other.gameObject.name=="lime_ball(Clone)"){
                
                limeScore++;
                scorePoints++;

                // Debug.Log("Green:"+greenScore);
            }
            else{
                screen.DeadScreen();

                Debug.Log("GAME OVER");
            }
        }
        
        // Debug.Log("Score: "+scorePoints);
        collideAudio.Play();
        Destroy(other.gameObject);
        BallGenerator.isAlive = false;
    }
}
