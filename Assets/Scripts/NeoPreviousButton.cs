using UnityEngine;
using System.Collections;

public class NeoPreviousButton : MonoBehaviour {
	public GameObject NextButton;
	private static bool isExisting = false;
	public AudioClip Sound, Sound2;
	private AudioSource Au;
	public AudioSource SoundPlayer2;
	private Transform Tr;
	// Use this for initialization
	void Awake(){
		Tr = transform;
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
			Tr.position = new Vector3(-33.0f, -20.0f, 0.0f);
		}  else if ((((float)Screen.width / Screen.height)>1.3f)&&(((float)Screen.width/Screen.height)<1.35f)) { //4/3
			Tr.position = new Vector3(-33.0f, -24.0f, 0.0f);
		} else if ((((float)Screen.width / Screen.height)>1.65f)&&(((float)Screen.width/Screen.height)<1.7f)) { //5/37
			Tr.position = new Vector3(-34.0f, -20.0f, 0.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			Tr.position = new Vector3 (-31.0f, -20.0f, 0.0f);
		}
		Au = GetComponent<AudioSource> ();
		if (!isExisting) {
			isExisting = true;
		} else if (isExisting) {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this);
	}

	void OnMouseDown(){
		Tr.localScale = new Vector3 (0.6f, 0.6f, 0.6f);
		Au.clip = Sound;
		Au.Play ();
		NextButton.SendMessage ("Minus");
	}

	void OnMouseUp(){
		SoundPlayer2.clip = Sound2;
		SoundPlayer2.Play ();
		Tr.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
	}
}
