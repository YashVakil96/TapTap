using UnityEngine;
using UnityEngine.UDP;

public class NoAdIAP : MonoBehaviour
{
    private void Start()
    {
        if (UDP.removeads)
        {
            gameObject.SetActive(false);
        }
    }

    public void Purchase()
    {
        StoreService.Purchase("remove_ads","0",UDP.instance._purchaseListener);
    }
}