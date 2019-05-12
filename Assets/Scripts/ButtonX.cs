using UnityEngine;
using System.Collections;

public class ButtonX : MonoBehaviour {

	public SpriteRenderer blind;

	Vector3 scale_init;

	void Awake () {
		DontDestroyOnLoad (gameObject);

		scale_init = transform.localScale;
	}

	void OnMouseDown () {
		transform.localScale = new Vector3 (scale_init.x*1.2f, scale_init.y*1.2f, scale_init.z);
	}

	void OnMouseUp () {
		transform.localScale = scale_init;

		StartCoroutine (Fade ());
	}

	IEnumerator Fade () {
		blind.transform.position = new Vector3 (-101.0f, 0.1f, 0.0f);
		for (int i = 0; i < 20; i++) {
			blind.GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			yield return new WaitForSeconds (0.075f);
		}

		blind.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		GameObject.FindWithTag ("MainCamera").transform.position = new Vector3 (0.0f, 0.0f, -10.0f);
		for (int i = 0; i < 20; i++) {
			blind.GetComponent<SpriteRenderer> ().color -= new Color (0.0f, 0.0f, 0.0f, 0.05f);
			yield return new WaitForSeconds (0.075f);
		}
	}
}
