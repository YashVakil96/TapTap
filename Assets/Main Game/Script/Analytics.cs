using System;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using UnityEngine;

public class Analytics : MonoBehaviour
{
    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                var app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
                Debug.Log("Firebase Ready");
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }

            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });    
    }

    


private void OnApplicationQuit()
{
    Firebase.FirebaseApp.DefaultInstance.Dispose();
}
}