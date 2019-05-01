using UnityEngine;
using System.Collections;

public class NeoFuse : MonoBehaviour {
	private SpriteRenderer S;
	public int FuseColor;
	public GameObject Starter;
	public GameObject FC1, FC2;
	public GameObject Clone;
	private Transform CT;
	private SpriteRenderer CS;
	private float Scale;
	private float q,w,e;
	public int MAX = 10;
	public float WaveScaleV = 0.02f;
	public float WaveAlphaV = 0.1f;
	private bool E;
	public AudioClip Success, Fail;
	private AudioSource Au;
	public float AlphaStart = 80/255f;
	public float AlphaV = 15 / 255f;
	public float ResetInterval = 1.0f;

	public bool isPlay = true;
	//public float 
	// Use this for initialization

	void Awake(){
		Au = GetComponent<AudioSource> ();
		E = true;
		if (FuseColor.Equals (0)) {
			q = 0;
			w = 0;
			e = 0;
		}

		if (FuseColor.Equals (1)) {
			q = 230/255f;
			w = 0;
			e = 18/255f;	
		}
		if (FuseColor.Equals (2)) {
			q = 0;
			w = 153/255f;
			e = 68/255f;
		}
		if (FuseColor.Equals (3)) {
			q = 249/255f;
			w = 230/255f;
			e = 47/255f;
		}

		if (FuseColor.Equals (4)) {
			q = 0;
			w = 71/255f;
			e = 157/255f;
		}

		if (FuseColor.Equals (5)) {
			q = 228/255f;
			w = 0;
			e = 180/255f;
		}
		if (FuseColor.Equals (6)) {
			q = 0;
			w =	160/255f;
			e = 233/255f;
		}
		if (FuseColor.Equals (7)) {
			q = 1;
			w = 1;
			e = 1;
		}
		Scale = transform.localScale.x;
		S = GetComponent<SpriteRenderer> ();
		ChangeColor (FuseColor);
		CT = Clone.transform;
		CS = Clone.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ball")) {
			if (isPlay) {
				//other.GetComponent<Rigidbody2D>().Sleep();
				if (other.gameObject.layer.Equals (FuseColor + 8)) {
					//if(E){
					//E = false;\
					Au.clip = Fail;
					Au.Play ();
					StartCoroutine ("ChangeCoreColor", -1);
					//}
				} else if (!other.gameObject.layer.Equals (FuseColor + 8)) {
					if (E) {
						E = false;
						Au.clip = Success;
						Au.Play ();
						//StartCoroutine("Wave");
						StartCoroutine ("ChangeCoreColor", 1);
					}
				}
			}
		}
	}

	IEnumerator Wave(){

		CT.rotation = transform.rotation;
		CT.position = transform.position + new Vector3 (0.0f, 0.0f, 0.0f);
		//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		CT.gameObject.SetActive (true);
		CS.color = new Color (q, w, e, 1.0f);
		for (float i=0; i<MAX; i++) {
			CT.localScale = Scale*new Vector3(1.0f+WaveScaleV*i,1.0f+WaveScaleV*i, 0.0f); 
			CS.color -= new Color(0.0f, 0.0f, 0.0f, WaveAlphaV); 
			yield return new WaitForSeconds(0.06f);
		}
		CT.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		CT.gameObject.SetActive (false);
		CS.color += new Color(0.0f, 0.0f, 0.0f, 1.0f);
		E = true;
	}

	void ChangeColor(int C){
		if (C.Equals (0)) {
			S.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
		}
		if (C.Equals (1)) {
			S.color = new Color(230/255f, 0.0f, 18/255f, 1.0f);
		}
		if (C.Equals (2)) {
			S.color = new Color(0.0f, 153/255f, 68/255f, 1.0f);
		}
		if (C.Equals (3)) {
			S.color = new Color(249/255f, 230/255f, 47/255f, 1.0f);
		}
		if (C.Equals (4)) {
			S.color = new Color(0.0f, 71/255f, 157/255f, 1.0f);
		}
		if (C.Equals (5)) {
			S.color = new Color(228/255f, 0.0f, 180/255f, 1.0f);
		}
		if (C.Equals (6)) {
			S.color = new Color(0.0f, 160/255f, 233/255f, 1.0f);
		}
		if (C.Equals (7)) {
			S.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
		S.color -= new Color (0.0f, 0.0f, 0.0f, AlphaStart);
	}

	IEnumerator ChangeCoreColor(int i){
		if (i.Equals(1)) {

			while (S.color.a<1.0f) {
				S.color += new Color (0.0f, 0.0f, 0.0f, AlphaV); 
				yield return new WaitForSeconds (0.1f);
			}
		} else if (i.Equals(-1)) {
			while(S.color.a>0.0f){
				S.color -= new Color (0.0f, 0.0f, 0.0f, AlphaV);
				yield return new WaitForSeconds(0.1f);
			}
		}
	}

	void Reset(){
		isPlay = false;

		E = true;
		StopCoroutine ("ChangeCoreColor");
		S.enabled = true;
		ChangeColor (FuseColor);
		FC1.SendMessage ("Reset");
		FC2.SendMessage ("Reset");
	}

	void Playing(){
		isPlay = true;

		FC1.SendMessage ("Playing");
		FC2.SendMessage ("Playing");
	}

	IEnumerator Broke(){
		yield return new WaitForSeconds(ResetInterval);
		Starter.SendMessage ("Reset");
	}

}
