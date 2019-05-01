using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobTest : MonoBehaviour
{
	RewardBasedVideoAd ad;
	InterstitialAd ad2;

	[SerializeField] string appId;
	[SerializeField] string unitId="ca-app-pub-3940256099942544/1033173712";
	[SerializeField] bool isTest;
	[SerializeField] string deviceId;

	void Start ()
	{
		MobileAds.Initialize(appId);
		ad = RewardBasedVideoAd.Instance;
		this.ad2 = new InterstitialAd (unitId);

		//광고요청이 성공적으로 로드되면 호출됩니다.
		ad.OnAdLoaded += OnAdLoaded;
		//광고요청을 로드하지 못했을 때 호출됩니다.
		ad.OnAdFailedToLoad += OnAdFailedToLoad;
		//광고가 표시될 때 호출됩니다.
		ad.OnAdOpening += OnAdOpening;
		//광고가 재생되기 시작하면 호출됩니다.
		ad.OnAdStarted += OnAdStarted;
		//사용자가 비디오 시청을 통해 보상을 받을 때 호출됩니다.
		ad.OnAdRewarded += OnAdRewarded;
		//광고가 닫힐 때 호출됩니다.
		ad.OnAdClosed += OnRewardAdClosed;
		ad2.OnAdClosed += OnInterstitialAdClosed;
		//광고클릭으로 인해 사용자가 애플리케이션을 종료한 경우 호출됩니다.
		ad.OnAdLeavingApplication += OnAdLeavingApplication;
		DontDestroyOnLoad (this);
		//LoadRewardAd();
		LoadInterstitialAd ();
	}


	void LoadRewardAd()
	{
		AdRequest request = new AdRequest.Builder().Build();
		if (isTest)
		{
			if(deviceId.Length > 0)
				request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice(deviceId).Build();
			else
				unitId = "ca-app-pub-3940256099942544/5224354917"; //테스트 유닛 ID

		}
		ad.LoadAd(request, unitId);
	}

	void LoadInterstitialAd(){
		AdRequest request = new AdRequest.Builder ().Build ();
		if (isTest) {
			if (deviceId.Length > 0)
				request = new AdRequest.Builder ().AddTestDevice (AdRequest.TestDeviceSimulator).AddTestDevice (deviceId).Build ();
			else
				unitId = "ca-app-pub-3940256099942544/1033173712"; //테스트 유닛 ID
		}
		this.ad2.LoadAd (request);
	}

	public void ShowRewardAd(){
		if (ad.IsLoaded())
		{
			Debug.Log("View Reward Ad");
			ad.Show();
		}
		else
		{
			Debug.Log("Reward Ad is Not Loaded");
			LoadRewardAd();
		}
	}

	public void ShowInterstitialAd(){
		if (ad2.IsLoaded ()) {
			Debug.Log ("View Interstitial Ad");
			ad2.Show ();
		} else {
			Debug.Log ("Interstitial Ad is not loaded");
			LoadInterstitialAd();
		}
	}

	void OnMouseDown(){
		ShowInterstitialAd ();
	}

	void OnAdLoaded(object sender, EventArgs args) { Debug.Log("OnAdLoaded"); }
	void OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e) { Debug.Log("OnAdFailedToLoad"); }
	void OnAdOpening(object sender, EventArgs e) { Debug.Log("OnAdOpening"); }
	void OnAdStarted(object sender, EventArgs e) { Debug.Log("OnAdStarted"); }
	void OnAdRewarded(object sender, Reward e) { Debug.Log("OnAdRewarded"); }
	void OnRewardAdClosed(object sender, EventArgs e)
	{
		Debug.Log("OnRewardAdClosed");
		LoadRewardAd();
	}
	void OnInterstitialAdClosed(object sender, EventArgs e){
		Debug.Log ("OnInterstitialAdClosed");
		LoadInterstitialAd ();
	}
	void OnAdLeavingApplication(object sender, EventArgs e) { Debug.Log("OnAdLeavingApplication"); }
}
