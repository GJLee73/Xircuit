using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour
{
	public static RewardBasedVideoAd rewardAd;
	public static InterstitialAd interstitialAd;

	public static string appId = "";
	public string _appId = "";
	public static string interstitialUnitId = "";
	public string _interstitialUnitId = "";
	public static string rewardUnitId = "";
	public string _rewardUnitId = "";
 	public static bool isTest = true;
	public bool _isTest = true;
	public static string deviceId="";
	public string _deviceId="";
	private const string INTER_TEST_ID = "ca-app-pub-3940256099942544/1033173712";
	private const string REWARD_TEST_ID = "ca-app-pub-3940256099942544/5224354917";
	public static bool interErrorOccured = false;

	void Awake (){
		isTest = _isTest;
		deviceId = _deviceId;
		appId = _appId;
		interstitialUnitId = _interstitialUnitId;
		rewardUnitId = _rewardUnitId;
		DontDestroyOnLoad (this);
	}

	void Start ()
	{
		MobileAds.Initialize(_appId);
		if (isTest) {
			//interstitialUnitId = INTER_TEST_ID;
			interstitialUnitId = "ca-app-pub-3411986967639265/5893498274";
			rewardUnitId = REWARD_TEST_ID;
		}
		//rewardAd = RewardBasedVideoAd.Instance;
		//interstitialAd = new InterstitialAd (interstitialUnitId);

		//광고요청이 성공적으로 로드되면 호출됩니다.
		//rewardAd.OnAdLoaded += OnAdLoaded;
		//interstitialAd.OnAdLoaded += OnAdLoaded;
		//광고요청을 로드하지 못했을 때 호출됩니다.
		//rewardAd.OnAdFailedToLoad += OnAdFailedToLoad;
		//interstitialAd.OnAdFailedToLoad += OnInterAdFailedToLoad;
		//광고가 표시될 때 호출됩니다.
		//rewardAd.OnAdOpening += OnAdOpening;
		//광고가 재생되기 시작하면 호출됩니다.
		//rewardAd.OnAdStarted += OnAdStarted;
		//사용자가 비디오 시청을 통해 보상을 받을 때 호출됩니다.
		//rewardAd.OnAdRewarded += OnAdRewarded;
		//광고가 닫힐 때 호출됩니다.
		//rewardAd.OnAdClosed += OnRewardAdClosed;
		//interstitialAd.OnAdClosed += OnInterstitialAdClosed;
		//광고클릭으로 인해 사용자가 애플리케이션을 종료한 경우 호출됩니다.
		//rewardAd.OnAdLeavingApplication += OnAdLeavingApplication;

		//LoadAd ("interstitial");
		//LoadAd ("reward");
	}

	public static void LoadAd(string mode){
		interErrorOccured = false;
		AdRequest request = new AdRequest.Builder ().Build ();
		if (isTest) {
			if (deviceId.Length > 0) {
				request = new AdRequest.Builder ().AddTestDevice (AdRequest.TestDeviceSimulator).AddTestDevice (deviceId).Build ();
			}
		}
		if (mode == "interstitial") {
			interstitialAd = new InterstitialAd (interstitialUnitId);
			interstitialAd.OnAdFailedToLoad += OnInterAdFailedToLoad;
			interstitialAd.LoadAd (request);
		} else if (mode == "reward") {
			rewardAd = RewardBasedVideoAd.Instance;
			rewardAd.LoadAd (request, rewardUnitId);
		}
	}

	public static void ShowAd(string mode){
		if (mode == "interstitial") {
			if (interstitialAd.IsLoaded ()) {
				Debug.Log ("View insterstitial Ad");
			} else {
				Debug.Log ("Interstitial Ad is not loaded");
				LoadAd (mode);
			}
			interstitialAd.Show ();
		} else if (mode == "reward") {
			if (rewardAd.IsLoaded ()) {
				Debug.Log ("View Reward Ad");
			} else {
				Debug.Log ("Reward Ad is not loaded");
				LoadAd (mode);
			}
			rewardAd.Show ();
		}
	}

	public static void DestroyAd(string mode){
		if (mode == "interstitial") {
			interstitialAd.Destroy ();
		} else {
			Debug.Log ("Unvalid mode");
		}
	}

		
	void OnAdLoaded(object sender, EventArgs args) { Debug.Log("OnAdLoaded"); }
	void OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e) { Debug.Log("OnAdFailedToLoad"); }
	void OnAdOpening(object sender, EventArgs e) { Debug.Log("OnAdOpening"); }
	void OnAdStarted(object sender, EventArgs e) { Debug.Log("OnAdStarted"); }
	void OnAdRewarded(object sender, Reward e) { Debug.Log("OnAdRewarded"); }
	void OnRewardAdClosed(object sender, EventArgs e)
	{
		Debug.Log("OnRewardAdClosed");
		LoadAd ("reward");
	}
	void OnInterstitialAdClosed(object sender, EventArgs e){
		Debug.Log ("OnInterstitialAdClosed");
		LoadAd ("interstitial");
	}
	void OnAdLeavingApplication(object sender, EventArgs e) { Debug.Log("OnAdLeavingApplication"); }

	void OnMouseDown(){
		LoadAd ("interstitial");
	}

	private static void OnInterAdFailedToLoad(object sender, AdFailedToLoadEventArgs e){
		interErrorOccured = true;
	}
}




