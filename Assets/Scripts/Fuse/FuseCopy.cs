using UnityEngine;
using System.Collections;

public class FuseCopy : MonoBehaviour {
	public GameObject Ba;
	public GameObject Fuse;
	//bool A = true;
	//bool B = true;
	public bool isPlaying = false;
	public GameObject O;
	Rigidbody2D Rb;
	public bool First = true;
	public int OutDirection = 0;
	private TrailRenderer Tra;
	private SpriteRenderer S;
	private SpriteRenderer Sother;
	private int FuseC = 1;
	private float q, w, e;
	private int Count;
	private bool R;
	public float V = 10;
	//public Transform OutPlace;
	// Use this for initialization
	void Awake () {
		FuseC = Fuse.GetComponent<NeoFuse> ().FuseColor;
		Rb = Ba.GetComponent<Rigidbody2D> ();
		First = true;
		Tra = Ba.GetComponent<TrailRenderer> ();
		S = GetComponent<SpriteRenderer> ();
		Sother = O.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		//if (First) {
		if (other.CompareTag ("Ball") && !other.gameObject.Equals (Ba) && isPlaying) {
				if (!other.GetComponent<Ball> ().Dead) {
					other.GetComponent<Rigidbody2D> ().Sleep ();

					StartCoroutine(ColorChange(other.gameObject.layer -8));
					if(First){
					tag = "RemoveSprite";
					O.GetComponent<FuseCopy> ().First = false;
					First = false;
					}
					//ColorChange (other.gameObject.layer - 8, S);
					if (other.gameObject.layer.Equals (FuseC + 8)) {
						Fuse.SendMessage ("Broke");
					}
					if (!other.gameObject.layer.Equals (FuseC + 8)) {

						StartCoroutine ("Bal", other);
					}
				}
			}
			//}
		//}
	}

	void Playing(){
		isPlaying = true;
		R = true;
	}

	void Reset(){
		R = false;
		StopCoroutine ("ColorChange");
		Count = 0;
		isPlaying = false;
		First = true;
		Tra.time = 0.1f;
		Ba.SetActive(false);
		Ba.GetComponent<Ball>().Dead = false;
		S.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
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
			//Debug.Log("AA");
			Count++;
			S.color += 2.0f*new Color(q, w, e);
			yield return new WaitForSeconds(0.1f);
		}
	}

	IEnumerator Bal(Collider2D other){
		//yield return new WaitForSeconds (0.2f);
		//StartCoroutine(ColorChange(other.gameObject.layer-8, Sother));
		O.SendMessage ("ColorChange", other.gameObject.layer - 8);
		other.GetComponent<Rigidbody2D> ().Sleep ();
		other.GetComponent<Ball> ().Dead = true;
		Ba.SetActive(true);
		if (!other.gameObject.Equals (Ba)) {
			Ba.layer = other.gameObject.layer;
		}

		if (OutDirection.Equals (0)) {
			OutDirection = other.GetComponent<Ball> ().Direction;
		}

		Ba.transform.position = O.transform.position;
		Ba.GetComponent<Ball> ().Direction = OutDirection;
		other.GetComponent<Rigidbody2D> ().Sleep ();
		yield return new WaitForSeconds (0.1f);

		if (OutDirection.Equals (1)) {
			Rb.AddForce (V*new Vector2 (200.0f, 0.0f));
			//Debug.Log ("1");
			}
		if (OutDirection.Equals (2)) {
			//Debug.Log ("2");
			Rb.AddForce (V*new Vector2 (0.0f, 200.0f));
			}
		if (OutDirection.Equals (3)) {
			//Debug.Log ("3");
			Rb.AddForce (V*new Vector2 (-200.0f, 0.0f));
			}
		if (OutDirection.Equals (4)) {
			//Debug.Log ("4");
			Rb.AddForce (V*new Vector2 (0.0f, -200.0f));
			}
		if (OutDirection.Equals (5)) {
			//Debug.Log ("5");
			Rb.AddForce(V*new Vector2(141.42f, 141.42f));
		}
		if (OutDirection.Equals (6)) {
			//Debug.Log ("6");
			Rb.AddForce(V*new Vector2(-141.42f, 141.42f));
		}
		if (OutDirection.Equals (7)) {
			//Debug.Log ("7");
			Rb.AddForce(V*new Vector2(-141.42f, -141.42f));
		}
		if (OutDirection.Equals (8)) {
			//Debug.Log ("8");
			Rb.AddForce(V*new Vector2(141.42f, -141.42f));
		}

		if (OutDirection.Equals (9)) {
			Rb.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		if (OutDirection.Equals (10)) {
			Rb.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		if (OutDirection.Equals (11)) {
			Rb.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		if (OutDirection.Equals (12)) {
			Rb.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
		if (OutDirection.Equals (13)) {
			Rb.AddForce(V*new Vector2(89.24f, 178.9869f));
		}
		if (OutDirection.Equals (14)) {
			Rb.AddForce(V*new Vector2(-89.24f, 178.9869f));
		}
		if (OutDirection.Equals (15)) {
			Rb.AddForce(V*new Vector2(-89.24f, -178.9869f));
		}
		if (OutDirection.Equals (16)) {
			Rb.AddForce(V*new Vector2(89.24f, -178.9869f));
		}

		other.GetComponent<Rigidbody2D> ().Sleep ();
		Ba.layer = other.gameObject.layer;
		yield return new WaitForSeconds (0.1f);
		Tra.time = Mathf.Infinity;
	}

}
