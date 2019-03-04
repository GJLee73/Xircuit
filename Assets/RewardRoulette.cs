using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewardRoulette : MonoBehaviour {
	public static RewardRoulette rouletteCircle;
	private int chosenSection = -1;
	// Use this for initialization
	void Awake(){
		rouletteCircle = this.GetComponent<RewardRoulette> ();
		DontDestroyOnLoad (this);
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator RouletteAnim(List<Transform> arg){
		this.GetComponent<SpriteRenderer> ().enabled = true;
		while (true) {
			foreach (Transform tr in arg) {
				transform.eulerAngles = tr.eulerAngles;
				transform.position = tr.position;
				chosenSection = tr.GetComponent<ChoosingBlock> ().BlockColor;
				yield return new WaitForSeconds (1.0f);
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
