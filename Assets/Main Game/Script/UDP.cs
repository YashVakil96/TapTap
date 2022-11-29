using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UDP;

public class UDP : MonoBehaviour
{
    public static UDP instance;
    private IInitListener _listener = new InitListener();
    public PurchaseListener _purchaseListener = new PurchaseListener();
    public static bool removeads;

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
        
        if (PlayerPrefs.GetInt("RemoveAds")==1)
        {
            removeads = true;
        }
    }

    private void Start()
    {
        
        StoreService.Initialize(_listener);

    }

    #region Purchase Class

    public class PurchaseListener : IPurchaseListener
    {
        public void OnPurchase(PurchaseInfo purchaseInfo)
        {
            // The purchase has succeeded.
            // If the purchased product is consumable, you should consume it here.
            // Otherwise, deliver the product.
            Debug.Log("On Purchase Success");
            Debug.Log("Remove ads");
            removeads = true;
            
            PlayerPrefs.SetInt("RemoveAds",1);

        }

        public void OnPurchaseFailed(string message, PurchaseInfo purchaseInfo)
        {
            Debug.Log("Purchase Failed: " + message);
        }

        public void OnPurchaseRepeated(string productCode)
        {
            // Some stores don't support queryInventory.
            Debug.Log("On Purchase Repeated");

        }

        public void OnPurchaseConsume(PurchaseInfo purchaseInfo)
        {
            Debug.Log("On Purchase Consume");
            // The consumption succeeded.
            // You should deliver the product here.        
        }

        public void OnPurchaseConsumeFailed(string message, PurchaseInfo purchaseInfo)
        {
            Debug.Log("On Purchase Consume Failed");
            // The consumption failed.
        }

        public void OnQueryInventory(Inventory inventory)
        {
            Debug.Log("On Query Inventory");
            // Querying inventory succeeded.
        }

        public void OnQueryInventoryFailed(string message)
        {
            Debug.Log("Query Failed");
            // Querying inventory failed.
        }

        public void OnPurchasePending(string message, PurchaseInfo purchaseInfo)
        {
            Debug.Log("Purchase Pending");
            // The Purchase is pending
        }
    }
    #endregion

    #region Init Class

    public class InitListener : IInitListener
    {
        public void OnInitialized(UserInfo userInfo)
        {
            Debug.Log("Initialization succeeded");
            // You can call the QueryInventory method here
            // to check whether there are purchases that haven’t been consumed.       
            StoreService.QueryInventory(UDP.instance._purchaseListener);

        }

        public void OnInitializeFailed(string message)
        {
            Debug.Log("Initialization failed: " + message);
        }
    }

    #endregion
     
}