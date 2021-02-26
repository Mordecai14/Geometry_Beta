using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class IntersticialAd : MonoBehaviour
{
    public static IntersticialAd instance;
    public InterstitialAd interAd;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-4796477816894604~4353173824";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif
        this.RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4796477816894604/6642766564";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interAd = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interAd.LoadAd(request);
    }


    public void ShowThisAd()
    {
        Debug.LogError("Intertitial Ad");
        if (this.interAd.IsLoaded())
        {
            this.interAd.Show();
        }
    }

    
}
