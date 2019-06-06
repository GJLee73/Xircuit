using UnityEngine;
using System.Collections;

public class ButtonX : MonoBehaviour {

	public SpriteRenderer blind;

	Vector3 scale_init;

	private Transform Tr;

	void Awake () {
		DontDestroyOnLoad (gameObject);

		scale_init = transform.localScale;

		Tr = transform;
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
			Tr.position = new Vector3(-33.0f, 19.0f, -3.0f) + new Vector3 (-101.0f, 0.1f, 0.0f);
		} else if ((((float)Screen.width / Screen.height)>1.3f)&&(((float)Screen.width/Screen.height)<1.35f)) { //4/3
			Tr.position = new Vector3(-33f, 24.0f, -3.0f) + new Vector3 (-101.0f, 0.1f, 0.0f);
		} else if ((((float)Screen.width / Screen.height)>1.65f)&&(((float)Screen.width/Screen.height)<1.7f)) { //5/3
			Tr.position = new Vector3(-34.0f, 19.0f,-3.0f) + new Vector3 (-101.0f, 0.1f, 0.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			Tr.position = new Vector3 (-30.5f, 19.0f, -3.0f) + new Vector3 (-101.0f, 0.1f, 0.0f);
		}
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
