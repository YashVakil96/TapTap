using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public static GameManager instance;

    public ScreenManager screenManager;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        screenManager = FindObjectOfType<ScreenManager>();
    }


    private void Update()
    {
        if (screenManager == null)
        {
            screenManager = FindObjectOfType<ScreenManager>();

        }
        
        if (Input.GetKey(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex ==0)
            {
                Application.Quit();
                Debug.Log("Quit");
            }
            else if (SceneManager.GetActiveScene().buildIndex > 2)
            {
                //Pause
                if (ScreenManager.popUpScreen)
                {
                   screenManager.PauseScreen();
                   Debug.Log("Paused");
                }

                else
                {
                    screenManager.Resume();
                    Debug.Log("Resume");
                }
            }
            else
            {
                GoBack();
            }
        }
        
    }
    #endregion

    #region User Methods

    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    #endregion

}//class