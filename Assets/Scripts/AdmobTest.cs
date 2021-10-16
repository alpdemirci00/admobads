using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdmobTest : MonoBehaviour
{
    public Text bilgi;
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        RequestRewarded();
        RequestInterstitial();
    }

    private void RequestRewarded() {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-7216345866466458/2162338066";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-7216345866466458/2162338066";
#else
            adUnitId = "unexpected_platform";
#endif
        this.rewardedAd = new RewardedAd(adUnitId);
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

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
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.OyunTerkediliyor;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7216345866466458/9220708619";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-7216345866466458/9220708619";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void OyunTerkediliyor(object sender, EventArgs args)
    {
        bilgi.text= "Oyun Terk Ediliyor.";
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        interstitial.Destroy();
        bilgi.text = "Geçiş Kapatıldı.";
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        //Oyuncuyu Ödüllendir.
        bilgi.text = "Oyuncu Ödüllendir.";
    }

    public void BannerButton() {
        this.RequestBanner();
        //bannerView.Destroy();
    }

    public void InterstatialButton() {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void RewardedButton() {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }


}
