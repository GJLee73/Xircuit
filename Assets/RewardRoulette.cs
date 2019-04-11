using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewardRoulette : MonoBehaviour {
	public static RewardRoulette rouletteCircle;
	private int chosenSection = -1;
	//public AudioClip[] audios = new AudioClip[12];
	public AudioClip new_audio;
	// Use this for initialization
	void Awake(){
		rouletteCircle = this.GetComponent<RewardRoulette> ();
		DontDestroyOnLoad (this);
		GetComponent<AudioSource> ().clip = new_audio;
	}

	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator RouletteAnim(List<Transform> arg){
		int counter = 0;

		this.GetComponent<SpriteRenderer> ().enabled = true;
		RewardAdButton.isChoosing = true;
		while (true) {
			foreach (Transform tr in arg) {
				//GetComponent<AudioSource> ().clip = audios [counter % 12];
				//GetComponent<AudioSource> ().Play ();
				transform.eulerAngles = tr.eulerAngles;
				transform.position = tr.position;
				chosenSection = tr.GetComponent<ChoosingBlock> ().BlockColor;
				counter++;
				yield return new WaitForSeconds (0.1f);
			}
		}
	}

	public int StopRoulette(){
		//stop the roultette and return the color of chosen section
		StopCoroutine ("RouletteAnim");
		this.GetComponent<SpriteRenderer> ().enabled = false;
		return chosenSection;
	}
}
