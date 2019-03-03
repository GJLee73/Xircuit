using UnityEngine;
using System.Collections;

public class RewardButton : MonoBehaviour {

	public NeoBlock motherBlock;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		int randomColor = Random.Range (0, 8);
		AddBlock (randomColor);
	}

	void AddBlock(int color, int amount = 1){
		if (color > 7 || color < 0) {
			throw new UnityException ("unvalid color number");
		}
		int[] args = new int[] {color, amount};
		motherBlock.SendMessage ("AddBlock", color);
	}

	private class Roulette: MonoBehaviour {
		public GameObject effectCircle;

	}
}
