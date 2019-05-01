using UnityEngine;
using System.Collections;

public class NeoBulb : MonoBehaviour {
	
	//public GameObject Starter;
	
	public GameObject B1, B2;
	
	public bool bulbOn = false;
	private TrailRenderer Tra1, Tra2;
	private Rigidbody2D Rb1, Rb2;
	private Transform Btr1, Btr2;
	private Vector3 Pos;
	private float Scale;
	public int OutDirection = 1;
	public float V = 1.0f;
	public SpriteRenderer[] SS;
	public GameObject Wick;
	private Rigidbody2D BR;
	private bool First;
	public GameObject Lighting, EffectCircle1;
	private SpriteRenderer CS1;
	private Transform CT1;
	private int K;
	public float ScaleA,ScaleB,ScaleC,ScaleD, ScaleE;
	public float ColorA, ColorB, ColorC, ColorD, ColorE = 0.01f;
	private float W;
	//bool A = true;
	//bool C = true;

	// Use this for initialization
	void Awake(){
		EffectCircle1.SetActive (false);
		CS1 = EffectCircle1.GetComponent<SpriteRenderer> ();
		CT1 = EffectCircle1.transform;

		Rb1 = B1.GetComponent<Rigidbody2D> ();
		Tra1 = B1.GetComponent<TrailRenderer> ();
		Tra2 = B2.GetComponent<TrailRenderer> ();
		Btr1 = B1.transform;
		Btr2 = B2.transform;
		Pos = transform.position;
		Scale = transform.localScale.x;
		Rb2 = B2.GetComponent<Rigidbody2D> ();
		B1.SetActive(false);
		B2.SetActive(false);
	}

	void OnMouseDown(){
		K = 0;
		StartCoroutine ("Effect");
	}

	void Playing(){
		
	}
	
	IEnumerator Reset(){
		K = 0;
		Lighting.SetActive (false);
		Wick.SendMessage ("Reset");
		B2.layer = 15;
		Btr1.position = Pos - Scale * new Vector3 (2.2f, 0.0f, 0.0f);
	
		if(OutDirection.Equals(1)){
			Btr2.position = Pos + Scale*new Vector3 (2.2f, 0.0f, 0.0f);
			
			//Rb.AddForce (new Vector3 (200.0f, 0, 0));
		}
		else if(OutDirection.Equals(2)){
			Btr2.position = Pos + Scale*new Vector3 (0.0f, 2.2f, 0.0f);
			
			///Rb.AddForce (new Vector2 (0.0f, 200.0f));
		}
		else if(OutDirection.Equals(4)){
			Btr2.position = Pos + Scale*new Vector3 (0.0f, -2.2f, 0.0f);
			
			//Rb.AddForce (new Vector2 (0.0f, -200.0f));
		}
		//if (bulbOn) {
			bulbOn = false;
			Tra1.time = 0.0f;
			Tra2.time = 0.0f;
			Rb1.Sleep ();
			Rb2.Sleep();
			yield return new WaitForSeconds (0.1f);
			B1.SetActive(false);
			B2.SetActive(false);
		for(int i=0; i<50; i++){
			SS[i].color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
		}
		First = true;
		//}
	}
	
	
	void OnTriggerEnter2D (Collider2D col) {
		if (!col.gameObject.layer.Equals (15)) {
			col.GetComponent<Rigidbody2D>().Sleep();
		}

		else if (col.CompareTag ("Ball")) {
			if (col.gameObject != B1) {
				if (First) {
					First = false;

					if (col.gameObject.layer.Equals (15)) {
						if(col.GetComponent<Rigidbody2D>().velocity.x>=0){
							col.GetComponent<Rigidbody2D> ().Sleep ();
							Btr1.position = Pos - Scale * new Vector3 (2.2f, 0.0f, 0.0f);
							B1.SetActive (true);
							Rb1.AddForce (V * new Vector2 (200.0f, 0.0f));
						}
						else if(col.GetComponent<Rigidbody2D>().velocity.x<0){
							col.GetComponent<Rigidbody2D> ().Sleep ();
							Btr1.position = Pos + Scale* new Vector3(2.2f, 0.0f, 0.0f);
							B1.SetActive(true);
							Rb1.AddForce(V* new Vector2(-200.0f, 0.0f));
						}
						B1.layer = 15;
						bulbOn = true;
					}
				}
			} /*else if (col.gameObject.Equals (B1) && !First&&bulbOn) {
				B2.SetActive (true);
				Tra2.time = Mathf.Infinity;
//				if (OutDirection.Equals (1)) {
					Rb2.AddForce (V * new Vector2 (200.0f, 0.0f));
				} else if (OutDirection.Equals (2)) {
					Rb2.AddForce (V * new Vector2 (0.0f, 200.0f));
				} else if (OutDirection.Equals (4)) {
					Rb2.AddForce (V * new Vector2 (0.0f, -200.0f));
				}
			}*/
		}
}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.Equals (B1) && !First) {
			B1.SetActive(false);
			B2.SetActive (true);
			Tra2.time = Mathf.Infinity;
			Lighting.SetActive(true);
			if (OutDirection.Equals (1)) {
				Rb2.AddForce (V * new Vector2 (200.0f, 0.0f));
			} else if (OutDirection.Equals (2)) {
				Rb2.AddForce (V * new Vector2 (0.0f, 200.0f));
			} else if (OutDirection.Equals (4)) {
				Rb2.AddForce (V * new Vector2 (0.0f, -200.0f));
			}
			StartCoroutine("Effect");
		}
	}

	IEnumerator FirstOn(){
		yield return new WaitForSeconds(0.1f);
		First = false;
	}

	IEnumerator Effect(){
		yield return new WaitForSeconds (0.15f);
		W = 0.002f;
		EffectCircle1.SetActive (true);
		CT1.localScale = new Vector3 (1.6f, 1.6f, 1.0f);
		CS1.color = new Color (1.0f, 1.0f, 1.0f, 0.35f);
		while(K<5){
			K++;
			CT1.localScale += new Vector3(ScaleA, ScaleA, 0.0f);
			CS1.color -= new Color(0.0f, 0.0f, 0.0f, ColorA);
			yield return new WaitForSeconds(0.01f);
		}

		while (K>4&&K<12) {
			K++;
			CT1.localScale += new Vector3(ScaleB, ScaleB, 0.0f);
			CS1.color -= new Color(0.0f, 0.0f, 0.0f, ColorB);
			yield return new WaitForSeconds(0.01f);
		}

		while (K>11&&K<26) {
			K++;
			CT1.localScale += new Vector3(ScaleC,ScaleC,0.0f);
			CS1.color -= new Color(0.0f, 0.0f, 0.0f,ColorC);
			//c += 0.04f;
			yield return new WaitForSeconds(0.01f);
		}

		while (K>25&&K<49) {
			K++;
			CT1.localScale += new Vector3(ScaleD,ScaleD,0.0f);
			CS1.color-= new Color(0.0f, 0.0f, 0.0f, ColorD);
			yield return new WaitForSeconds(0.01f);
		}

		while (K>48&&K<64) {
			K++;
			CT1.localScale += new Vector3(ScaleE, ScaleE, 0.0f);
			CS1.color -= new Color(0.0f, 0.0f, 0.0f, ColorE);
			yield return new WaitForSeconds(0.01f);
		}
	
	}
}
