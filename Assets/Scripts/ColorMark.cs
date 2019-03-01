using UnityEngine;
using System.Collections;

public class ColorMark : MonoBehaviour {
	private Transform T;
	// Use this for initialization
	void Awake () {
		T = transform;
		if (Screen.width.Equals (1280) && Screen.height.Equals (720)) {
			T.position = new Vector3 (-33.0f, 17.0f, 0.0f);
		} else if (Screen.width.Equals (800) && Screen.height.Equals (480)) {
			T.position = new Vector3 (-33.0f, 19.0f, 0.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
