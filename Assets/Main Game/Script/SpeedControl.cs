using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    public float speedMultiplier;
    public int scoreCount;
    public float speedInput;
    public float maxSpeedInput;
    
    public static float speed;
    public static float maxSpeed;

    private void Start() {
        speed=speedInput;
        maxSpeed=maxSpeedInput;
    }
    void Update()
    {
        if(scoreCount<Colliders.scorePoints)
        {
            speed+=speedMultiplier;
            // Debug.Log("MIN : "+minGap);
            // Debug.Log("MAX : "+maxGap);
            scoreCount+=scoreCount;
        }
    }
}
