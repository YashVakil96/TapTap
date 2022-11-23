using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject stage;
    float screenRatio;
    float stageRatio;
    void Start()
    {
        screenRatio = (float)Screen.width / (float)Screen.height;
        stageRatio = (float)stage.transform.localScale.y / (float)stage.transform.localScale.x;
    }

    
    void Update()
    {
        if (Rotation.currentScene.name == "Scene_Easy")
        {
            screenRatio = (float)Screen.width / (float)Screen.height;
            stageRatio = (float)stage.transform.localScale.y / (float)stage.transform.localScale.x;
            stage.transform.localScale = new Vector3(screenRatio * 1.7f, screenRatio * 1.7f);
        }
        if (Rotation.currentScene.name == "Scene_Medium")
        {
            screenRatio = (float)Screen.width / (float)Screen.height;
            stageRatio = (float)stage.transform.localScale.y / (float)stage.transform.localScale.x;
            stage.transform.localScale = new Vector3(screenRatio * 2.2f, screenRatio * 2.2f);
        }
        if (Rotation.currentScene.name == "Scene_Hard")
        {
            screenRatio = (float)Screen.width / (float)Screen.height;
            stageRatio = (float)stage.transform.localScale.y / (float)stage.transform.localScale.x;
            stage.transform.localScale = new Vector3(screenRatio * 2.0f, screenRatio * 2.0f);
        }
        
    }
}
