using UnityEngine;
using System.Collections;

public class MousePointer : MonoBehaviour {

	Vector3 pos_init;

	public GameObject button_X;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		pos_init = transform.position;
		gameObject.SetActive (false);
	}

	public void Move () {
		StartCoroutine (Slide ());
	}

	IEnumerator Slide () {
		float t = 0.0f;
		while (true) {
			if (t >= 1.0f) {
				yield return new WaitForSeconds (1.0f);
				transform.position = pos_init;
				t = 0.0f;
				continue;
			}

			t += 0.0167f;
			transform.position = Vector3.Lerp (pos_init, new Vector3 (-104.5f, -1.4f, 0.0f), t);
			yield return new WaitForSeconds (0.02f);
		}
	}

	public void Destroy () {
		button_X.SetActive (true);
		gameObject.SetActive (false);
	}
}
