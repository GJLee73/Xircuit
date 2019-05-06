using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject plus;
	public GameObject[] equals;

	public void Animate (GameObject circle_x, GameObject circle_y) {
		int slash = circle_x.GetComponent<Circle_Tutorial> ().GetTag () & circle_y.GetComponent<Circle_Tutorial> ().GetTag ();
		GameObject[] bars_x = circle_x.GetComponent<Circle_Tutorial> ().bars;
		GameObject[] bars_y = circle_y.GetComponent<Circle_Tutorial> ().bars;
		ArrayList bars = new ArrayList ();
		if (slash % 2 == 1) {
			for (int i = 0; i < bars_x.Length; i++) {
				if (int.Parse (bars_x [i].tag) == 1)
					bars.Add (bars_x [i]);
			}
			for (int i = 0; i < bars_y.Length; i++) {
				if (int.Parse (bars_y [i].tag) == 1)
					bars.Add (bars_y [i]);
			}
		}
		slash = slash / 2;
		if (slash % 2 == 1) {
			for (int i = 0; i < bars_x.Length; i++) {
				if (int.Parse (bars_x [i].tag) == 2)
					bars.Add (bars_x [i]);
			}
			for (int i = 0; i < bars_y.Length; i++) {
				if (int.Parse (bars_y [i].tag) == 2)
					bars.Add (bars_y [i]);
			}
		}
		slash = slash / 2;
		if (slash % 2 == 1) {
			for (int i = 0; i < bars_x.Length; i++) {
				if (int.Parse (bars_x [i].tag) == 4)
					bars.Add (bars_x [i]);
			}
			for (int i = 0; i < bars_y.Length; i++) {
				if (int.Parse (bars_y [i].tag) == 4)
					bars.Add (bars_y [i]);
			}
		}

		StartCoroutine (Tuto (bars));
	}

	IEnumerator Tuto (ArrayList bars) {
		for (int i = 0; i < 20; i++) {
			plus.GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			yield return new WaitForSeconds (0.025f);
		}

		for (int i = 0; i < 20; i++) {
			foreach (GameObject g in bars) {
				g.GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
				yield return new WaitForSeconds (0.005f);
			}
		}

		// Equals Timing
		yield return new WaitForSeconds (0.05f);

		for (int i = 0; i < 20; i++) {
			equals [0].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			equals [1].GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			yield return new WaitForSeconds (0.025f);
		}
	}
}
