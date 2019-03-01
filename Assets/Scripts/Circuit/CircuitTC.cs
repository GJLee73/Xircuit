using UnityEngine;
using System.Collections;

public class CircuitTC : MonoBehaviour {
	public int Order = 1;
	public int T1;
	public int T2;
	public int Tag;
	public bool K = true;
	private Transform Btr;
	private Vector3 Pos;
	private TrailRenderer Tra;
	private SpriteRenderer S;
	public GameObject Out;
	public int OutDirection;
	int a;

	public GameObject Ba;
	private Rigidbody2D Rb;
	private Ball BaSc;
	
	// Use this for initialization
	void Awake () {
		Order = 1;
		K = true;
		Rb = Ba.GetComponent<Rigidbody2D> ();
		Pos = Out.transform.position;
		Btr = Ba.transform;
		Tra = Ba.GetComponent<TrailRenderer> ();
		//StartCoroutine ("Updat");
		BaSc = Ba.GetComponent<Ball> ();
		S = GetComponent<SpriteRenderer> ();
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Ball")&&!other.Equals(Ba)) {
			if (Order.Equals(1)) {
				other.GetComponent<SpriteRenderer>().enabled = false;
				other.GetComponent<Rigidbody2D> ().Sleep ();
				ChangeColor(other.gameObject.layer - 8);
				StartCoroutine (Fir (other));
			}
			if (Order.Equals(2)) {
				//other.GetComponent<SpriteRenderer>().enabled = false;
				other.GetComponent<Rigidbody2D> ().Sleep ();
				if(K){
					K = false;
					StartCoroutine (Sec (other));
				}
			}
		}
		
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
	
	IEnumerator Fir(Collider2D other){
		if (true){
			T1 = other.gameObject.layer - 8;
			yield return new WaitForFixedUpdate();
			//Debug.Log ("FFFFF");
		}
		Order = 2;
	}
	
	IEnumerator Sec(Collider2D other){
		if (true) {
			T2 = other.gameObject.layer - 8;
			ChangeColor(T1^T2);
			BaSc.Direction = OutDirection;
			yield return new WaitForFixedUpdate();

			Btr.position = Pos;
			Ba.layer = T1^T2 + 8;
			//Debug.Log (T1^T2 );
			Ba.SetActive(true);
			yield return new WaitForSeconds (0.1f);
			Direction();
			
			yield return new WaitForSeconds(0.1f);
			//Debug.Log ("SSSS");
		}
		Order++;
	}
	
	void Playing(){

	}

	void Reset(){
		StopAllCoroutines ();
		Order = 1;
		K = true;
		Ba.SetActive(false);
		Tra.time = 0.1f;
		ChangeColor (0);
	}

	void Direction(){
		Tra.time = Mathf.Infinity;
		Rb.Sleep();
		Btr.position = Pos;
		if(OutDirection.Equals(1)){
			Rb.AddForce(new Vector2(200.0f, 0.0f));
			Btr.position = Pos;
		}
		else if(OutDirection.Equals(2)){
			Rb.AddForce(new Vector2(0.0f, 200.0f));
			Btr.position = Pos;
		}
		else if(OutDirection.Equals(3)){
			Rb.AddForce(new Vector2(-200.0f, 0.0f));
			Btr.position = Pos;
		}
		else if(OutDirection.Equals(4)){
			Rb.AddForce(new Vector2(0.0f, -200.0f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals (8)) {
			Rb.AddForce(new Vector2(141.42f, -141.42f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals (7)) {
			Rb.AddForce(new Vector2(-141.42f, -141.42f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals (6)) {
			Rb.AddForce(new Vector2(-141.42f, 141.42f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals (5)) {
			Rb.AddForce(new Vector2(141.42f, 141.42f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals (9)) {
			Rb.AddForce(new Vector2(178.9869f, 89.24f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals (10)) {
			Rb.AddForce(new Vector2(-178.9869f, 89.24f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals (11)) {
			Rb.AddForce(new Vector2(-178.9869f, -89.24f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals (12)) {
			Rb.AddForce(new Vector2(178.9869f, -89.24f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals(13)){
			Rb.AddForce(new Vector2(89.24f, 178.9869f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals(14)){
			Rb.AddForce(new Vector2(-89.24f, 178.9869f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals(15)){
			Rb.AddForce(new Vector2(-89.24f, -178.9869f));
			Btr.position = Pos;
		}
		else if (OutDirection.Equals(16)){
			Rb.AddForce(new Vector2(89.24f, -178.9869f));
			Btr.position = Pos;
		}
	}
	/*IEnumerator Updat(){
		while (true) {
			if (Starter.tag.Equals("Playing")) {
				if(B){
					A = true;
					Ba.GetComponent<Ball>().isPlaying = true;
					B = false;
					
				}
			}
			if (Starter.tag.Equals("Reset")) {
				if(A){
					Order = 1;
					K = true;
					A = false;
					B = true;
					Ba.SetActive(false);
					Ba.GetComponent<TrailRenderer>().time = 0.1f;
				}
			}
			
			yield return new WaitForEndOfFrame();
		}
	}*/
	

	
}
