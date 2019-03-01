using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;

public class NeoButton : MonoBehaviour {
	public SpriteRenderer blinder;
	public float FadeInSpeed = 0.05f;
	public float FadeOutSpeed = 0.05f;
	private bool isStage = true;
	private int Count;
	public SpriteRenderer S1, S2;
	public Sprite[] Numbers;
	private Transform T1, T2;
	public int A;
	private bool isChanging;
	public AudioClip Sound, Sound2;
	private AudioSource Au;
	public AudioSource BGMPlayer1 ,BGMPlayer2;
	private bool T = false;
	private Transform Tr;
	public AudioClip BGM2;
	public AudioSource SoundPlayer2;
	public Sprite Thanksto;
	// Use this for initialization

	void Update () {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit ();
			}
		}
	}

	void Awake(){
		Tr = transform;
		if (((float)Screen.width / Screen.height) > 1.59f && ((float)Screen.width / Screen.height) < 1.61f) {  //16/10
			Tr.position = new Vector3 (33.0f, -20.0f, 0.0f);
			blinder.transform.localScale = new Vector3 (4.0f, 4.5f, 1.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.3f) && (((float)Screen.width / Screen.height) < 1.35f)) { //4/3
			Tr.position = new Vector3 (33.0f, -24.0f, 0.0f);
			blinder.transform.localScale = new Vector3 (4.0f, 5.5f, 1.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.65f) && (((float)Screen.width / Screen.height) < 1.7f)) { //5/37
			Tr.position = new Vector3 (34.0f, -20.0f, 0.0f);
			blinder.transform.localScale = new Vector3 (4.0f, 4.5f, 1.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			Tr.position = new Vector3 (31.0f, -20.0f, 0.0f);
			blinder.transform.localScale = new Vector3 (4.3f, 4.6f, 1.0f);
		}
		BGMPlayer1 = GameObject.Find ("BGM").GetComponent<AudioSource> ();
		StartCoroutine ("SoundFade", BGMPlayer1);
		//BGMPlayer2.Play ();
		T = true;
		Au = GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("LastPlayedStage").Equals (0)) {
			Count = 1;
		}
		else{
			Count = PlayerPrefs.GetInt ("LastPlayedStage");
		}
		/*if (Screen.width.Equals (800) && Screen.height.Equals (480)) {
			Camera.main.orthographicSize = 21.5f;
		} else if (Screen.width.Equals (1280) && Screen.height.Equals (720)) {
			Camera.main.orthographicSize = 20.0f;
		}*/
		S1.sprite = null;
		T1 = S1.transform;
		T2 = S2.transform;


		DontDestroyOnLoad (S1);
		DontDestroyOnLoad (S2);
		DontDestroyOnLoad (blinder);
		DontDestroyOnLoad (this);

		if (Application.loadedLevelName.Equals ("Intermid")||Application.loadedLevelName.Equals("Void")) {
			
			isStage = false;
		} else{
			
			isStage = true;
		}
		if (Count.Equals (61)) {
			S1.sprite = null;
			T2.position = new Vector3 (-0.5f, -1.25f, 0.0f);
			S2.sprite = Thanksto;
			T2.localScale = new Vector3 (1.5f, 1.5f, 1.0f);
		} else {
			T2.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			if (!((Count / 10).Equals (0))) {
				T1.position = new Vector3 (-2.0f, 0.0f, 0.0f);
				T2.position = new Vector3 (2.0f, 0.0f, 0.0f);
				S1.sprite = Numbers [Count / 10];
			} else if ((Count / 10).Equals (0)) {
				S1.sprite = null;
				T2.position = new Vector3 (0.0f, 0.0f, 0.0f);
			}
			S2.sprite = Numbers [Count % 10];
		}
		if (!isStage) {
			StartCoroutine ("ChangeScene", Count);
		}
	}
		

	IEnumerator SoundFade(AudioSource Source){
		while (Source.volume > 0.0f) {
			Source.volume -= 0.1f;
			yield return new WaitForSeconds (0.1f);
		}
		BGMPlayer2.Play ();
	}	

	void OnLevelWasLoaded(){
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
			Camera.main.orthographicSize = 23.0f;
		} else if ((((float)Screen.width / Screen.height)>1.7f)&&(((float)Screen.width/Screen.height)<1.8f)) { //16/9
			//Debug.Log ("BB");
			Camera.main.orthographicSize =20.0f;
		} else if ((((float)Screen.width / Screen.height)>1.3f)&&(((float)Screen.width/Screen.height)<1.35f)) { //4/3
			Camera.main.orthographicSize = 28.0f;
		} else if ((((float)Screen.width / Screen.height)>1.65f)&&(((float)Screen.width/Screen.height)<1.7f)) { //5/37
			//Debug.Log ("DD");
			Camera.main.orthographicSize = 23.0f;
		}else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			Camera.main.orthographicSize = 23.0f;
		}
		PlayerPrefs.SetInt ("LastPlayedStage", Count);
			DontDestroyOnLoad (S1);
			DontDestroyOnLoad (S2);
			DontDestroyOnLoad (blinder);
			DontDestroyOnLoad (this);

		if (Application.loadedLevelName.Equals ("Intermid")||Application.loadedLevelName.Equals("Void")) {
			
			isStage = false;
		} else{
			
			isStage = true;
		}

		if (isStage) {
			StartCoroutine ("Fade", 1);
		}
	}

	void Start () {

		if (isStage) {
			//Debug.Log ("Stage");
			StartCoroutine ("Fade", 1);
		}
	}

	IEnumerator StageCleared(){
		if (Count > PlayerPrefs.GetInt ("ClearedStage")) {
			PlayerPrefs.SetInt ("ClearedStage", Count);
		}
		AdMobManager.LoadAd ("interstitial");
		AdMobManager.interstitialAd.OnAdClosed += AdClosedHandler;

		//AdMobManager.interstitialAd.OnAdClosed += AdClosedHandler;
		//AdMobManager.LoadAd ("interstitial");
		isChanging = true;
		Count++;
		if (!((Count / 10).Equals (0))) {
			T1.position = new Vector3 (-2.0f, 0.0f, 0.0f);
			T2.position = new Vector3 (2.0f, 0.0f, 0.0f);
			S1.sprite = Numbers [Count / 10];
		} else if ((Count / 10).Equals (0)) {
			S1.sprite = null;
			T2.position = new Vector3 (0.0f, 0.0f, 0.0f);
		}
		S2.sprite = Numbers [Count % 10];
		while (blinder.color.a<1.0f) {
			blinder.color += new Color (0.0f, 0.0f, 0.0f, FadeOutSpeed/2);
			yield return new WaitForSeconds (0.05f);
		}
		while (S1.color.a < 1.0f) {
			S1.color += new Color (0.0f, 0.0f, 0.0f, FadeInSpeed/2);
			S2.color += new Color (0.0f, 0.0f, 0.0f, FadeInSpeed/2);
			yield return new WaitForSeconds (0.05f);
		}
		S1.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		S2.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		// 2019/2/25 추가한 구글 애드몹 관련 코드
		AdMobManager.ShowAd("interstitial");


		// 2019/2/25 추가한 구글 애드몹 관련 코드
		//StartCoroutine ("ChangeScene", Count);
		//isChanging = false;
	}

	private void AdClosedHandler(object sender, EventArgs args){
		Application.LoadLevel ("Void");
		StartCoroutine ("ChangeScene", Count);
		isChanging = false;
		AdMobManager.DestroyAd ("interstitial");
	}

	// Update is called once per frame
	void OnMouseDown(){
		//Debug.Log (Count);

		if (PlayerPrefs.GetInt ("ClearedStage") + 1 > Count && !isChanging) {
			if (Count < 61) {
				T2.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				Tr.localScale = new Vector3 (0.6f, 0.6f, 1.0f);
				Au.clip = Sound;
				Au.Play ();
				if (isStage) {
					StopCoroutine ("Fade");
					StartCoroutine ("Fade", -1);
					Count++;
					if (!Count.Equals (61)) {
						if (!((Count / 10).Equals (0))) {
							T1.position = new Vector3 (-2.0f, 0.0f, 0.0f);
							T2.position = new Vector3 (2.0f, 0.0f, 0.0f);
							S1.sprite = Numbers [Count / 10];
						} else if ((Count / 10).Equals (0)) {
							S1.sprite = null;
							T2.position = new Vector3 (0.0f, 0.0f, 0.0f);
						}
						S2.sprite = Numbers [Count % 10];
					} else {
						S1.sprite = null;
						T2.position = new Vector3 (-0.5f, -1.25f, 0.0f);
						S2.sprite = Thanksto;
						T2.localScale = new Vector3 (1.5f, 1.5f, 1.0f);
					}
					StopCoroutine ("ChangeScene");

					//StartCoroutine ("ChangeScene", Count);
				} else {

					StopCoroutine ("ChangeScene");
					Count++;
					if (!Count.Equals (61)) {
						if (!((Count / 10).Equals (0))) {
							T1.position = new Vector3 (-2.0f, 0.0f, 0.0f);
							T2.position = new Vector3 (2.0f, 0.0f, 0.0f);
							S1.sprite = Numbers [Count / 10];
						} else if ((Count / 10).Equals (0)) {
							S1.sprite = null;
							T2.position = new Vector3 (0.0f, 0.0f, 0.0f);
						}
						S2.sprite = Numbers [Count % 10];
					} else {
						S1.sprite = null;
						T2.position = new Vector3 (-0.5f, -1.25f, 0.0f);
						S2.sprite = Thanksto;
						T2.localScale = new Vector3 (1.5f, 1.5f, 1.0f);
					}
					StartCoroutine ("ChangeScene", Count);
			
				} 
			}

		} else if (Count.Equals (61)) {
			T2.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			Tr.localScale = new Vector3 (0.6f, 0.6f, 1.0f);
			Au.clip = Sound;
			Au.Play ();
			if (isStage) {
				StopCoroutine ("Fade");
				StartCoroutine ("Fade", -1);
				Count = 1;

				if (!((Count / 10).Equals (0))) {
					T1.position = new Vector3 (-2.0f, 0.0f, 0.0f);
					T2.position = new Vector3 (2.0f, 0.0f, 0.0f);
					S1.sprite = Numbers [Count / 10];
				} else if ((Count / 10).Equals (0)) {
					S1.sprite = null;
					T2.position = new Vector3 (0.0f, 0.0f, 0.0f);
				}
				S2.sprite = Numbers [Count % 10];
				StopCoroutine ("ChangeScene");
				//StartCoroutine ("ChangeScene", Count);
			} else {

				StopCoroutine ("ChangeScene");
				Count = 1;

				if (!((Count / 10).Equals (0))) {
					T1.position = new Vector3 (-2.0f, 0.0f, 0.0f);
					T2.position = new Vector3 (2.0f, 0.0f, 0.0f);
					S1.sprite = Numbers [Count / 10];
				} else if ((Count / 10).Equals (0)) {
					S1.sprite = null;
					T2.position = new Vector3 (0.0f, 0.0f, 0.0f);
				}
				S2.sprite = Numbers [Count % 10];
				StartCoroutine ("ChangeScene", Count);

			}
		}
	}

	void OnMouseUp(){
		if (Tr.localScale.x.Equals(0.6f)) {
			Tr.localScale = new Vector3 (0.5f, 0.5f, 1.0f);
			SoundPlayer2.clip = Sound2;
			SoundPlayer2.Play ();
		}
	}

	IEnumerator ChangeScene(int ind){
		yield return new WaitForSeconds (1.0f);
		Application.LoadLevel (ind+1);
	}

	IEnumerator Fade(int i){
		if (i.Equals (-1)) {
			while (blinder.color.a<1.0f) {
				blinder.color += new Color (0.0f, 0.0f, 0.0f, FadeInSpeed);
				yield return new WaitForSeconds (0.05f);
			}
			while (S1.color.a < 1.0f) {
				S1.color += new Color (0.0f, 0.0f, 0.0f, FadeInSpeed);
				S2.color += new Color (0.0f, 0.0f, 0.0f, FadeInSpeed);
				yield return new WaitForSeconds (0.05f);
			}
			Application.LoadLevel ("Void");
			StopCoroutine ("ChangeScene");
			StartCoroutine ("ChangeScene", Count);
		} else if (i.Equals (1)) {
			while (S1.color.a>0.0f) {
				S1.color -= new Color (0.0f, 0.0f, 0.0f, FadeInSpeed);
				S2.color -= new Color (0.0f, 0.0f, 0.0f, FadeInSpeed);
				yield return new WaitForSeconds (0.05f);
			}
			while (blinder.color.a > 0.0f) {
				blinder.color -= new Color (0.0f, 0.0f, 0.0f, FadeInSpeed);
				yield return new WaitForSeconds (0.05f);
			}
			if (T) {
				
				T = false;
				//BGMPlayer2.Play ();
			}
		}
	}

	void Minus(){
		if ((Count > 1)&&!isChanging) {
			T2.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			if (!isStage) {
				StopCoroutine ("ChangeScene");
				Count--;
				if (!((Count / 10).Equals (0))) {
					T1.position = new Vector3 (-2.0f, 0.0f, 0.0f);
					T2.position = new Vector3 (2.0f, 0.0f, 0.0f);
					S1.sprite = Numbers [Count / 10];
				} else if ((Count / 10).Equals (0)) {
					S1.sprite = null;
					T2.position = new Vector3 (0.0f, 0.0f, 0.0f);
				}
				S2.sprite = Numbers [Count % 10];
				StartCoroutine ("ChangeScene", Count);
			} else {
				StopCoroutine ("Fade");
				StartCoroutine ("Fade", -1);
				Count--;
				if (!((Count / 10).Equals (0))) {
					T1.position = new Vector3 (-2.0f, 0.0f, 0.0f);
					T2.position = new Vector3 (2.0f, 0.0f, 0.0f);
					S1.sprite = Numbers [Count / 10];
				} else if ((Count / 10).Equals (0)) {
					S1.sprite = null;
					T2.position = new Vector3 (0.0f, 0.0f, 0.0f);
				}
				S2.sprite = Numbers [Count % 10];
			}
		}
		else if (Count.Equals (1) && !isChanging && PlayerPrefs.GetInt ("ClearedStage").Equals(60)) {
			if (!isStage) {
				StopCoroutine ("ChangeScene");
				Count = 61;
				S1.sprite = null;
				T2.position = new Vector3 (-0.5f, -1.25f, 0.0f);
				S2.sprite = Thanksto;
				T2.localScale = new Vector3 (1.5f, 1.5f, 1.0f);
				StartCoroutine ("ChangeScene", Count);
			} else {
				StopCoroutine ("Fade");
				StartCoroutine ("Fade", -1);
				Count = 61;
				S1.sprite = null;
				T2.position = new Vector3 (-0.5f, -1.25f, 0.0f);
				S2.sprite = Thanksto;
				T2.localScale = new Vector3 (1.5f, 1.5f, 1.0f);
			}
		}

	}
}
