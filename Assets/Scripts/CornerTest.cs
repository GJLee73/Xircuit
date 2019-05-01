using UnityEngine;
using System.Collections;

public class CornerTest : MonoBehaviour {
	public float speed = (4*Mathf.PI)/5;
	private float angle;
	private Transform T;
	public SpriteRenderer[] Pieces;
	public int Direction = 1;
	private Rigidbody2D R;
	private bool E = true;
	private float Sp = 1.0f;
	private float Scale;
	private Transform Tr;
	private Vector3 Center;
	private Ball BaSc;
	public float V = 10.0f;

	// Use this for initialization
	void Awake () {

		speed = Mathf.PI / 5;
		Tr = transform;
		Scale = Tr.localScale.x;
		//speed = 7.353f;
		if (Direction.Equals (1)) {
			Center = Tr.position + Scale*new Vector3(-1.088f, -1.088f, 0.0f);
		}
		if (Direction.Equals (2)) {
			Center = Tr.position + Scale*new Vector3(1.088f, -1.088f, 0.0f);
		}
		if (Direction.Equals (3)) {
			Center = Tr.position + Scale*new Vector3(1.088f, 1.088f, 0.0f);
		}
		if (Direction.Equals (4)) {
			Center = Tr.position + Scale*new Vector3(-1.088f, 1.088f, 0.0f);
		}

	}
	
	// Update is called once per frame
	/*void Update () {
		if (T != null) {
			angle += speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
			T.position = transform.position - new Vector3(-1.024f, 1.024f)+ new Vector3( Mathf.Cos (angle) * radius, Mathf.Sin (angle) * radius);
		}
	}*/

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ball")) {
			T = other.transform;
			R = other.GetComponent<Rigidbody2D>();
			BaSc = other.GetComponent<Ball>();
	
			if(E){
				Sp = 1.0f/R.mass;
				E = false;
			if(Direction.Equals(1)){
				if(R.velocity.x>0){
						R.Sleep ();
						StartCoroutine(Circle (T, 1.570796f, -1));
				}
				else if(R.velocity.y>0){
						R.Sleep ();
						StartCoroutine(Circle (T, 0.0f, 1));
				}
			}
			 else if(Direction.Equals(2)){
				if(R.velocity.x<0){
						R.Sleep ();
					StartCoroutine(Circle (T, 1.570796f, 1));
				}
				else if(R.velocity.y>0){
						R.Sleep ();
					StartCoroutine(Circle (T, 3.141592f, -1));
				}
			}
			else if(Direction.Equals(3)){
				if(R.velocity.x<0){
						R.Sleep ();
					StartCoroutine(Circle (T, 4.7123f, -1));
				}
				else if(R.velocity.y<0){
						R.Sleep ();
					StartCoroutine(Circle (T, 3.141592f, 1));
				}
			}
			else if(Direction.Equals(4)){
				if(R.velocity.x>0){
						R.Sleep ();
					StartCoroutine(Circle (T, 4.7123f, 1));
				}
				else if(R.velocity.y<0){
						R.Sleep ();
					StartCoroutine(Circle (T, 6.283184f, -1));
				}
			}
			}
		}
	}

	IEnumerator Circle(Transform T, float angle, int D){
		float Max = angle + D * 1.5708f;
		R.Sleep ();
		if (D.Equals (1)) {
			while (angle<Max) {
				//Debug.Log("QQQQ");
				angle += Sp * speed * 0.01f;
				T.position = Center + Scale*1.088f*new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle));
				yield return new WaitForFixedUpdate();
			}
		} else if (D.Equals (-1)) {

			while (angle>Max) {
				angle -= Sp * speed * 0.01f;
				T.position = Center + Scale*1.088f*new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle));
				yield return new WaitForFixedUpdate();
			}
		}
		if (Direction.Equals (1)) {
			if (D.Equals (1)) {
				R.AddForce (V*new Vector2 (-200.0f, 0.0f));
				BaSc.Direction = 3;
			} else if (D.Equals (-1)) {
				R.AddForce (V*new Vector2 (0.0f, -200.0f));
				BaSc.Direction = 4;
			}

		} else if (Direction.Equals (2)) {
			if (D.Equals (1)) {
				R.AddForce (V*new Vector2 (0.0f, -200.0f));
				BaSc.Direction = 4;
			} else if (D.Equals (-1)) {
				R.AddForce (V*new Vector2 (200.0f, 0.0f));
				BaSc.Direction = 1;
			}
		} else if (Direction.Equals (3)) {
			if (D.Equals (1)) {
				R.AddForce (V*new Vector2 (200.0f, 0.0f));
				BaSc.Direction = 1;
			} else if (D.Equals (-1)) {
				R.AddForce (V*new Vector2 (0.0f, 200.0f));
				BaSc.Direction = 2;
			}
		} else if (Direction.Equals (4)) {
			if (D.Equals (1)) {
				R.AddForce (V*new Vector2 (0.0f, 200.0f));
				BaSc.Direction = 2;
			} else if (D.Equals (-1)) {
				R.AddForce (V*new Vector2 (-200.0f, 0.0f));
				BaSc.Direction = 3;
			}
		}
		
	}

	void Reset(){
		E = true;
		T = null;
		for (int i = 0; i<Pieces.Length; i++) {
			ChangeColor (0, Pieces [i]);
		}
	}

	void Playing(){

	}

	void ChangeColor(int C, SpriteRenderer S){
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
}
