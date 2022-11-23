using UnityEngine;
using System.Collections;

public class BallGenerator : MonoBehaviour
{
    public GameObject[] Balls;

    public static bool isAlive;
    
    private int ballsSize;
    private int ballSelectorPrevious;
    private int ballSelector;
    GameObject temp;

    void Start()
    {   
        ballsSize=Balls.GetLength(0)-1;
    }

    private void Update()
    {
        if(!isAlive)
        {
            cloneBall();
        }
    }

    public void cloneBall()
    {

        #region EasyCode
        //Easy
        if (Rotation.currentScene.name == "Scene_Easy")
        {
            ballsSize = Balls.GetLength(0) - 4;
            ballSelector = Random.Range(0, 3);
        }
        #endregion

        #region MeduimCode
        //Medium
        if (Rotation.currentScene.name == "Scene_Medium")
        {
            ballsSize = Balls.GetLength(0) - 3;
            ballSelector = Random.Range(0, 4);
        }
        #endregion

        #region HardCode
        //Hard
        if (Rotation.currentScene.name == "Scene_Hard")
        {
            ballsSize = Balls.GetLength(0) - 1;
            ballSelector = Random.Range(0, 6);
        }
        #endregion

        Instantiate(Balls[ballSelector],transform.position,Quaternion.identity);
        ballSelectorPrevious=ballSelector;
        // Swap Code        
        temp = Balls[ballsSize];
        Balls[ballsSize]=Balls[ballSelectorPrevious];
        Balls[ballSelectorPrevious]=temp;
        isAlive = true;
    }
}