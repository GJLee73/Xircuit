using UnityEngine;
using System.Collections;

public class WifiFake : MonoBehaviour {
	private SpriteRenderer S; 

	void Awake(){
		S = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ball")) {
			other.GetComponent<Rigidbody2D>().Sleep();
			//Debug.Log ("QWER");
			ColorChange(other.gameObject.layer-8, S);
		}
	}

	void ColorChange(int C, SpriteRenderer Sp){
		if (C.Equals (0)) {
			Sp.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		}
		else if (C.Equals (1)) {
			Sp.color = new Color (1.0f, 0.0f, 0.0f, 1.0f);
		}
		else if (C.Equals (2)) {
			Sp.color = new Color (0.0f, 1.0f, 0.0f, 1.0f);
		}
		else if (C.Equals (3)) {
			Sp.color = new Color (1.0f, 1.0f, 0.0f, 1.0f);
		}
		else if (C.Equals (4)) {
			Sp.color = new Color (0.0f, 0.0f, 1.0f, 1.0f);
		}
		else if (C.Equals (5)) {
			Sp.color = new Color (1.0f, 0.0f, 1.0f, 1.0f);
		}
		else if (C.Equals (6)) {
			Sp.color = new Color (0.0f, 1.0f, 1.0f, 1.0f);
		}
		else if (C.Equals (7)) {
			Sp.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		}
	}

	void Playing(){

	}

	void Reset(){
		S.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
	}
}
