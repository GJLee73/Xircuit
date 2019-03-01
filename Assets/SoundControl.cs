using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {
	public AudioSource BGMPlayer;
	private bool SoundOn;
	public Sprite[] Sprites;
	private SpriteRenderer S;
	private Transform Tr;
	// Use this for initialization
	void Awake(){
		Tr = transform;
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
			Tr.position = new Vector3(33.0f, 19.5f, 0.0f);
		} else if ((((float)Screen.width / Screen.height)>1.3f)&&(((float)Screen.width/Screen.height)<1.35f)) { //4/3
			Tr.position = new Vector3(33f, 24.5f, 0.0f);
		} else if ((((float)Screen.width / Screen.height)>1.65f)&&(((float)Screen.width/Screen.height)<1.7f)) { //5/3
			Tr.position = new Vector3(34f, 19.5f,0.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			Tr.position = new Vector3(30.5f, 19.5f, 0.0f);
		}
		DontDestroyOnLoad (this.gameObject);
		SoundOn = true;
		S = GetComponent<SpriteRenderer> ();
	}

	void OnMouseDown(){
		if (SoundOn) {
			SoundOn = false;
			S.sprite = Sprites [1];
			BGMPlayer.mute = true;
		} else {
			SoundOn = true;
			S.sprite = Sprites [0];
			BGMPlayer.mute = false;
		}
	}
}
