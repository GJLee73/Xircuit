using UnityEngine;
using System.Collections;

public class Corner : MonoBehaviour {
	public bool isPlaying = false;
	int a;
	public int N;
	public float L = 0.23f;
	//bool A = true;
	//bool B = true;
	//public GameObject Starter;
	//public GameObject Ba;
	private SpriteRenderer S;
	//public GameObject B;
	private Vector3 Pos;
	public float V = 10.0f;
	// Use this for initialization
	void Awake () {
		isPlaying = false;

		//StartCoroutine ("Updat");
		S = GetComponent<SpriteRenderer> ();
		Pos = transform.position;
	}
	


	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ball")) {

			//other.GetComponent<Rigidbody2D>().Sleep();
			StartCoroutine("CornerColor", other.gameObject.layer);
			//GetComponent<SpriteRenderer>().enabled = true;
			//StartCoroutine ("Bal1", other);
			Rigidbody2D Rb = other.GetComponent<Rigidbody2D>();
			Ball BaSc = other.GetComponent<Ball>();
		 if (N.Equals (1)) {
				if(Rb.velocity.y >0){
					Rb.Sleep();
					other.transform.position = Pos- new Vector3 (L, 0.0f, 0.0f);
					BaSc.Direction = 1;
					Rb.AddForce (V*new Vector2 (200.0f, 0.0f));
					
				}
				if(Rb.velocity.x<0){
					Rb.Sleep();
					other.transform.position = Pos + new Vector3 (0.0f, L, 0.0f);
					BaSc.Direction = 4;
					Rb.AddForce (V*new Vector2 (0.0f, -200.0f));
				}
			}
			
		else if (N.Equals (2)) {
				if(Rb.velocity.x>0){
					Rb.Sleep();
					other.transform.position = Pos + new Vector3 (0.0f, L, 0.0f);
					BaSc.Direction = 4;
					Rb.AddForce (V*new Vector2 (0.0f, -200.0f));
				}
				if(Rb.velocity.y>0){
					Rb.Sleep();
					other.transform.position = Pos + new Vector3 (L, 0.0f, 0.0f);
					BaSc.Direction = 3;
					Rb.AddForce (V*new Vector2 (-200.0f, 0.0f));
				}
			}
			
			else if (N.Equals (3)) {
				if(Rb.velocity.x>0){
					Rb.Sleep();
					other.transform.position = Pos - new Vector3 (0.0f, L, 0.0f);
					BaSc.Direction = 2;
					Rb.AddForce (V*new Vector2 (0.0f, 200.0f));
				}
				if(Rb.velocity.y<0){
					Rb.Sleep();
					other.transform.position = Pos + new Vector3 (L, 0.0f, 0.0f);
					BaSc.Direction = 3;
					Rb.AddForce (V*new Vector2 (-200.0f, 0.0f));
				}
			}
			
			else if (N.Equals (4)) {
				if(Rb.velocity.x<0){
					Rb.Sleep();
					other.transform.position = Pos- new Vector3 (0.0f, L, 0.0f);
					BaSc.Direction = 2;
					Rb.AddForce (V*new Vector2 (0.0f, 200.0f));
				}
				if(Rb.velocity.y<0){
					Rb.Sleep();
					other.transform.position = Pos- new Vector3 (L, 0.0f, 0.0f);
					BaSc.Direction = 1;
					Rb.AddForce (V*new Vector2 (200.0f, 0.0f));
				}
			}
			//other.GetComponent<Rigidbody2D> ().Sleep ();
		}
	}

	void Playing(){
		isPlaying = true;
	}

	void Reset(){
		S.enabled = false;
		isPlaying = false;
	}

	/*IEnumerator Updat(){
		while (true) {
			if (Starter.tag == "Playing") {
				if(B){
					isPlaying = true;
					A = true;
					B = false;
				}
			}
			if (Starter.tag == "Reset") {
				if(A){
					GetComponent<SpriteRenderer>().enabled = false;
					isPlaying = false;
				
					A = false;
					B = true;
				}
			}

			yield return new WaitForEndOfFrame();
		}
	}*/

	void CornerColor(int L){
		S.enabled = true;
		//yield return new WaitForSeconds (0.1f);
		if (L.Equals (8)) {
			S.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
		}
		if (L.Equals (9)) {
			S.color = new Color(230/255f, 0.0f, 18/255f, 1.0f);
		}
		if (L.Equals (10)) {
			S.color = new Color(0.0f, 153/255f, 68/255f, 1.0f);
		}
		if (L.Equals (11)) {
			S.color = new Color(249/255f, 230/255f, 47/255f, 1.0f);
		}
		if (L.Equals (12)) {
			S.color = new Color(0.0f, 71/255f, 157/255f, 1.0f);
		}
		if (L.Equals (13)) {
			S.color = new Color(228/255f, 0.0f, 180/255f, 1.0f);
		}
		if (L.Equals (14)) {
			S.color = new Color(0.0f, 160/255f,233/255f, 1.0f);
		}
		if (L.Equals (15)) {
			S.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}

	}

	}
