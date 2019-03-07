using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class RewardAdButton : MonoBehaviour {
	private static NeoBlock motherBlock;
	public static GameObject instance;

	//this variable is just for test
	public static bool isChoosing = false;

	void Awake(){
		//instance = GetComponent<RewardAdButton> ();
		instance = this.gameObject;
		DontDestroyOnLoad (this.gameObject);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//AddBlock (randomColor);
		/*if (mode) {
			AdMobManager.LoadAd ("reward");
			AdMobManager.rewardAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
			AdMobManager.ShowAd ("reward");
		} else {
			int chosenColor = RewardRoulette.rouletteCircle.StopRoulette ();
			AddBlock (chosenColor);
			mode = true;
		}*/


		if (!isChoosing) {
			StartRoulette ();
			isChoosing = true;
		} else {
			int chosenColor = RewardRoulette.rouletteCircle.StopRoulette ();
			AddBlock (chosenColor);
			isChoosing = false;
		}
	}

	void HandleRewardBasedVideoRewarded(object sender, Reward args){
		StartRoulette ();
		isChoosing = false;
	}

	void AddBlock(int color, int amount=1){
		if (color > 7 || color < 0) {
			throw new UnityException ("unvalid color number");
		}
		motherBlock.SendMessage ("AddBlock", color);
	}

	void StartRoulette(){
		motherBlock.SendMessage ("Roulette", 6);
	}
		
	public static void SetMotherBlock(NeoBlock motherB){
		motherBlock = motherB;
	}
}
