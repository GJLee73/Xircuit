using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {


	TrailRenderer Clone;
	public Rigidbody2D rb;

	TrailRenderer T;
	//public bool S = true;
	public int Direction = 1;
	bool A = true;
	bool C = true;
	public bool isPlaying = false;
	public bool Dead = false;
	//public GameObject Starter;
	//public bool isStarted = false;
	public GameObject  G;
	public bool Checked = false;
	private SpriteRenderer S;

	// Use this for initialization
	void OnDisable(){
		Dead = false;
		T.sortingLayerName = "Ball";
		T.sortingOrder = 1;
	}
	


	void OnEnable(){
		tag = "Ball";
		G = GetComponent<Collider2D> ().gameObject;
		isPlaying = true;
		T = GetComponent<TrailRenderer> ();
		//isStarted = false;
		//isPlaying = false;
		//if (isPlaying) {

		T.material.color = new Color (0.0f, 0.0f, 0.0f, 255.0f);
		rb = GetComponent<Rigidbody2D> ();
		S = GetComponent<SpriteRenderer> ();
		S.enabled = true;
		Dead = false;
		Checked = false;
		//StartCoroutine ("Updat");
		T.sortingLayerName = "Ball";
		T.sortingOrder = 1;
	}
	// Update is called once per frame

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("Enter");
		if (other.CompareTag ("RemoveSprite")) {
			S.enabled = false;
		}

		if (other.gameObject.layer.Equals (24)) {
			StartCoroutine("Connection", other);
		}

		if (G.layer.Equals(8)) { // Black
			T.material.color= new Color (0/255.0f, 0.0f/255.0f, 0.0f/255.0f, 1.0f);
			S.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
		}
		if (G.layer.Equals(9)) { // Red
			T.material.color = new Color (230/255f, 0.0f, 18/255f, 1.0f);
			S.color = new Color(230/255f, 0.0f, 18/255f, 1.0f);
		}
		if (G.layer.Equals(10)){ // Green
			T.material.color = new Color (0.0f, 153/255f, 68/255f, 1.0f);
			S.color = new Color(0.0f, 153/255f, 68/255f, 1.0f);
		}
		if (G.layer.Equals(11)) { //yellow
			T.material.color = new Color (249/255f, 230/255f, 47/255f, 1.0f);
			S.color = new Color(249/255f, 230/255f, 47/255f, 1.0f);
		}
		if (G.layer.Equals(12)) { //Blue
			S.color = new Color(0.0f, 71/255f, 157/255f, 1.0f);
			T.material.color = new Color (0.0f, 71/255f, 157/255f, 1.0f);
		}
		if (G.layer.Equals(13)) { //Magenta
			S.color = new Color(228/255f, 0.0f, 180/255f, 1.0f);
			T.material.color = new Color (228/255f, 0.0f, 180/255f, 1.0f);
		}
		if (G.layer.Equals(14)) { //Cyan
			S.color = new Color(0.0f, 160/255f, 233/255f, 1.0f);
			T.material.color = new Color (0.0f, 160/255f, 233/255f, 1.0f);
		}
		if (G.layer.Equals(15)) { //White
			S.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			T.material.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		}

		/*if (isPlaying&&Starter.CompareTag("Playing")) {
			//isStarted = true;
		}*/



		/*if (other.CompareTag("Entrance")) {
			rb.Sleep ();
		}*/

		if (other.CompareTag("Blocking")) {

			rb.Sleep();

		
		} 
	}

	/*void OnTriggerStay2D(Collider2D other){
		//if(S){
		if (other.CompareTag("Player")) {
			//S = false;
			//Debug.Log ("Succccc");
		
				//Player();
			
				/*if(rb.IsSleeping()&&!Dead){
					Debug.Log ("Succccc");
					rb.AddForce(new Vector2(200.0f,0.0f));
		//		{ 
			}
		}*/

	IEnumerator Connection(Collider2D other){
		while (true) {
			if(other.CompareTag("Player")){
				Player ();
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	void Player(){
		StopCoroutine ("Connection");
		if (rb.IsSleeping() && !Dead) {
			if(Direction.Equals(1)){
				rb.AddForce(new Vector2(200.0f , 0.0f));
			}
			if(Direction.Equals(2)){
				rb.AddForce(new Vector2(0.0f , 200.0f));
			}
			if(Direction.Equals(3)){
				rb.AddForce(new Vector2(-200.0f , 0.0f));
			}
			if(Direction.Equals(4)){
				rb.AddForce(new Vector2(0.0f , -200.0f));
			}
			if (Direction.Equals (8)) {
				rb.AddForce(new Vector2(141.42f, -141.42f));
			}
			if (Direction.Equals (7)) {
				rb.AddForce(new Vector2(-141.42f, -141.42f));
			}
			if (Direction.Equals (6)) {
				rb.AddForce(new Vector2(-141.42f, 141.42f));
			}
			if (Direction.Equals (5)) {
				rb.AddForce(new Vector2(141.42f, 141.42f));
			}
			if (Direction.Equals (9)) {
				rb.AddForce(new Vector2(178.9869f, 89.24f));
			}
			if (Direction.Equals (10)) {
				rb.AddForce(new Vector2(-178.9869f, 89.24f));
			}
			if (Direction.Equals (11)) {
				rb.AddForce(new Vector2(-178.9869f, -89.24f));
			}
			if (Direction.Equals (12)) {
				rb.AddForce(new Vector2(178.9869f, -89.24f));
			}
		}
	}


	void Playing(){
		if(C){
			//Debug.Log (name);
			isPlaying = true;
			A = true;
			C = false;
		}
	}

	void Reset(){
		if(A){
			Checked = false;
			isPlaying = false;
			A = false;
			C = true;
			this.gameObject.SetActive(false);
		}
	}

}


