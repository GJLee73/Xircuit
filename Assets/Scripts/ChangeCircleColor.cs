using UnityEngine;
using System.Collections;

public class ChangeCircleColor : MonoBehaviour {
	private SpriteRenderer S;
	private int Count;
	private float q,w,e, Scale;
	private bool R, K, B;
	public Transform Clone;
	private SpriteRenderer SClone;
	private Vector3 Pos;
	private Transform T;
	public bool isWaving = false;
	// Use this for initialization
	void Awake () {
		T = transform;
		Scale = T.localScale.x;
		Pos = T.position;
		if (isWaving) {
			SClone = Clone.GetComponent<SpriteRenderer> ();
		}
		S = GetComponent<SpriteRenderer> ();
		Count = 0;
		
	}

	void Start(){
		GetComponent<SpriteRenderer> ().sortingLayerName = "Ball";
		GetComponent<SpriteRenderer> ().sortingOrder = 1;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ball")) {
			//Debug.Log ("QQ");
			StartCoroutine(ColorChange(other.gameObject.layer-8));
			if(K&&isWaving){
				K = false;
				StartCoroutine("WaveRepeat");
			}
		}
	}
	
	
	void StopWave(){
		//Debug.Log ("AS");
		StopCoroutine ("WaveRepeat");
		B = false;
	}
	
	IEnumerator WaveRepeat(){
		while (B) {
			StartCoroutine(Wave (SClone, Clone, Pos, Scale,10.0f*new Color(q,w,e,1.0f)));
			yield return new WaitForSeconds(1.8f);
		}
	}
	
	IEnumerator ColorChange(int C){
		if (C.Equals (0)) {
			q = 0.0f; 
			w = 0.0f; 
			e = 0.0f;
		}
		if (C.Equals (1)) {
			q = 230/2550f;
			w = 0.0f;
			e = 18/2550f;
		}
		if (C.Equals (2)) {
			q = 0.0f; 
			w = 153/2550f;
			e = 68/2550f;
		}
		if (C.Equals (3)) {
			q = 249/2550f;
			w = 230/2550f;
			e = 47/2550f;
		}
		if (C.Equals (4)) {
			q = 0.0f;
			w = 71/2550f;
			e = 157/2550f;
		}
		if (C.Equals (5)) {
			q = 228/2550f;
			w = 0.0f;
			e = 180/2550f;
		}
		if (C.Equals (6)) {
			q = 0.0f;
			w = 160/2550f;
			e = 233/2550f; 
		}
		if (C.Equals (7)) {
			q = 0.1f;
			w = 0.1f;
			e =0.1f;
		}
		
		while (!Count.Equals(5)&&R) {
			
			Count++;
			S.color += 2.0f*new Color(q, w, e);
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	IEnumerator Wave(SpriteRenderer SSS, Transform T, Vector3 Po, float SC, Color Co){
		//Debug.Log ("AAA");
		T.position = Po + new Vector3 (0.0f, 0.0f, 0.0f);
		//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		T.gameObject.SetActive (true);
		SSS.color = new Color (Co.r, Co.g, Co.b, 1.0f);
		for (float i=0; i<17; i++) {
			T.localScale = SC*new Vector3(1.0f+0.08f*i,1.0f+0.08f*i, 0.0f); 
			SSS.color -= new Color(0.0f, 0.0f, 0.0f, 0.07f); 
			yield return new WaitForSeconds(0.06f);
		}
		T.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		T.gameObject.SetActive (false);
		SSS.color += new Color(0.0f, 0.0f, 0.0f, 1.0f);
	}
	
	void Reset(){
		StopCoroutine ("WaveRepeat");
		B = false;
		K = true;
		R = false;
		StopCoroutine ("ColorChange");
		Count = 0;
		S.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
	}
	
	void Playing(){
		R = true;
		B = true;
	}
	
}