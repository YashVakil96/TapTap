using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class ScreenManager : MonoBehaviour
{
    public GameObject DeadMenuUI;
    public GameObject PauseMenuUI;

    public Sprite musicOffSprite;
    public Sprite musicOnSprite;

    public static bool fromHome = false;
    public static int DeathCount = 0;
    public static bool popUpScreen = false;


    private GameObject musicObject;
    private GameObject adPanel;
    private Button musicButton;

    public GameObject easy;
    public GameObject normal;
    public GameObject hard;


    private GameObject AdsButton;
    //private GooglaAds gads;

    private void Start()
    {
        Time.timeScale = 1f;
        BallGenerator.isAlive = false;
        musicObject = GameObject.Find("musicButton");
        AdsButton = GameObject.Find("noAddsButtonOn");
        switch (GameManager.instance.level)
        {
            case GameManager.Level.Easy:
                easy.SetActive(true);
                break;

            case GameManager.Level.Normal:
                normal.SetActive(true);
                break;

            case GameManager.Level.Hard:
                hard.SetActive(true);
                break;
        }
    }

    public void checkMusic()
    {
        musicObject = GameObject.Find("musicButton");
        musicButton = musicObject.GetComponent<Button>();
        if (HomeScreen.musicOn)
        {
            Music.instance.StopMusic();

            HomeScreen.musicOn = false;
            Debug.Log(musicButton.image.sprite);
            musicButton.image.sprite = musicOffSprite;
        }
        else
        {
            Music.instance.PlayMusic();
            HomeScreen.musicOn = true;
            Debug.Log(musicButton.image.sprite);

            musicButton.image.sprite = musicOnSprite;
            // Debug.Log(musicOn);
        }
    }

    public void DeadScreen()
    {
        DeadMenuUI.SetActive(true);
        Time.timeScale = 0f;
        if (HomeScreen.musicOn)
        {
            DeadMenuUI.transform.GetChild(0).GetChild(5).GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            DeadMenuUI.transform.GetChild(0).GetChild(5).GetComponent<Image>().sprite = musicOffSprite;
        }

        DeathCount++;
        if (DeathCount == 3)
        {
            //show ad
        }

        AdsButton = GameObject.Find("noAddsButtonOn");
        if (PlayerPrefs.GetString("Remove_Ads").Equals("true"))
        {
            AdsButton.SetActive(false);
        }

        popUpScreen = true;
    }

    public void PauseScreen()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        if (HomeScreen.musicOn)
        {
            PauseMenuUI.transform.GetChild(5).GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            PauseMenuUI.transform.GetChild(5).GetComponent<Image>().sprite = musicOffSprite;
        }

        AdsButton = GameObject.Find("noAddsButtonOn");
        if (PlayerPrefs.GetString("Remove_Ads").Equals("true"))
        {
            AdsButton.SetActive(false);
        }

        popUpScreen = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        popUpScreen = false;
        Debug.Log(popUpScreen);
    }

    public void Home()
    {
        SceneManager.LoadScene("Home_Screen");
        Time.timeScale = 1f;
    }

    public void Rating()
    {
        Application.OpenURL("https://apps.apple.com/in/app/id1494657488");
    }
}