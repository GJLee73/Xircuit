using UnityEngine;
using System.Collections;

public class Instruction : MonoBehaviour {

	public GameObject[] RGB = new GameObject[3];
	public GameObject[] SLASH = new GameObject[3];
	public GameObject PLUS;
	public GameObject[] RGB2 = new GameObject[3];
	public GameObject[] SLASH2 = new GameObject[3];
	public GameObject[] EQUAL = new GameObject[2];
	public GameObject[] RGB3 = new GameObject[3];
	public GameObject CIRCLE1;
	public GameObject CIRCLE2;
	public GameObject CIRCLE3;

	int color1;
	int color2;
	int color3;
	int slash;

	public void GetColor (int color1, int color2) {
		this.color1 = color1;
		this.color2 = color2;
		this.color3 = color1 ^ color2;

		this.slash = color1 & color2;

		for (int i = 0; i < 3; i++) {
			if (this.color1 % 2 == 1) {
				RGB [i].SetActive (true);
			}
			this.color1 = this.color1 / 2;
		}

		for (int i = 0; i < 3; i++) {
			if (this.color2 % 2 == 1) {
				RGB2 [i].SetActive (true);
			}
			this.color2 = this.color2 / 2;
		}

		for (int i = 0; i < 3; i++) {
			if (this.color3 % 2 == 1) {
				RGB3 [i].SetActive (true);
			}
			this.color3 = this.color3 / 2;
		}

		for (int i = 0; i < 3; i++) {
			if (this.slash % 2 == 1) {
				SLASH [i].SetActive (true);
				SLASH2 [i].SetActive (true);
			}
			this.slash = this.slash / 2;
		}

		this.color1 = color1;
		this.color2 = color2;
		this.color3 = color1 ^ color2;
			
		StartCoroutine (Show ());
	}

	IEnumerator Show () {
		Color color1 = GameObject.FindWithTag (this.color1.ToString ()).GetComponent<Circle_Tutorial> ().GetColor ();
		Color color2 = GameObject.FindWithTag (this.color2.ToString ()).GetComponent<Circle_Tutorial> ().GetColor ();
		Color color3 = GameObject.FindWithTag (this.color3.ToString ()).GetComponent<Circle_Tutorial> ().GetColor ();
		CIRCLE1.GetComponent<SpriteRenderer> ().color = new Color (color1.r, color1.g, color1.b, 0.0f);
		CIRCLE2.GetComponent<SpriteRenderer> ().color = new Color (color2.r, color2.g, color2.b, 0.0f);
		CIRCLE3.GetComponent<SpriteRenderer> ().color = new Color (color3.r, color3.g, color3.b, 0.0f);
		for (int i = 0; i < 20; i++) {
			if (RGB [0].activeSelf) {
				RGB [0].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (RGB [1].activeSelf) {
				RGB [1].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (RGB [2].activeSelf) {
				RGB [2].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (CIRCLE1.activeSelf) {
				CIRCLE1.GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (PLUS.activeSelf) {
				PLUS.GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (RGB2 [0].activeSelf) {
				RGB2 [0].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (RGB2 [1].activeSelf) {
				RGB2 [1].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (RGB2 [2].activeSelf) {
				RGB2 [2].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (CIRCLE2.activeSelf) {
				CIRCLE2.GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			yield return new WaitForSeconds (0.025f);
		}
		yield return new WaitForSeconds (0.025f);
		for (int i = 0; i < 20; i++) {
			if (SLASH [0].activeSelf) {
				SLASH [0].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (SLASH [1].activeSelf) {
				SLASH [1].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (SLASH [2].activeSelf) {
				SLASH [2].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (SLASH2 [0].activeSelf) {
				SLASH2 [0].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (SLASH2 [1].activeSelf) {
				SLASH2 [1].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (SLASH2 [2].activeSelf) {
				SLASH2 [2].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			yield return new WaitForSeconds (0.025f);
		}
		yield return new WaitForSeconds (0.025f);
		for (int i = 0; i < 20; i++) {
			if (EQUAL [0].activeSelf) {
				EQUAL [0].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (EQUAL [1].activeSelf) {
				EQUAL [1].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			yield return new WaitForSeconds (0.025f);
		}
		yield return new WaitForSeconds (0.025f);
		for (int i = 0; i < 20; i++) {
			if (RGB3 [0].activeSelf) {
				RGB3 [0].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (RGB3 [1].activeSelf) {
				RGB3 [1].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (RGB3 [2].activeSelf) {
				RGB3 [2].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			if (CIRCLE3.activeSelf) {
				CIRCLE3.GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			}
			yield return new WaitForSeconds (0.025f);
		}
	}
}
