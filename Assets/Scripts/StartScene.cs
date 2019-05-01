using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

	public SpriteRenderer[] objects;

	// Use this for initialization
	void Start () {
		StartCoroutine("FadeOutFamily");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeOut (SpriteRenderer spr) {
		for (int i = 0; i < 50; i++) {
			spr.color -= new Color (0.0f,0.0f,0.0f,0.02f);
			yield return new WaitForSeconds (0.05f);
		}
	}

 	void FadeOutFamily () {
		int length = objects.Length;
		for (int i = 0; i < length; i++) {
			StartCoroutine("FadeOut",objects[i]);
		}
	}
}
