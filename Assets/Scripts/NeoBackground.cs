using UnityEngine;
using System.Collections;

public class NeoBackground : MonoBehaviour {
	private SpriteRenderer S;
	public float K;
	public Transform Circuit7;
	private Transform Tr;
	// Use this for initialization
	void Awake(){
		Tr = transform;
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {
			Tr.localScale = new Vector3 (6.0f, 6.75f, 1.0f);
			Circuit7.localScale = new Vector3 (7 / 6f, 7 / 6.75f, 1.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.3f) && (((float)Screen.width / Screen.height) < 1.35f)) {
			Tr.localScale = new Vector3 (6.0f, 8.25f, 1.0f);
			Circuit7.localScale = new Vector3(7.0f/6.0f, 7.0f/8.25f, 1.0f);
			Circuit7.position = new Vector3 (0.0f, -2.0f, 0.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.65f) && (((float)Screen.width / Screen.height) < 1.7f)) {
			Tr.localScale = new Vector3 (6.0f, 6.75f, 1.0f);
			Circuit7.localScale = new Vector3 (7 / 6f, 7 / 6.75f, 1.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.7f) && (((float)Screen.width / Screen.height) < 1.8f)) {
			Tr.localScale = new Vector3 (6.0f, 6.0f, 1.0f);
			Circuit7.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		}else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			Tr.localScale = new Vector3(6.5f, 7.0f, 1.0f);
			Circuit7.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		}
		S = GetComponent<SpriteRenderer> ();
		S.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	}

	IEnumerator Fade(){
		while(S.color.a>0){
			//Debug.Log("Fade");
			S.color -= new Color(0.0f, 0.0f, 0.0f, K);
			yield return new WaitForSeconds(0.1f);
		}
	}

	IEnumerator In(){

		while(S.color.a<75/255f){
			//Debug.Log ("In");
			S.color += new Color(0.0f, 0.0f, 0.0f, K);
			yield return new WaitForSeconds(0.1f);
		}
	}

	void Playing(){
		//Debug.Log ("Playing");
		StopCoroutine ("Fade");
		StartCoroutine ("In");
	}

	void Reset(){
		StopCoroutine ("In");
		StartCoroutine ("Fade");
	}
	          
}
