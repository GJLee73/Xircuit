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

	void Update() {
		//Debug.Log (isChoosing);
	}

	// Update is called once per frame


	void OnMouseDown(){
		Debug.Log ("sdsddsds");
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
		//handling for tutorial stages: 1,2,3,5,7
		int buildIndex = SceneManager.GetActiveScene ().buildIndex;
		if (buildIndex == 2 || buildIndex == 3 || buildIndex == 4 || buildIndex == 6 || buildIndex == 8) {
			return;
		}
	
		if (!isChoosing) {
			if (isTest) {
				StartRoulette ();
				//isChoosing = true;
			}
			AdMobManager.rewardAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
			//AdMobManager.LoadAd ("reward");
			AdMobManager.ShowAd ("reward");
			//StartRoulette ();
			//isChoosing = true;
		} else {
			RewardRoulette.mode = false;
			//int chosenColor = RewardRoulette.rouletteCircle.StopRoulette ();
			//Debug.Log (chosenColor);
			//if (chosenColor != -1) {
			//	AddBlock (chosenColor);
			//}
			//isChoosing = false;
		}
		GetComponent<SpriteRenderer> ().color = new Color (255, 0, 0, 0.5f);
	}

	void OnMouseUp(){
		GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 0.5f);
	}

	void HandleRewardBasedVideoRewarded(object sender, Reward args){
		StartRoulette ();
		isChoosing = true;
		AdMobManager.LoadAd ("reward");
	}

	void AddBlock(int color){
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
