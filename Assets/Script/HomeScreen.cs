using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class HomeScreen : MonoBehaviour
{
    public GameObject homeScreenUI;
    public Sprite musicOffSprite;
    public Sprite musicOnSprite;    
    public static bool musicOn=true;

    private GameObject AdsButton;
    private GameObject musicObject;
    private Button musicButton;
    private Music musicControl;
    // Start is called before the first frame update
    void Start()
    {
        musicObject=GameObject.Find("musicButton");
        musicButton=musicObject.GetComponent<Button>();
        musicControl=GameObject.FindGameObjectWithTag("Audio").GetComponent<Music>();
        AdsButton = GameObject.Find("noAddsButtonOn");
        if(musicOn)
        {
            musicButton.image.sprite=musicOnSprite;
        }
        else
        {
            musicButton.image.sprite=musicOffSprite;

        }
        if(PlayerPrefs.GetString("Remove_Ads").Equals("true"))
        {
            AdsButton.SetActive(false);
            // IAP.isRemoveAds = true;
            Debug.Log("Ads Removed");
        }
        /*if(IAP.isRemoveAds)
        {
            AdsButton.SetActive(false);
        }*/
    }
    private void Update()
    {
        /*if (IAP.isRemoveAds)
        {
            AdsButton.SetActive(false);
        }*/
    }
    public void checkMusic()
    {
        if(musicOn)
        {
            musicControl.StopMusic();
            musicOn=false;
            musicButton.image.sprite=musicOffSprite;
            // musicControl.mute=true;
            // musicControl.Stop();
        }
        else
        {
            musicControl.PlayMusic();
            musicOn=true;
            musicButton.image.sprite=musicOnSprite;
            // musicControl.mute=false;
            // musicControl.Play();

        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Difficulty_Screen");
    }

      public void InfoScreen()
    {
        SceneManager.LoadScene("InfoScreen");
        ScreenManager.fromHome=true;
    }
    public void Rating()
    {
        Application.OpenURL("https://apps.apple.com/in/app/id1494657488");
    }
}
