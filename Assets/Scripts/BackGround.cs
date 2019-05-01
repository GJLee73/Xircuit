using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {
	private SpriteRenderer S;
	public float Starts;
	public float End;
	public float Speed;
	public GameObject OS;
	private SpriteRenderer OSS;
	public int Changeable = 0;
	// Use this for initialization
	void Awake () {
		if (Changeable>0) {
			OSS = OS.GetComponent<SpriteRenderer> ();
		}
		S = GetComponent<SpriteRenderer> ();
		S.color = new Color (1.0f, 1.0f, 1.0f, Starts);
	}

	void Start(){
		if (Changeable.Equals (0)||Changeable.Equals(1)) {
			StartCoroutine ("ChangeAlpha");
		}
		     
	}

	IEnumerator ChangeAlpha(){
		if (Speed > 0) {
			while (S.color.a<End) {
				//Debug.Log ("ZAZ");
				S.color += new Color (1.0f, 1.0f, 1.0f, Speed);
				yield return new WaitForSeconds (0.1f);
			}
			Speed = -Speed;
			float Tem = End;
			End = Starts;
			Starts = Tem;
			StartCoroutine("ChangeAlpha");
		} else if (Speed < 0) {
			while (S.color.a>End) {
				S.color += new Color (1.0f, 1.0f, 1.0f, Speed);
				yield return new WaitForSeconds (0.1f);
			}
			Speed = -Speed;
			float Tem = End;
			End = Starts;
			Starts = Tem;

			StartCoroutine("ChangeAlpha");
		}
	}

	IEnumerator Change(int A){
		if (A.Equals (1)) {
			while (S.color.a>0) {
				S.color -= new Color (0.0f, 0.0f, 0.0f, 0.1f);
				yield return new WaitForSeconds (0.05f);
			}
		} else if (A.Equals (2)) {
			while(OSS.color.a<1.0f){
				OSS.color += new Color(0.0f, 0.0f, 0.0f, 0.1f);
				yield return new WaitForSeconds(0.05f);
			}
		}
	}

	// Update is called once per frame
	IEnumerator Reset(){
		if (Changeable.Equals(2)) {
			//Debug.Log("AQ");
			OS.SendMessage("StopPlaying");
			StopCoroutine ("ChangeAlpha");
			while (S.color.a>0||OSS.color.a<1.0f) {
				OSS.color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
				S.color -= new Color (0.0f, 0.0f, 0.0f, 0.05f);
				yield return new WaitForSeconds(0.25f);
			}
			S.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			OSS.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); 
			OS.SendMessage ("ChangeAlpha");
		}
	}

	IEnumerator Playing(){
		if (Changeable.Equals (1)) {
			OS.SendMessage("StopReset");
			StopCoroutine("ChangeAlpha");
			while(S.color.a>0||OSS.color.a<1.0f){
				OSS.color += new Color(0.0f, 0.0f, 0.0f, 0.05f);
				S.color -= new Color(0.0f, 0.0f, 0.0f, 0.05f);
				yield return new WaitForSeconds(0.25f);
			}
			S.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			OSS.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); 
			OS.SendMessage("ChangeAlpha");
		}
	}

	void StopPlaying(){
		StopCoroutine ("Playing");
	}

	void StopReset(){
		StopCoroutine ("Reset");
	}
}
