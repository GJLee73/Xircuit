using UnityEngine;
using System.Collections;

public class ChoosingBlock : MonoBehaviour {
	public GameObject MotherBlock;
	public bool Enabled;
	public int BlockColor;
	private static int[] BlockCount = new int[8];
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
		if (isActivated) {
			BlockCount [BlockColor] = MotherBlock.GetComponent<NeoBlock> ().BlockNumber [BlockColor];
			Number.sprite = NumberSprite [BlockCount [BlockColor]];
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



	void ResetNumber(){
		if (isActivated) {
			Number.sprite = NumberSprite [BlockCount [BlockColor]];
			if (BlockCount [BlockColor].Equals (0)) {
				//S.enabled = false;
				C.enabled = false;
			} else if (BlockCount [BlockColor] > 0) {
				S.enabled = true;
				C.enabled = true;
			}
		}
	}

	// Update is called once per frame
	void OnMouseDown(){
		if (isActivated&&Enabled&&BlockCount[BlockColor]>0) {
			
			//Number.transform.position = T.position + K * new Vector3 (Co, Si, 0.0f);
			MotherBlock.SendMessage ("Cloose", BlockColor);
			BlockCount[BlockColor]--;
			Number.sprite = NumberSprite[BlockCount[BlockColor]];
			if(BlockCount[BlockColor].Equals(0)){
				//S.enabled = false;
				C.enabled = false;
			}

		}
	}

	void Plus(){
		if (isActivated) {
			BlockCount [BlockColor]++;
			Number.sprite = NumberSprite [BlockCount [BlockColor]];
			S.enabled = true;
			C.enabled = true;
		}
	}


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
}
