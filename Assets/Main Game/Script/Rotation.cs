using UnityEngine;
using UnityEngine.SceneManagement;
public class Rotation : MonoBehaviour
{

    public iTween.LoopType loopType;
    public iTween.EaseType easeType;
    private Vector3 originalRotation;

    private void Start() {
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
            if(GameManager.instance.level == GameManager.Level.Easy)
            {
                iTween.RotateBy(this.gameObject,iTween.Hash("z",-.333333333333f,"time",.1f,"easetype",easeType,"looptype",loopType)); //Scene_Easy Code
                Debug.Log("easy");
            }
            if(GameManager.instance.level == GameManager.Level.Normal)
            {
                iTween.RotateBy(this.gameObject,iTween.Hash("z",-.25f,"time",.1f,"easetype",easeType,"looptype",loopType)); //Scene_Medium Code
                Debug.Log("normal");
            }
            if(GameManager.instance.level == GameManager.Level.Hard)
            {
                iTween.RotateBy(this.gameObject,iTween.Hash("z",-.1666666667f,"time",.1f,"easetype",easeType,"looptype",loopType)); //Scene_Medium Code
                Debug.Log("hard");
            }
    }
}