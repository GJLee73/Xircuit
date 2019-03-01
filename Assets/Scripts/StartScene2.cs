using UnityEngine;
using System.Collections;

public class StartScene2 : MonoBehaviour {

	public GameObject ball;
	public GameObject ball2;
	public GameObject ball3;
	public GameObject ball4;
	public GameObject ball5;
	public GameObject ball6;
	public GameObject ball7;
	public GameObject ball8;

	public SpriteRenderer backG;

	void Awake(){
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
			backG.transform.localScale = new Vector3 (4.0f, 4.5f, 1.0f);
		} else if ((((float)Screen.width / Screen.height)>1.3f)&&(((float)Screen.width/Screen.height)<1.35f)) { //4/3
			backG.transform.localScale = new Vector3(4.0f, 5.5f, 1.0f);
		} else if ((((float)Screen.width / Screen.height)>1.65f)&&(((float)Screen.width/Screen.height)<1.7f)) { //5/37
			backG.transform.localScale = new Vector3(4.0f, 4.5f, 1.0f);
		}  else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			backG.transform.localScale = new Vector3(4.3f, 4.6f, 1.0f);
		}
	}

	// Use this for initialization
	void Start () {
		ball.GetComponent<TrailRenderer> ().material.color = new Color (0f, 0f, 0f);
		ball2.GetComponent<TrailRenderer> ().material.color = new Color (230/255f, 0f, 18/255f);
		ball3.GetComponent<TrailRenderer> ().material.color = new Color (0f, 153/255f, 68/255f);
		ball4.GetComponent<TrailRenderer> ().material.color = new Color (0f, 71/255f, 157/255f);
		ball5.GetComponent<TrailRenderer> ().material.color = new Color (1f, 1f, 1f);
		ball6.GetComponent<TrailRenderer> ().material.color = new Color (249/255f, 230/255f, 47/255f);
		ball7.GetComponent<TrailRenderer> ().material.color = new Color (228/255f, 0f, 180/255f);
		ball8.GetComponent<TrailRenderer> ().material.color = new Color (0f, 160/255f, 233/255f);
		StartCoroutine ("MoveMove");
		StartCoroutine ("Remove");
	}
	
	// Update is called once per frame

	void MoveMove () {
		ball.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (2000f, 0f));
		ball2.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (2000f, 0f));
		ball3.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 2000f));
		ball4.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 2000f));
		ball5.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-2000f, 0f));
		ball6.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-2000f, 0f));
		ball7.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, -2000f));
		ball8.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, -2000f));
	}

	IEnumerator Remove () {
		while (backG.color.a<1.0f) {
			backG.color += new Color (0.0f,0.0f,0.0f,5/255f);
			yield return new WaitForSeconds (0.05f);
		}
		Application.LoadLevel ("Intermid");
	}
}
