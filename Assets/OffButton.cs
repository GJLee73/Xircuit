using UnityEngine;
using System.Collections;

public class OffButton : MonoBehaviour {
	private int ClickCount;
	private SpriteRenderer S;
	private Transform Tr;
	// Use this for initialization
	void Awake(){
		Tr = transform;
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
			Tr.position = new Vector3(29.5f, 19.5f, 0.0f);
		} else if ((((float)Screen.width / Screen.height)>1.3f)&&(((float)Screen.width/Screen.height)<1.35f)) { //4/3
			Tr.position = new Vector3(29.5f, 24.5f, 0.0f);
		} else if ((((float)Screen.width / Screen.height)>1.65f)&&(((float)Screen.width/Screen.height)<1.7f)) { //5/3
			Tr.position = new Vector3(30.5f, 19.5f,0.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			Tr.position = new Vector3(27.0f, 19.5f, 0.0f);
		}
		DontDestroyOnLoad (this.gameObject);
		ClickCount = 0;
		S = GetComponent<SpriteRenderer> ();
	}

	void OnMouseDown(){
		ClickCount++;
		if (ClickCount.Equals (1)) {
			S.color = new Color (230/255f, 0.0f, 18/255f, 1.0f);
			StartCoroutine ("QuitCheck");
		} else if (ClickCount.Equals (2)) {
			Application.Quit ();
		}
	}

	IEnumerator QuitCheck(){
		yield return new WaitForSeconds (1.0f);
		ClickCount = 0;
		S.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
	}
}
