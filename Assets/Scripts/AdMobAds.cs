using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobAds : MonoBehaviour
{
    public static AdMobAds instance;
    public BannerView bannerHome;
    //public BannerView bannerHome2;

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
    public void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-4796477816894604~4353173824";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerHome = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        //this.bannerHome2 = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        this.bannerHome.LoadAd(request);
        //this.bannerHome2.LoadAd(request);
    }


    private void OnDisable()
    {
        //Posible destruccion de Banners en el menu
        //Debug.LogError("On Disable");
    }
}
