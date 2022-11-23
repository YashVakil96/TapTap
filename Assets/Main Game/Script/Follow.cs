using UnityEngine;

public class Follow : MonoBehaviour
{
    private Transform target;
    private float speedCheck;
    // Start is called before the first frame update
    void Start()
    {
        target=GameObject.Find("Follow").GetComponent<Transform>();
        speedCheck=SpeedControl.speed;

    }

    void FixedUpdate()
    {
        speedCheck=SpeedControl.speed;
        if(SpeedControl.speed>SpeedControl.maxSpeed)
        {
            SpeedControl.speed=SpeedControl.maxSpeed;
            transform.position=Vector2.MoveTowards(transform.position,target.position,SpeedControl.speed * Time.deltaTime);
        }
        else
        {
            transform.position=Vector2.MoveTowards(transform.position,target.position,SpeedControl.speed * Time.deltaTime);
        }
    }

   
}
