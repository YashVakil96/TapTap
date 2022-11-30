using System;
using System.Threading.Tasks;
using Unity.Example;
using Unity.Services.Core;
using Unity.Services.Mediation;
using UnityEngine;

public class Ads : MonoBehaviour
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    private string _gameId;

    public Interstitial interstitialAd;
    public Banner bannerAd;
    
    public static Ads instance;

    void Awake()
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

     async void Start()
    {
        if (!UDP.removeads)
        {
            InitializeAds();
            await InitServices();
        }
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
    }

    public async Task InitServices()
    {
        try
        {
            InitializationOptions initializationOptions = new InitializationOptions();
            initializationOptions.SetGameId(_gameId);
            await UnityServices.InitializeAsync(initializationOptions);
            
            interstitialAd.SetupAd();
            await interstitialAd.LoadAd();
            
            bannerAd.SetupAd();
            await bannerAd.LoadAd();
        }
        catch (Exception e)
        {
            InitializationFailed(e);
        }
    }


    void InitializationFailed(Exception e)
    {
        Debug.Log("Initialization Failed: " + e.Message);
    }
}