using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class GoogleMobileAdControll : MonoBehaviour {
    private BannerView bannerView;
    public static bool showbanner;
    private string bannerID = "Your Add Banner ID";
    private static GoogleMobileAdControll admobControll = null;
    public static GoogleMobileAdControll AdmobControll{get{return admobControll;} }  
    
	// Use this for initialization   
    void Awake()
    {
        if (admobControll)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        admobControll = this;
        DontDestroyOnLoad(this.gameObject);
		RequestBanner();
	}	
	
    #region BannerAD
    private void RequestBanner()
    {
        if (bannerView != null) 
        {
            bannerView.Destroy();
        }        
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(bannerID, AdSize.SmartBanner, AdPosition.Bottom);

        // Register for ad events.
        //bannerView.AdLoaded += HandleAdLoaded;
        //bannerView.AdFailedToLoad += HandleAdFailedToLoad;
        //bannerView.AdOpened += HandleAdOpened;
        //bannerView.AdClosing += HandleAdClosing;
        //bannerView.AdClosed += HandleAdClosed;
        //bannerView.AdLeftApplication += HandleAdLeftApplication;

        // bannerView.LoadAd(createAdRequest());
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    public void ShowBanner()
    {        
        bannerView.Show();
    }
    public void HideBanner()
    {
        bannerView.Hide();
    }
    public void desBanner()
    {
        bannerView.Destroy();
    }
#endregion

}
