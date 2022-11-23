using UnityEngine;
using UnityEngine.SceneManagement;
public class Rotation : MonoBehaviour
{

    public iTween.LoopType loopType;
    public iTween.EaseType easeType;
    private Vector3 originalRotation;
    public static Scene currentScene;

    private void Start() {
    currentScene=SceneManager.GetActiveScene();
    // Debug.Log(currentScene.name);    
    }
    
    void Update()
    {
     originalRotation=transform.position;
        //Rotation
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
                Spin();
                
        }   
    }

    void Spin(){
            if(currentScene.name=="Scene_Easy")
            {
                iTween.RotateBy(this.gameObject,iTween.Hash("z",-.333333333333f,"time",.1f,"easetype",easeType,"looptype",loopType)); //Scene_Easy Code
            }
            if(currentScene.name=="Scene_Medium")
            {
                iTween.RotateBy(this.gameObject,iTween.Hash("z",-.25f,"time",.1f,"easetype",easeType,"looptype",loopType)); //Scene_Medium Code
            }
            if(currentScene.name=="Scene_Hard")
            {
                iTween.RotateBy(this.gameObject,iTween.Hash("z",-.1666666667f,"time",.1f,"easetype",easeType,"looptype",loopType)); //Scene_Medium Code
            }
    }
}