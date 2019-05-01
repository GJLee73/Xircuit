using UnityEngine;
using System.Collections;

public class Focus : MonoBehaviour {
	private Transform Tr;
	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad (this.gameObject);
		Tr = transform;
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
			Tr.position = new Vector3(-33.0f, 19.0f, -2.0f);
		} else if ((((float)Screen.width / Screen.height)>1.3f)&&(((float)Screen.width/Screen.height)<1.35f)) { //4/3
			Tr.position = new Vector3(-33f, 24.0f, -2.0f);
			Tr.localScale = new Vector3 (9.8f, 9.8f, 1.0f);
		} else if ((((float)Screen.width / Screen.height)>1.65f)&&(((float)Screen.width/Screen.height)<1.7f)) { //5/3
			Tr.position = new Vector3(-34.0f, 19.0f,-2.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			Tr.position = new Vector3 (-30.5f, 19.0f, -2.0f);
		}
	}
}
