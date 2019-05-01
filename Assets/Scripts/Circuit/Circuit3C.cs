using UnityEngine;
using System.Collections;

public class Circuit3C : MonoBehaviour {
	public int Order = 1;
	public int T1;
	public int T2;
	public int T3;
	public int Tag = 0;
	public bool K = true;
	//public GameObject B;
	//public int Direction = 1;
	int a;
	//public GameObject Starter;

	public GameObject Ba;
	public int ConvergeNumber = 3;
	public int OutDirection = 1;
	private Rigidbody2D Rb;
	private TrailRenderer Tra;
	private Transform BTr;
	private Transform Tr;
	private Vector3 Pos;
	private SpriteRenderer S;
	private bool Sh;
	//private bool M = false;
	public GameObject[] In;
	public GameObject Out;
	public float V = 10.0f;
	
	// Use this for initialization
	void Awake () {
		//M = false;
		Order = 0;
		K = true;
		Rb = Ba.GetComponent<Rigidbody2D> ();
		Tra = Ba.GetComponent<TrailRenderer> ();
		Tr = transform;
		BTr = Ba.transform;
		Pos = Out.transform.position;
		S = GetComponent<SpriteRenderer> ();
		//StartCoroutine ("Updat");

	}
	
		
	void OnTriggerStay2D(Collider2D other){
		
		if (!Sh&&other.CompareTag ("Ball")&&!other.gameObject.Equals(Ba)) {
			other.GetComponent<Rigidbody2D> ().Sleep ();
			other.GetComponent<SpriteRenderer>().enabled = false;
			//other.GetComponent<SpriteRenderer>().enabled = false;
			if(!other.GetComponent<Ball>().Checked){
				Order++;
				other.GetComponent<Ball>().Checked = true;
				Tag = (other.gameObject.layer - 8) ^ Tag;
				ChangeColor(Tag);
				if(Order.Equals(ConvergeNumber)){
					for(int i =0; i<In.Length; i++){
						In[i].SendMessage("StopWave");
					}
					StartCoroutine("Shoot");
				}
			}
		}
	}

	IEnumerator Wave(SpriteRenderer SSS, Transform T, Vector3 Po, float SC, Color Co){
		//Debug.Log ("AAA");
		T.position = Po + new Vector3 (0.0f, 0.0f, 0.0f);
		//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		T.gameObject.SetActive (true);
		SSS.color = new Color (Co.r, Co.g, Co.b, 1.0f);
		for (float i=0; i<10; i++) {
			T.localScale = SC*new Vector3(1.0f+0.1f*i,1.0f+0.1f*i, 0.0f); 
			SSS.color -= new Color(0.0f, 0.0f, 0.0f, 0.1f); 
			yield return new WaitForSeconds(0.06f);
		}
		T.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		T.gameObject.SetActive (false);
		SSS.color += new Color(0.0f, 0.0f, 0.0f, 1.0f);
	}

	void ChangeColor(int C){
		if (C.Equals (0)) {
			S.color -= new Color(1.0f, 1.0f, 1.0f, 0.0f);
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
	}

	
	IEnumerator Shoot(){
		//Debug.Log ("Shoot");
		Sh = true;
		BTr.position = Tr.position;
		Ba.layer = Tag + 8;
		Ba.SetActive (true);
		yield return new WaitForSeconds(0.1f);
		Direc ();


	}

	void Playing(){
		
	}

	void Reset(){
		Sh = false;
		Order = 0;
		K = true;
		Ba.SetActive(false);
		Tra.time = 0.1f;
		Tag = 0;
		ChangeColor (0);

	}

	void Direc(){
		Tra.time = Mathf.Infinity;
		Rb.Sleep ();
		BTr.position = Pos;
		Ba.GetComponent<Ball> ().Direction = OutDirection;
		if (OutDirection.Equals (1)) {
			Rb.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		else if (OutDirection.Equals (2)) {
			Rb.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		else if (OutDirection.Equals (3)) {
			Rb.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		else if (OutDirection.Equals (4)) {
			Rb.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		else if (OutDirection.Equals (8)) {
			Rb.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		else if (OutDirection.Equals (7)) {
			Rb.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		else if (OutDirection.Equals (6)) {
			Rb.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		else if (OutDirection.Equals (5)) {
			Rb.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		else if (OutDirection.Equals (9)) {
			Rb.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		else if (OutDirection.Equals (10)) {
			Rb.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		else if (OutDirection.Equals (11)) {
			Rb.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		else if (OutDirection.Equals (12)) {
			Rb.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		else if (OutDirection.Equals(13)){
			Rb.AddForce(V*new Vector2(89.24f, 178.9869f));
		}
		else if (OutDirection.Equals(14)){
			Rb.AddForce(V*new Vector2(-89.24f, 178.9869f));
		}
		else if (OutDirection.Equals(15)){
			Rb.AddForce(V*new Vector2(-89.24f, -178.9869f));
		}
		else if (OutDirection.Equals(16)){
			Rb.AddForce(V*new Vector2(89.24f, -178.9869f));
		}
	}
}
