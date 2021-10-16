using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed = 19f;
    public FixedJoystick variableJoystick;
    public Rigidbody rb;
    public Transform Cam;
    bool çıkma = true;
    bool turboayarı = false;
    bool hayırs = false;
    public UnityEngine.UI.Button evet;
    public UnityEngine.UI.Button hayır;
    public UnityEngine.UI.Button turbo;
    public UnityEngine.UI.Button turboacik;
    public UnityEngine.UI.Text text;
    private RewardedAd rewardedAd;
    public DynamicJoystick dy;


    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
        requestrewarded();
    }
    private void requestrewarded()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-7216345866466458/3590931810";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-7216345866466458/3590931810";
#else
            adUnitId = "unexpected_platform";
#endif
        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        AdRequest request = new AdRequest.Builder().Build();
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }
    public void FixedUpdate()
    {
        Vector3 direction = Cam.transform.forward * variableJoystick.Vertical + Cam.transform.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed);

    }
    public void hızarttır()
    {
         
        
            
        
    }

    public void bessaniyeHizlandir()
    {
        if (gameObject.tag.Equals("Player"))
        {
            speed = 30;
        }
            
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        speed = 30f;
        Time.timeScale = 1;
    }

    public void Rewardedbutton()
    {
            if (this.rewardedAd.IsLoaded())
            {
                this.rewardedAd.Show();
            }
    }
    public void turbobas()
    {
        evet.gameObject.SetActive(true);
        hayır.gameObject.SetActive(true);
        turboacik.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        dy.gameObject.SetActive(false);
    }
    public void turboevet()
    {
        evet.gameObject.SetActive(false);
        hayır.gameObject.SetActive(false);
        turboacik.gameObject.SetActive(true);
        turbo.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        dy.gameObject.SetActive(true);
    }
    public void hayırr()
    {
        evet.gameObject.SetActive(false);
        hayır.gameObject.SetActive(false);
        turbo.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        dy.gameObject.SetActive(true);
    }
}