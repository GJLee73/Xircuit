using UnityEngine;
using System.Collections;

public class ChoosingBlock : MonoBehaviour {
	public GameObject MotherBlock;
	public bool Enabled;
	public int BlockColor;
	public Sprite[] NumberSprite;
	public SpriteRenderer Number;
	public SpriteRenderer Border;
	private SpriteRenderer S;
	private CircleCollider2D C;
	//private float Co, Si;
	private Transform T;
	public float K;
	private bool M;
	public bool isActivated = true;
	private Animator An;
	private static bool rewardButtonShown = false;
	// Use this for initialization
	void Awake(){
		Enabled = true;
		An = GetComponent<Animator> ();
		//An.SetTrigger ("Stop");
		M = true;
		T = transform;
		S = GetComponent<SpriteRenderer> ();
		C = GetComponent<CircleCollider2D> ();
		ChangeColor (BlockColor);
		Hide ();
	}

	void Start(){
		if (isActivated) {
			Number.sprite = NumberSprite [NeoBlock.GetBlockNum(BlockColor)];
		}
		else if (!isActivated) {
			Number.sprite = null;
		}
	}

	void RemoveSelf(){
		this.gameObject.SetActive (false);
	}

	void RemoveBigone(){
		MotherBlock.SendMessage ("RemoveBigone");
	}

	void MakeBigOne(){
		MotherBlock.SendMessage ("MakeBigOne");
	}

	void Close(){
		//Debug.Log ("Close");
		rewardButtonShown = false;
		RewardAdButton.instance.gameObject.SetActive (false);
		Enabled = false;
		An.SetTrigger ("Close");
	}

	void Open(){
		//Debug.Log ("Open");
		Show ();
		ResetNumber ();
		Enabled = true;
		An.SetTrigger ("Open");
	}


	void Hide(){
		//S.sortingLayerName = "Default";
		//S.sortingOrder = -1;
		S.enabled = false;
		C.enabled = false;
		Number.enabled = false;
		Border.enabled = false;
	}

	void Show(){
		//S.sortingLayerName = "Block";
		//Number.enabled = true;
		Border.enabled = true;
		S.enabled = true;
		C.enabled = true;
		if (M) {
			M = false;
			Number.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			//Number.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		}
		Number.enabled = true;
	}



	public void ResetNumber(){
		if (NeoBlock.GetBlockNum(BlockColor) > 0) {
			isActivated = true;
		}
		if (isActivated) {
			Number.sprite = NumberSprite [NeoBlock.GetBlockNum(BlockColor)];
			if (NeoBlock.GetBlockNum(BlockColor).Equals (0)) {
				//S.enabled = false;
				C.enabled = false;
			} else if (NeoBlock.GetBlockNum(BlockColor) > 0) {
				S.enabled = true;
				C.enabled = true;
			}
		}
	}

	// Update is called once per frame
	void OnMouseDown(){
		if (RewardAdButton.isChoosing) {
			return;
		}
		int BlockNum = NeoBlock.GetBlockNum (BlockColor);
		if (isActivated&&Enabled&&BlockNum>0) {
			
			//Number.transform.position = T.position + K * new Vector3 (Co, Si, 0.0f);
			MotherBlock.SendMessage ("Cloose", BlockColor);
			MotherBlock.SendMessage("ReduceBlock", BlockColor);
			Number.sprite = NumberSprite[BlockNum];
			if(BlockNum.Equals(0)){
				//S.enabled = false;
				C.enabled = false;
			}

		}
	}

	/*public void Plus(){
		if (!isActivated) {
			isActivated = true;
		}
		//if (isActivated) {
		//BlockCount [BlockColor]++;
		Number.sprite = NumberSprite [NeoBlock.GetBlockNum(BlockColor)];
		S.enabled = true;
		C.enabled = true;
		//}
	}*/



	void ChangeColor(int C){
		if (C.Equals (0)) {
			S.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
		}
		if (C.Equals (1)) {
			S.color = new Color(230/255f, 0.0f, 18/255f, 1.0f);
		}
		if (C.Equals (2)) {
			S.color = new Color(0.0f, 153/255f, 68/255f, 1.0f);
		}
		if (C.Equals (3)) {
			S.color = new Color(249/255f, 230/255f, 47/255f, 1.0f);
		}
		if (C.Equals (4)) {
			S.color = new Color(0.0f, 71/255f, 157/255f, 1.0f);
		}
		if (C.Equals (5)) {
			S.color = new Color(228/255f, 0.0f, 180/255f, 1.0f);
		}
		if (C.Equals (6)) {
			S.color = new Color(0.0f, 160/255f, 233/255f, 1.0f);
		}
		if (C.Equals (7)) {
			S.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
		S.color -= new Color (0.0f, 0.0f, 0.0f, 150 / 255f);
	}

	public void ShowRewardAdButton(){
		if (!rewardButtonShown) {
			rewardButtonShown = true;
			RewardAdButton.instance.gameObject.SetActive (true);	
		}
	}

	public void RemoveRewardAdButton() {
		if (rewardButtonShown) {
			rewardButtonShown = false;
			RewardAdButton.instance.gameObject.SetActive (false);
		}
	}
}
