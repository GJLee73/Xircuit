using UnityEngine;
using System.Collections;

public class RewardAdButton : MonoBehaviour {
	public NeoBlock motherBlock;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		int randomColor = Random.Range (0, 8);
		//AddBlock (randomColor);
		StartRoulette();
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
}
