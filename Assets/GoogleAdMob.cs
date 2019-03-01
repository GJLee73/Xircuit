using System.Collections;

using System.Collections.Generic;

using UnityEngine;



using GoogleMobileAds.Api;



public class GoogleAdMob : MonoBehaviour {



	static bool isAdsBannerSet = false;



	// Use this for initialization

	void Start () {



		if(!isAdsBannerSet)

			RequestBanner();

	}





	private void RequestBanner()

	{

		#if UNITY_ANDROID

		string AdUnitID = "ca-app-pub-3411986967639265/1127723924";

		#else

		string AdUnitID = "unDefind";

		#endif

		BannerView banner = new BannerView(AdUnitID, AdSize.Banner, AdPosition.Bottom);


		AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("62f61b09fd4dd067").Build();

		//AdRequest request = new AdRequest.Builder().Build();

		banner.LoadAd(request);

		isAdsBannerSet = true;

	}

}



