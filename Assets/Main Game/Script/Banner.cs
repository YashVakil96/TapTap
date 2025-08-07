using System;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Mediation;
using UnityEngine;

namespace Unity.Example
{
    public class Banner : MonoBehaviour,IDisposable
    {
        IBannerAd ad;
        string adUnitId = "Banner_Android";

        public void SetupAd()
        {
            //Create
            ad = MediationService.Instance.CreateBannerAd(
                adUnitId,
                BannerAdPredefinedSize.Banner.ToBannerAdSize(),
                BannerAdAnchor.BottomCenter,
                Vector2.zero);

            //Subscribe to events
            ad.OnRefreshed += AdRefreshed;
            ad.OnClicked += AdClicked;
            ad.OnLoaded += AdLoaded;
            ad.OnFailedLoad += AdFailedLoad;
            
            // Impression Event
            MediationService.Instance.ImpressionEventPublisher.OnImpression += ImpressionEvent;
        }

        public void Dispose() => ad?.Dispose();

        public async Task LoadAd()
        {
            try
            {
                await ad.LoadAsync();
            }
            catch (LoadFailedException)
            {
                // We will handle the failure in the OnFailedLoad callback
            }
        }

        void AdLoaded(object sender, EventArgs e)
        {
            Debug.Log("Ad loaded");
        }

        void AdFailedLoad(object sender, LoadErrorEventArgs e)
        {
            Debug.Log("Failed to load ad");
            Debug.Log(e.Message);
        }
        
        void AdRefreshed(object sender, LoadErrorEventArgs e)
        {
            Debug.Log("Refreshed ad");
            Debug.Log(e.Message);
        }
        
        void AdClicked(object sender, EventArgs e)
        {
            Debug.Log("Ad has been clicked");
            // Execute logic after an ad has been clicked.
        }
        
        void ImpressionEvent(object sender, ImpressionEventArgs args)
        {
            var impressionData = args.ImpressionData != null ? JsonUtility.ToJson(args.ImpressionData, true) : "null";
            Debug.Log("Impression event from ad unit id " + args.AdUnitId + " " + impressionData);
        }
        
    }
}