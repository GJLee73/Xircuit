using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject plus;
	public GameObject[] equals;

	public GameObject[] circles;

	GameObject circle_x;
	GameObject circle_y;
	GameObject circle_z;

	bool is_done = false;

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	void Update () {
		if (is_done && Input.GetMouseButtonDown (0)) {
			Initialize ();
		}
	}

	public void Animate (GameObject circle_x, GameObject circle_y, GameObject circle_z) {
		this.circle_x = circle_x;
		this.circle_y = circle_y;
		this.circle_z = circle_z;

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

		is_done = true;
	}

	void Initialize () {
		is_done = false;

		plus.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		equals [0].GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		equals [1].GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		Destroy (circle_x);
		Destroy (circle_y);
		Destroy (circle_z);

		for (int i = 0; i < this.circles.Length; i++) {
			circles[i].GetComponent<Circle_Tutorial>().Initialize();
		}
	}
}
