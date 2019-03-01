using UnityEngine;
using System.Collections;

public class CircuitTD : MonoBehaviour {
	public bool isPlaying =false;
	public GameObject B1;
	public GameObject B2;
	public int Direction1;
	public int Direction2;
	public bool isCopied = false;
	private Rigidbody2D Rb1;
	private Rigidbody2D Rb2;
	private Transform Tr1;
	private Transform Tr2;
	private int a;
	private Vector3 Pos;
	private Ball BaSc1;
	private Ball BaSc2;
	private TrailRenderer Tra1;
	private TrailRenderer Tra2;
	private SpriteRenderer S;
	public GameObject Out1;
	public GameObject Out2;
	private Vector3 Pos1;
	private Vector3 Pos2;
	public float V = 10.0f;
	//public GameObject Starter;
	//bool A = true;
	//bool B = true;
	
	// Use this for initialization
	void Awake () {
		Pos1 = Out1.transform.position;
		Pos2 = Out2.transform.position;
		isPlaying = false;
		isCopied = false;
		//StartCoroutine ("Updat");
		Rb1 = B1.GetComponent<Rigidbody2D> ();
		Rb2 = B2.GetComponent<Rigidbody2D> ();
		Tr1 = B1.transform;
		Tr2 = B2.transform;
		Pos = transform.position;
		BaSc1 = B1.GetComponent<Ball> ();
		BaSc2 = B2.GetComponent<Ball> ();
		Tra1 = B1.GetComponent<TrailRenderer> ();
		Tra2 = B2.GetComponent<TrailRenderer> ();
		S = GetComponent<SpriteRenderer> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Ball")&&!other.gameObject.Equals(B1)&&!other.gameObject.Equals(B2)) {
			other.GetComponent<Rigidbody2D>().Sleep();
			other.GetComponent<SpriteRenderer>().enabled = false;
			if(!isCopied){
				//Debug.Log (other.name);
				ChangeColor(other.gameObject.layer -8);
				other.GetComponent<Ball>().Dead = true;
				other.GetComponent<Rigidbody2D>().Sleep();
				StartCoroutine(Rexar(other.gameObject.layer, other));
				isCopied = true;
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

	IEnumerator Rexar(int Layer, Collider2D other){
		B1.SetActive (true);		
		Tr1.position = Pos1;
		B1.layer = Layer;
		BaSc2.Direction = Direction1;
		
		B2.SetActive (true);
		Tr2.position = Pos2;
		B2.layer = Layer;
		BaSc1.Direction = Direction2;
		//Rb2 = other.GetComponent<Rigidbody2D> ();

		yield return new WaitForSeconds (0.1f);
		Direction ();
		other.GetComponent<Rigidbody2D>().Sleep();
	}

	void Playing(){
		isPlaying = true;
	}

	void Direction(){
		Rb1.Sleep ();
		Tra1.time = Mathf.Infinity;
		Rb2.Sleep ();
		Tra2.time = Mathf.Infinity;
		if (Direction1.Equals (1)) {
			Rb1.AddForce (V*new Vector2 (200.0f, 0.0f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (2)) {
			Rb1.AddForce(V*new Vector2(0.0f, 200.0f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (3)) {
			Rb1.AddForce(V*new Vector2(-200.0f, 0.0f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (4)) {
			Rb1.AddForce(V*new Vector2(0.0f, -200.0f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (8)) {
			Rb1.AddForce(V*new Vector2(141.42f, -141.42f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (7)) {
			Rb1.AddForce(V*new Vector2(-141.42f, -141.42f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (6)) {
			Rb1.AddForce(V*new Vector2(-141.42f, 141.42f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (5)) {
			Rb1.AddForce(V*new Vector2(141.42f, 141.42f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (9)) {
			Rb1.AddForce(V*new Vector2(178.9869f, 89.24f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (10)) {
			Rb1.AddForce(V*new Vector2(-178.9869f, 89.24f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (11)) {
			Rb1.AddForce(V*new Vector2(-178.9869f, -89.24f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (12)) {
			Rb1.AddForce(V*new Vector2(178.9869f, -89.24f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (13)) {
			Rb1.AddForce(V*new Vector2(89.24f, 178.9869f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (14)) {
			Rb1.AddForce(V*new Vector2(-89.24f, 178.9869f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (15)) {
			Rb1.AddForce(V*new Vector2(-89.24f, -178.9869f));
			Tr1.position = Pos1;
		}
		if (Direction1.Equals (16)) {
			Rb1.AddForce(V*new Vector2(89.24f, -178.9869f));
			Tr1.position = Pos1;
		}
		
		
		
		if (Direction2.Equals (1)) {
			Rb2.AddForce (V*new Vector2 (200.0f, 0.0f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (2)) {
			Rb2.AddForce(V*new Vector2(0.0f, 200.0f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (3)) {
			Rb2.AddForce(V*new Vector2(-200.0f, 0.0f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (4)) {
			Rb2.AddForce(V*new Vector2(0.0f, -200.0f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (6)) {
			Rb2.AddForce(V*new Vector2(-141.42f, 141.42f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (7)) {
			Rb2.AddForce(V*new Vector2(-141.42f, -141.42f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (8)) {
			Rb2.AddForce(V*new Vector2(141.42f, -141.42f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (5)) {
			Rb2.AddForce(V*new Vector2(141.42f, 141.42f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (9)) {
			Rb2.AddForce(V*new Vector2(178.9869f, 89.24f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (10)) {
			Rb2.AddForce(V*new Vector2(-178.9869f, 89.24f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (11)) {
			Rb2.AddForce(V*new Vector2(-178.9869f, -89.24f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (12)) {
			Rb2.AddForce(V*new Vector2(178.9869f, -89.24f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (13)) {
			Rb2.AddForce(V*new Vector2(89.24f, 178.9869f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (14)) {
			Rb2.AddForce(V*new Vector2(-89.24f, 178.9869f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (15)) {
			Rb2.AddForce(V*new Vector2(-89.24f, -178.9869f));
			Tr2.position = Pos2;
		}
		if (Direction2.Equals (16)) {
			Rb2.AddForce(V*new Vector2(89.24f, -178.9869f));
			Tr2.position = Pos2;
		}
		
		BaSc1.Direction = Direction1;
		BaSc2.Direction = Direction2;
	}

	void Reset(){
		StopCoroutine ("Rexar");
		isPlaying = false;
		isCopied = false;
		Tra1.time = 0.0f;
		B1.SetActive(false);
		BaSc1.Dead = false;
		Tra2.time = 0.0f;
		B2.SetActive(false);
		BaSc2.Dead = false;
		ChangeColor (0);
	}

	/*IEnumerator Updat(){
		while (true) {
			if (Starter.CompareTag("Playing")) {
				if(B){
					isPlaying = true;
					A = true;
					B = false;
				}
			}
			if (Starter.CompareTag("Reset")) {
				if(A){
					isPlaying = false;
					A = false;
					B = true;
					isCopied = false;
					B1.GetComponent<TrailRenderer>().time = 0.0f;
					B1.SetActive(false);
					B1.GetComponent<Ball>().Dead = false;
					B2.GetComponent<TrailRenderer>().time = 0.0f;
					B2.SetActive(false);
					B2.GetComponent<Ball>().Dead = false;
				}
			}
			

			yield return new WaitForEndOfFrame();
		}
	}*/

	//Input.GetKeyDown (KeyCode.Space)
}
