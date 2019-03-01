using UnityEngine;
using System.Collections;

public class CornerChangeColor : MonoBehaviour {
	private SpriteRenderer S;
	// Use this for initialization
	void Awake () {
		S = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ball")) {
			//Debug.Log ("QQ");
			ChangeColor(other.gameObject.layer-8);
		}
	}

	void ChangeColor(int C){
		if (C.Equals (0)) {
			S.color -= new Color(1.0f, 1.0f, 1.0f, 0.0f);
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
	}

	void Reset(){
		ChangeColor (0);
	}

	void Playing(){

	}

}
