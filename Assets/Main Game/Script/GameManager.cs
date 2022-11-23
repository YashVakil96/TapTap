using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public static GameManager instance;

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
    

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Application.Quit();
                Debug.Log("Quit");
            }
        }
    }
    #endregion

}//class