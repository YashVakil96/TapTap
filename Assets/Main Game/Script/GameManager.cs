using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public static GameManager instance;
    public Level level;

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

    public void LoadLevel(int no)
    {
        level = (Level) no;
        Debug.Log(level);
        SceneManager.LoadScene("Gameplay");
    }

    public enum Level
    {
        Easy = 0,
        Normal = 1,
        Hard = 2
    }
} //class