using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewardRoulette : MonoBehaviour {
	public static RewardRoulette rouletteCircle;
	private int chosenSection = -1;
	//public AudioClip[] audios = new AudioClip[12];
	public AudioClip new_audio;
	public static bool mode = true;
	public float fixedv = 0.01f;
	public float acc = 0.001f;
	public int count = 10;
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
		//Transform tr;

		this.GetComponent<SpriteRenderer> ().enabled = true;
		RewardAdButton.isChoosing = true;
		while (mode) {
			for (counter = 0; counter < arg.Count; counter++) {
				//GetComponent<AudioSource> ().clip = audios [counter % 12];
				//GetComponent<AudioSource> ().Play ();
				transform.eulerAngles = arg[counter].eulerAngles;
				transform.position = arg[counter].position;
				//chosenSection = arg[counter].GetComponent<ChoosingBlock> ().BlockColor;
				yield return new WaitForSeconds (fixedv);
			}
		}
		float v = fixedv;
		int cnt = 0;
		int rewardIndex = -1;
		if (arg [0]) {
			rewardIndex = arg [0].GetComponent<ChoosingBlock>().MotherBlock.GetComponent<NeoBlock>().rewardIndex;
		}
		while (!mode) {
			v += fixedv;
			cnt++;
			counter = (counter + 1) % arg.Count;
			transform.eulerAngles = arg[counter].eulerAngles;
			transform.position = arg[counter].position;
			chosenSection = arg[counter].GetComponent<ChoosingBlock> ().BlockColor;
			if (cnt == count) {
				RewardAdButton.ChangeNumberWhite (chosenSection, rewardIndex);
				RewardAdButton.AddBlock (chosenSection, rewardIndex);
				//RewardAdButton.instance.SendMessage ("AddBlock", chosenSection);
				yield return new WaitForSeconds (1.0f);
				RewardAdButton.isChoosing = false;
				this.GetComponent<SpriteRenderer> ().enabled = false;
				mode = true;
				RewardAdButton.ChangeNumberBlack (chosenSection, rewardIndex);
				break;
			}
			yield return new WaitForSeconds (v);
		}
	}

	/*public int StopRoulette(){
		//stop the roultette and return the color of chosen section
		StopCoroutine ("RouletteAnim");
		this.GetComponent<SpriteRenderer> ().enabled = false;
		return chosenSection;
	}*/
}
