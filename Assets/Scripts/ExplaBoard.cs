using UnityEngine;
using System.Collections;

public class ExplaBoard : MonoBehaviour {
	public SpriteRenderer[] SS;
	private SpriteRenderer S;

	void Awake(){
		S = GetComponent<SpriteRenderer> ();
		for (int i = 0; i < 19; i++) {
			SS [i].color = new Color (SS [i].color.r, SS [i].color.g, SS [i].color.b, 0.0f);
		}
		S.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
	}

	void Fade(int k){
		StartCoroutine (Fade (k, S, 150/255f));
		for (int i = 0; i < 19; i++) {
			StartCoroutine(Fade(k, SS[i], 1.0f));
		}
	}

	// Use this for initialization
	IEnumerator Fade(int D, SpriteRenderer Expla, float Dest){
		if (D.Equals (1)) {
			while (Expla.color.a < Dest) {
				Expla.color += new Color (0.0f, 0.0f, 0.0f, 0.01f);
				yield return new WaitForFixedUpdate ();
			}
			Expla.color= new Color (Expla.color.r, Expla.color.g, Expla.color.b, Dest);
		} else if (D.Equals (-1)) {
			while (Expla.color.a > 0.0f) {
				Expla.color -= new Color (0.0f, 0.0f, 0.0f, 0.01f);
				yield return new WaitForFixedUpdate ();
			}
			Expla.color= new Color (Expla.color.r, Expla.color.g, Expla.color.b, 0.0f);
		}
	}

}
