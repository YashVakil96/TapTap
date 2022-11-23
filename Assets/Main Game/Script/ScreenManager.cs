using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private Music musicControl;

    private GameObject AdsButton;
    //private GooglaAds gads;

    private void Start()
    {
        musicControl = GameObject.FindGameObjectWithTag("Audio").GetComponent<Music>();
        musicObject = GameObject.Find("musicButton");
        AdsButton = GameObject.Find("noAddsButtonOn");
        musicButton = musicObject.GetComponent<Button>();
    }

    private void Update()
    {
        musicObject = GameObject.Find("musicButton");
        musicButton = musicObject.GetComponent<Button>();
    }

    public void Easy()
    {
        SceneManager.LoadScene("Scene_Easy");
        Colliders.scorePoints = 0;
        Time.timeScale = 1f;
        BallGenerator.isAlive = false;
    }

    public void Medium()
    {
        SceneManager.LoadScene("Scene_Medium");
        Colliders.scorePoints = 0;
        Time.timeScale = 1f;
        BallGenerator.isAlive = false;
    }

    public void Hard()
    {
        SceneManager.LoadScene("Scene_Hard");
        Colliders.scorePoints = 0;
        Time.timeScale = 1f;
        BallGenerator.isAlive = false;
    }

    public void checkMusic()
    {
        musicObject = GameObject.Find("musicButton");
        musicButton = musicObject.GetComponent<Button>();
        if (HomeScreen.musicOn)
        {
            musicControl.StopMusic();
            HomeScreen.musicOn = false;
            Debug.Log(musicButton.image.sprite);
            musicButton.image.sprite = musicOffSprite;
        }
        else
        {
            musicControl.PlayMusic();
            HomeScreen.musicOn = true;
            Debug.Log(musicButton.image.sprite);

            musicButton.image.sprite = musicOnSprite;
            // Debug.Log(musicOn);
        }
    }


    public void Difficulty_Screen()
    {
        SceneManager.LoadScene("Difficulty_Screen");
        Time.timeScale = 1f;
        popUpScreen = false;
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
        adPanel.SetActive(true);
        popUpScreen = false;
        Debug.Log(popUpScreen);
    }

    public void Home()
    {
        SceneManager.LoadScene("Home_Screen");
        Time.timeScale = 1f;
    }

    public void InfoScreen()
    {
        SceneManager.LoadScene("InfoScreen");
        Time.timeScale = 1f;
    }

    public void closeInfo()
    {
        if (fromHome)
        {
            SceneManager.LoadScene("Home_Screen");
            fromHome = false;
        }
        else
        {
            SceneManager.LoadScene("Difficulty_Screen");
        }
    }

    public void Rating()
    {
        Application.OpenURL("https://apps.apple.com/in/app/id1494657488");
    }
}