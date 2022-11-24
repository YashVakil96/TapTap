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
        
        SetStage();
    }

    private void SetStage()
    {
        if (GameManager.instance.level == GameManager.Level.Easy)
        {
            screenRatio = (float) Screen.width / (float) Screen.height;
            stageRatio = (float) stage.transform.localScale.y / (float) stage.transform.localScale.x;
            stage.transform.localScale = new Vector3(screenRatio * 1.7f, screenRatio * 1.7f);
        }

        if (GameManager.instance.level == GameManager.Level.Normal)
        {
            screenRatio = (float) Screen.width / (float) Screen.height;
            stageRatio = (float) stage.transform.localScale.y / (float) stage.transform.localScale.x;
            stage.transform.localScale = new Vector3(screenRatio * 2.2f, screenRatio * 2.2f);
        }

        if (GameManager.instance.level == GameManager.Level.Hard)
        {
            screenRatio = (float) Screen.width / (float) Screen.height;
            stageRatio = (float) stage.transform.localScale.y / (float) stage.transform.localScale.x;
            stage.transform.localScale = new Vector3(screenRatio * 2.0f, screenRatio * 2.0f);
        }
    }
}
