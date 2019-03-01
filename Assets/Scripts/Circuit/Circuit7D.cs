using UnityEngine;
using System.Collections;

public class Circuit7D : MonoBehaviour {
	public bool isPlaying =false;
	public GameObject B1, B2, B3, B4, B5, B6, B7;
	public int Direction1, Direction2, Direction3, Direction4, Direction5, Direction6, Direction7;
	public bool isCopied = false;
	private Rigidbody2D Rb1, Rb2, Rb3, Rb4, Rb5, Rb6, Rb7;
	private Transform Tr1, Tr2, Tr3, Tr4, Tr5, Tr6, Tr7;
	private Vector3 Pos1, Pos2, Pos3, Pos4, Pos5, Pos6, Pos7;
	public GameObject Out1, Out2, Out3, Out4, Out5, Out6, Out7;
	private int a;
	private SpriteRenderer S;
	public float V = 10.0f;
	//public GameObject Starter;
	//bool A = true;
	//bool B = true;
	
	// Use this for initialization
	void Awake () {
		isPlaying = false;
		isCopied = false;
		//StartCoroutine ("Updat");
		Rb1 = B1.GetComponent<Rigidbody2D> ();
		Rb2 = B2.GetComponent<Rigidbody2D> ();
		Rb3 = B3.GetComponent<Rigidbody2D> ();
		Rb4 = B4.GetComponent<Rigidbody2D> ();
		Rb5 = B5.GetComponent<Rigidbody2D> ();
		Rb6 = B6.GetComponent<Rigidbody2D> ();
		Rb7 = B7.GetComponent<Rigidbody2D> ();
		Tr1 = B1.transform;
		Tr2 = B2.transform;
		Tr3 = B3.transform;
		Tr4 = B4.transform;
		Tr5 = B5.transform;
		Tr6 = B6.transform;
		Tr7 = B7.transform;
		Pos1 =Out1.transform.position;
		Pos2 = Out2.transform.position;
		Pos3 = Out3.transform.position;
		Pos4 = Out4.transform.position;
		Pos5 = Out5.transform.position;
		Pos6 = Out6.transform.position;
		Pos7 = Out7.transform.position;
		S = GetComponent<SpriteRenderer> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Ball")&&!other.Equals(B1)&&!other.Equals(B2)) {
			//other.GetComponent<SpriteRenderer>().enabled = false;
			other.GetComponent<Rigidbody2D>().Sleep();
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
		Tr1.position = Pos1;
		B1.layer = Layer;
		B1.GetComponent<Ball> ().Direction = Direction1;
		
		B2.SetActive (true);
		Tr2.position = Pos2;
		B2.layer = Layer;
		B2.GetComponent<Ball> ().Direction = Direction2;
		//Rb2 = other.GetComponent<Rigidbody2D> ();
		B3.SetActive (true);
		Tr3.position = Pos3;
		B3.layer = Layer;
		B3.GetComponent<Ball> ().Direction = Direction2;
		
		B4.SetActive (true);
		Tr4.position = Pos4;
		B4.layer = Layer;
		B4.GetComponent<Ball> ().Direction = Direction2;
		
		B5.SetActive (true);
		Tr5.position = Pos5;
		B5.layer = Layer;
		B5.GetComponent<Ball> ().Direction = Direction2;

		B6.SetActive (true);
		Tr6.position = Pos6;
		B6.layer = Layer;
		B6.GetComponent<Ball> ().Direction = Direction2;

		B7.SetActive (true);
		Tr7.position = Pos7 ;
		B7.layer = Layer;
		B7.GetComponent<Ball> ().Direction = Direction2;
		yield return new WaitForSeconds (0.1f);
		
		Rb1.Sleep ();
		B1.GetComponent<TrailRenderer> ().time = Mathf.Infinity;
		Rb2.Sleep ();
		B2.GetComponent<TrailRenderer> ().time = Mathf.Infinity;
		Rb3.Sleep ();
		B3.GetComponent<TrailRenderer> ().time = Mathf.Infinity;
		Rb4.Sleep ();
		B4.GetComponent<TrailRenderer> ().time = Mathf.Infinity;
		Rb5.Sleep ();
		B5.GetComponent<TrailRenderer> ().time = Mathf.Infinity;
		Rb6.Sleep ();
		B6.GetComponent<TrailRenderer> ().time = Mathf.Infinity;
		Rb7.Sleep ();
		B7.GetComponent<TrailRenderer> ().time = Mathf.Infinity;
		Tr1.position = Pos1;
		Tr2.position = Pos2;
		Tr3.position = Pos3;
		Tr4.position = Pos4;
		Tr5.position = Pos5;
		Tr6.position = Pos6;
		Tr7.position = Pos7;




		if (Direction1.Equals (1)) {
			Rb1.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction1.Equals (2)) {
			Rb1.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction1.Equals (3)) {
			Rb1.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction1.Equals (4)) {
			Rb1.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction1.Equals (8)) {
			Rb1.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction1.Equals (7)) {
			Rb1.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction1.Equals (6)) {
			Rb1.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction1.Equals (5)) {
			Rb1.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction1.Equals (9)) {
			Rb1.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction1.Equals (10)) {
			Rb1.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction1.Equals (11)) {
			Rb1.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction1.Equals (12)) {
			Rb1.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		
		
		if (Direction2.Equals (1)) {
			Rb2.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction2.Equals (2)) {
			Rb2.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction2.Equals (3)) {
			Rb2.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction2.Equals (4)) {
			Rb2.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction2.Equals (6)) {
			Rb2.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction2.Equals (7)) {
			Rb2.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction2.Equals (8)) {
			Rb2.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction2.Equals (5)) {
			Rb2.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction2.Equals (9)) {
			Rb2.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction2.Equals (10)) {
			Rb2.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction2.Equals (11)) {
			Rb2.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction2.Equals (12)) {
			Rb2.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		
		
		if (Direction3.Equals (1)) {
			Rb3.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction3.Equals (2)) {
			Rb3.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction3.Equals (3)) {
			Rb3.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction3.Equals (4)) {
			Rb3.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction3.Equals (6)) {
			Rb3.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction3.Equals (7)) {
			Rb3.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction3.Equals (8)) {
			Rb3.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction3.Equals (5)) {
			Rb3.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction3.Equals (9)) {
			Rb1.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction3.Equals (10)) {
			Rb3.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction3.Equals (11)) {
			Rb3.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction3.Equals (12)) {
			Rb3.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		
		
		if (Direction4.Equals (1)) {
			Rb4.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction4.Equals (2)) {
			Rb4.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction4.Equals (3)) {
			Rb4.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction4.Equals (4)) {
			Rb4.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction4.Equals (6)) {
			Rb4.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction4.Equals (7)) {
			Rb4.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction4.Equals (8)) {
			Rb4.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction4.Equals (5)) {
			Rb4.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction4.Equals (9)) {
			Rb4.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction4.Equals (10)) {
			Rb4.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction4.Equals (11)) {
			Rb4.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction4.Equals (12)) {
			Rb4.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		
		if (Direction5.Equals (1)) {
			Rb5.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction5.Equals (2)) {
			Rb5.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction5.Equals (3)) {
			Rb5.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction5.Equals (4)) {
			Rb5.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction5.Equals (6)) {
			Rb5.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction5.Equals (7)) {
			Rb5.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction5.Equals (8)) {
			Rb5.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction5.Equals (5)) {
			Rb5.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction5.Equals (9)) {
			Rb5.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction5.Equals (10)) {
			Rb5.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction5.Equals (11)) {
			Rb5.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction5.Equals (12)) {
			Rb5.AddForce(V*new Vector2(178.9869f, -89.24f));
		}

		if (Direction6.Equals (1)) {
			Rb6.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction6.Equals (2)) {
			Rb6.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction6.Equals (3)) {
			Rb6.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction6.Equals (4)) {
			Rb6.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction6.Equals (6)) {
			Rb6.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction6.Equals (7)) {
			Rb6.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction6.Equals (8)) {
			Rb6.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction6.Equals (5)) {
			Rb6.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction6.Equals (9)) {
			Rb6.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction6.Equals (10)) {
			Rb6.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction6.Equals (11)) {
			Rb6.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction6.Equals (12)) {
			Rb6.AddForce(V*new Vector2(178.9869f, -89.24f));
		}

		if (Direction7.Equals (1)) {
			Rb7.AddForce (V*new Vector2 (200.0f, 0.0f));
		}
		if (Direction7.Equals (2)) {
			Rb7.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		if (Direction7.Equals (3)) {
			Rb7.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		if (Direction7.Equals (4)) {
			Rb7.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		if (Direction7.Equals (6)) {
			Rb7.AddForce(V*new Vector2(141.42f, -141.42f));
		}
		if (Direction7.Equals (7)) {
			Rb7.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (Direction7.Equals (8)) {
			Rb7.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (Direction7.Equals (5)) {
			Rb7.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (Direction7.Equals (9)) {
			Rb7.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (Direction7.Equals (10)) {
			Rb7.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (Direction7.Equals (11)) {
			Rb7.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (Direction7.Equals (12)) {
			Rb7.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		B1.GetComponent<Ball> ().Direction = Direction1;
		B2.GetComponent<Ball> ().Direction = Direction2;
		B3.GetComponent<Ball> ().Direction = Direction3;
		B4.GetComponent<Ball> ().Direction = Direction4;
		B5.GetComponent<Ball> ().Direction = Direction5;
		B6.GetComponent<Ball> ().Direction = Direction6;
		B7.GetComponent<Ball> ().Direction = Direction7;

		other.GetComponent<Rigidbody2D>().Sleep();
	}
	
	void Playing(){
		isPlaying = true;
	}
	
	void Reset(){
		isPlaying = false;
		isCopied = false;
		B1.GetComponent<TrailRenderer>().time = 0.0f;
		B1.SetActive(false);
		B1.GetComponent<Ball>().Dead = false;
		B2.GetComponent<TrailRenderer>().time = 0.0f;
		B2.SetActive(false);
		B2.GetComponent<Ball>().Dead = false;
		B3.SetActive(false);
		B3.GetComponent<TrailRenderer>().time = 0.0f;
		B3.GetComponent<Ball>().Dead = false;
		B4.SetActive(false);
		B4.GetComponent<TrailRenderer>().time = 0.0f;
		B4.GetComponent<Ball>().Dead = false;
		B5.SetActive(false);
		B5.GetComponent<TrailRenderer>().time = 0.0f;
		B5.GetComponent<Ball>().Dead = false;
		B6.SetActive(false);
		B6.GetComponent<TrailRenderer>().time = 0.0f;
		B6.GetComponent<Ball>().Dead = false;
		B7.SetActive(false);
		B7.GetComponent<TrailRenderer>().time = 0.0f;
		B7.GetComponent<Ball>().Dead = false;
		ChangeColor (0);
	}
}