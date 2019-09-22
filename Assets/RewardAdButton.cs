using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;

public class RewardAdButton : MonoBehaviour {
	//private static NeoBlock[] motherBlock = new NeoBlock[2];
	public static RewardAdButton[] instances = new RewardAdButton[2];
	private NeoBlock motherBlock;
	//this variable is just for test
	public static bool isChoosing = false;
	public bool isTest = false;
    private bool handlerAdded = false;
	private const int MAX_AD_NUM = 2;
	private static int counter = 0;

	private bool is_tuto = false;
	public GameObject blinder;
	public GameObject blinderCircle;

	void Awake(){
		//instance = GetComponent<RewardAdButton> ();
		if (instances [0] == null) {
			instances [0] = GetComponent<RewardAdButton>();
		} else {
			instances [1] = GetComponent<RewardAdButton>();
		}
		DontDestroyOnLoad (this.gameObject);
		AdMobManager.LoadAd ("reward");
        handlerAdded = false;
	}

	void OnLevelWasLoaded(int level) {
		if (level == 9) {
			is_tuto = true;

			blinder.SetActive (true);
			blinderCircle.SetActive (true);
		} else {
			is_tuto = false;

			blinder.SetActive (false);
			blinderCircle.SetActive (false);
		}

		string[] notStages = {"Void", "Intermid", "start2", "loading"};
		Debug.Log ("OnSceneLoaded: " + level);
		if (level > 2) {
			AdMobManager.LoadAd ("reward");
		}
		counter = 0;
	}

	void Start () {
		isChoosing = false;
	}

	void Update() {
		//Debug.Log (isChoosing);
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
        //handling for tutorial stages: 1,2,3,5,7
        Debug.Log("RewardAd button pressed");
		int buildIndex = SceneManager.GetActiveScene ().buildIndex;
		if (buildIndex == 2 || buildIndex == 3 || buildIndex == 4 || buildIndex == 6 || buildIndex == 8) {
			return;
		}
	
		if (!isChoosing) {
			if (isTest) {
				if (counter >= MAX_AD_NUM) {
					return;
				}
				StartRoulette ();
				isChoosing = true;
				StartCoroutine ("CheckTouch");
				counter++;
				return;
			}
            if (!handlerAdded)
            {
                handlerAdded = true;
                AdMobManager.rewardAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
            }
            //AdMobManager.LoadAd ("reward");
            AdMobManager.ShowAd ("reward");
			//StartRoulette ();
			//isChoosing = true;

		}

		//else {
			//RewardRoulette.mode = false;
			//int chosenColor = RewardRoulette.rouletteCircle.StopRoulette ();
			//Debug.Log (chosenColor);
			//if (chosenColor != -1) {
			//	AddBlock (chosenColor);
			//}
			//isChoosing = false;
		//}

		// GJ's CODE
		if (is_tuto) {
			blinder.SetActive (false);
			blinderCircle.SetActive (false);
		}
		//

		GetComponent<SpriteRenderer> ().color = new Color (255, 0, 0, 0.5f);
	}

	IEnumerator CheckTouch(){
		yield return new WaitForSeconds (0.5f);
		while (!Input.GetMouseButton(0)) {
			yield return new WaitForEndOfFrame ();
		}

		RewardRoulette.mode = false;
	}

	void OnMouseUp(){
		GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 0.5f);
	}

	void HandleRewardBasedVideoRewarded(object sender, Reward args){
		StartRoulette ();
        StartCoroutine("CheckTouch");
		isChoosing = true;
		AdMobManager.LoadAd ("reward");
	}

	public static void AddBlock(int color, int index){
		if (color > 7 || color < 0) {
			throw new UnityException ("unvalid color number");
		}
		instances [index].motherBlock.SendMessage ("AddBlock", color);
	}

	public static void ChangeNumberBlack(int color, int index){
		
		instances[index].motherBlock.SendMessage ("ChangeNumberBlack", color);
	}

	public static void ChangeNumberWhite(int color, int index){
		instances[index].motherBlock.SendMessage ("ChangeNumberWhite", color);
	}

	void StartRoulette(){
		motherBlock.SendMessage ("Roulette", 6);
	}

	public static int SetMotherBlock(NeoBlock motherB){
		if (!instances [0].motherBlock) {
			instances [0].motherBlock = motherB;
			return 0;
		} else {
			instances [1].motherBlock = motherB;
			return 1;
		}
	}

	public static void Close(int index){
		instances [index].GetComponent<Animator> ().SetTrigger ("Close");
		instances [index].motherBlock = null;
	}

	public static void Open(int index){
		instances [index].GetComponent<Animator> ().SetTrigger ("Open");
	}

	public static void movePos(Vector3 des, int index){
		instances [index].transform.position = des;
	}
}
