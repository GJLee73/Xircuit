using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;

public class RewardAdButton : MonoBehaviour {
	private static NeoBlock motherBlock;
	public static GameObject instance;

	//this variable is just for test
	public static bool isChoosing = false;
	public bool isTest = false;

	void Awake(){
		//instance = GetComponent<RewardAdButton> ();
		instance = this.gameObject;
		DontDestroyOnLoad (this.gameObject);
		AdMobManager.LoadAd ("reward");
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		string[] notStages = {"Void", "Intermid", "start2", "loading"};
		Debug.Log ("OnSceneLoaded: " + scene.name);
		if (scene.buildIndex > 2 && !Array.Exists (notStages, element=>element == scene.name)) {
			AdMobManager.LoadAd ("reward");
		}
	}

	void Start () {
		isChoosing = false;
	}
	
	// Update is called once per frame


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


		if (isTest) {

		}
		if (!isChoosing) {
			if (isTest) {
				StartRoulette ();
				isChoosing = true;
			}
			AdMobManager.rewardAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
			//AdMobManager.LoadAd ("reward");
			AdMobManager.ShowAd ("reward");
			//StartRoulette ();
			//isChoosing = true;
		} else {
			int chosenColor = RewardRoulette.rouletteCircle.StopRoulette ();
			AddBlock (chosenColor);
			isChoosing = false;
		}
		GetComponent<SpriteRenderer> ().color = new Color (255, 0, 0);
	}

	void OnMouseUp(){
		GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
	}

	void HandleRewardBasedVideoRewarded(object sender, Reward args){
		StartRoulette ();
		isChoosing = true;
		AdMobManager.LoadAd ("reward");
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
