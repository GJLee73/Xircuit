using UnityEngine;
using System.Collections;

public class CircuitED : MonoBehaviour {
	public bool isPlaying =false;
	public GameObject B1,B2,B3;
	public int Direction1 = 1;
	public int Direction2 = 2;
	public int Direction3 = 4;
	private Rigidbody2D Rb1, Rb2, Rb3;
	public bool isCopied = false;
	private int a;
	public GameObject Out1, Out2, Out3;
	private Vector3 Pos1, Pos2, Pos3;
	private Transform Tr1, Tr2, Tr3;
	private Ball BaSc1, BaSc2, BaSc3;
	private TrailRenderer Tra1, Tra2, Tra3;
	private SpriteRenderer S;
	public float V = 10.0f;

	public SpriteRenderer[] Change;

	public bool isChange = false;

	// Use this for initialization
	void Awake () {
		//GameObject[] Balls = new GameObject[3]; 
		isPlaying = false;
		isCopied = false;
		//StartCoroutine ("Updat");
		Rb1 = B1.GetComponent<Rigidbody2D> ();
		Rb2 = B2.GetComponent<Rigidbody2D> ();
		Rb3 = B3.GetComponent<Rigidbody2D> ();
		Pos1 =Out1.transform.position;
		Pos2 = Out2.transform.position;
		Pos3 = Out3.transform.position;
		Tr1 = B1.transform;
		Tr2 = B2.transform;
		Tr3 = B3.transform;
		BaSc1 = B1.GetComponent<Ball> ();
		BaSc2 = B2.GetComponent<Ball> ();
		BaSc3 = B3.GetComponent<Ball> ();
		Tra1 = B1.GetComponent<TrailRenderer> ();
		Tra2 = B2.GetComponent<TrailRenderer> ();
		Tra3 = B3.GetComponent<TrailRenderer> ();
		S = GetComponent<SpriteRenderer> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Ball")&&!other.Equals(B1)&&!other.Equals(B2)&&!other.Equals(B3)) {
			other.GetComponent<Rigidbody2D>().Sleep();
			//other.GetComponent<SpriteRenderer>().enabled = false;
			if(!isCopied){
				//Debug.Log (other.name);
				ChangeColor(other.gameObject.layer - 8);
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
		B1.transform.position = Pos1;
		B1.layer = Layer;
		B1.GetComponent<Ball> ().Direction = Direction1;
		
		B2.SetActive (true);
		B2.transform.position =	Pos2;
		B2.layer = Layer;
		B2.GetComponent<Ball> ().Direction = Direction2;

		B3.SetActive (true);
		B3.transform.position = Pos3;
		B3.layer = Layer;
		B3.GetComponent<Ball> ().Direction = Direction2;
		//Rb2 = other.GetComponent<Rigidbody2D> ();
		
		yield return new WaitForSeconds (0.1f);

		if (isChange) {
			if (Layer.Equals (8)) {
				//Debug.Log ("AAA");
				for (int i = 0; i < 3; i++) {
					Change [i].color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
				}
			} else if (Layer.Equals (9)) {
				for (int i = 0; i < 3; i++) {
					Change [i].color = new Color (230 / 255f, 0.0f, 18 / 255f, 1.0f);
				}
			} else if (Layer.Equals (10)) {
				for (int i = 0; i < 3; i++) {
					Change [i].color = new Color (0.0f, 153 / 255f, 68 / 255f, 1.0f);
				}
			} else if (Layer.Equals (11)) {
				for (int i = 0; i < 3; i++) {
					Change [i].color = new Color (249 / 255f, 230 / 255f, 47 / 255f, 1.0f);
				}
			} else if (Layer.Equals (12)) {
				for (int i = 0; i < 3; i++) {
					Change [i].color = new Color (0.0f, 71 / 255f, 157 / 255f, 1.0f);
				}
			} else if (Layer.Equals (13)) {
				for (int i = 0; i < 3; i++) {
					Change [i].color = new Color (228 / 255f, 0.0f, 180 / 255f, 1.0f);
				}
			} else if (Layer.Equals (14)) {
				for (int i = 0; i < 3; i++) {
					Change [i].color = new Color (0.0f, 160 / 255f, 233 / 255f, 1.0f);
				}
			} else if (Layer.Equals (15)) {
				for (int i = 0; i < 3; i++) {
					Change [i].color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
				}
			}
		}

		Direction ();
		other.GetComponent<Rigidbody2D>().Sleep();
	}

	void Direction(){
		Rb1.Sleep ();
		Tra1.time = Mathf.Infinity;
		Rb2.Sleep ();
		Tra2.time = Mathf.Infinity;
		Rb3.Sleep ();
		Tra3.time = Mathf.Infinity;
		if (Direction1.Equals (1)) {
			Tr1.position = Pos1;
			Rb1.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction1.Equals (2)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction1.Equals (3)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction1.Equals (4)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction1.Equals (8)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction1.Equals (7)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction1.Equals (6)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction1.Equals (5)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction1.Equals (9)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction1.Equals (10)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction1.Equals (11)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction1.Equals (12)) {
			Tr1.position = Pos1;
			Rb1.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		
		
		
		if (Direction2.Equals (1)) {
			Tr2.position = Pos2;
			Rb2.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction2.Equals (2)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction2.Equals (3)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction2.Equals (4)) {
			Tr2.position =Pos2;
			Rb2.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction2.Equals (6)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction2.Equals (7)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction2.Equals (8)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction2.Equals (5)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction2.Equals (9)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction2.Equals (10)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction2.Equals (11)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction2.Equals (12)) {
			Tr2.position = Pos2;
			Rb2.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		
		
		if (Direction3.Equals (1)) {
			Tr3.position =Pos3;
			Rb3.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction3.Equals (2)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction3.Equals (3)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction3.Equals (4)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction3.Equals (6)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction3.Equals (7)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction3.Equals (8)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction3.Equals (5)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction3.Equals (9)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction3.Equals (10)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction3.Equals (11)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction3.Equals (12)) {
			Tr3.position = Pos3;
			Rb3.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		
		BaSc1.Direction = Direction1;
		BaSc2.Direction = Direction2;
		BaSc3.Direction = Direction3;
	}

	void Playing(){
		isPlaying = true;

		if (isChange) {
			for (int i = 0; i < 3; i++) {
				Change [i].color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
			}
		}
	}

	void Reset(){

		if (isChange) {
			for (int i = 0; i < 3; i++) {
				Change [i].color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
			}
		}

		StopCoroutine ("Rexar");
		isPlaying = false;
		isCopied = false;
		B1.GetComponent<TrailRenderer>().time = 0.0f;
		B1.SetActive(false);
		BaSc1.Dead = false;
		B2.GetComponent<TrailRenderer>().time = 0.0f;
		B2.SetActive(false);
		BaSc2.Dead = false;
		B3.GetComponent<TrailRenderer>().time = 0.0f;
		B3.SetActive(false);
		BaSc3.Dead = false;
		ChangeColor (0);
	}

}
