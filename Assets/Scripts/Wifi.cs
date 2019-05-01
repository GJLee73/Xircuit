using UnityEngine;
using System.Collections;

public class Wifi : MonoBehaviour {

	public GameObject Exit;
	public GameObject Ba;
	public int OutDirection = 1;
	private Rigidbody2D rb;
	//public GameObject Starter;
	public float K;
	private TrailRenderer Tra;
	private SpriteRenderer S1;
	private SpriteRenderer S2;
	public float V = 10.0f;

	//public SpriteRenderer[] Pieces;

	void Awake(){
		rb = Ba.GetComponent<Rigidbody2D> ();
		Tra = Ba.GetComponent<TrailRenderer> ();
		S1 = GetComponent<SpriteRenderer> ();
		S2 = Exit.GetComponent<SpriteRenderer> ();
	}
	// Use this for initialization

	
	// Update is called once per frame


	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ball")) {
			other.GetComponent<SpriteRenderer>().enabled = false;
			ChangeColor(other.gameObject.layer-8, S1);
			StartCoroutine ("Transport", other.gameObject.layer);
		}
	
	}
	void Playing(){

	}

	void Reset(){
		StopCoroutine ("Transport");
		S1.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		S2.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		Tra.time = 0.0f;

		/*for (int i = 0; i<Pieces.Length; i++) {
			ChangeColorz (0, Pieces [i]);
		}*/

		//yield return new WaitForSeconds (0.1f);

		Ba.SetActive (false);
	}

	IEnumerator Transport(int L){
		yield return new WaitForSeconds (0.2f);
		ChangeColor(L - 8, S2);

		Ba.layer = L;
		//Ba.transform.position = Exit.transform.position;
		Ba.GetComponent<Ball> ().Direction = OutDirection;
		//Ba.GetComponent<TrailRenderer> ().time = 0.0f;
		//Ba.SetActive (true);
		//yield return new WaitForSeconds (0.05f);
		Ba.GetComponent<TrailRenderer> ().time = Mathf.Infinity;
		if(OutDirection.Equals(1)){

			Ba.transform.position = Exit.transform.position - new Vector3(K, 0.0f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time =Mathf.Infinity;
			rb.AddForce(V*new Vector2(200.0f, 0.0f));
		}
		else if(OutDirection.Equals(2)){
		
			Ba.transform.position = Exit.transform.position - new Vector3(0.0f, K, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time =Mathf.Infinity;
			rb.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		else if(OutDirection.Equals(3)){

			Ba.transform.position = Exit.transform.position + new Vector3(K,0.0f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time = Mathf.Infinity;
			rb.AddForce(V*new Vector2(-200.0f, 0.0f));
		}
		else if(OutDirection.Equals(4)){

			Ba.transform.position = Exit.transform.position + new Vector3(0.0f, K, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time =Mathf.Infinity;
			rb.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		else if(OutDirection.Equals(5)){
			Ba.transform.position = Exit.transform.position - new Vector3(K*0.717f, K*0.717f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time = Mathf.Infinity;
			rb.AddForce(V*new Vector2(200.0f*0.717f, 200.0f*0.717f));
		}
		else if(OutDirection.Equals(6)){
			Ba.transform.position = Exit.transform.position + new Vector3(K* 0.717f, -K*0.717f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time = Mathf.Infinity;
			rb.AddForce(V*new Vector2(-200.0f*0.717f, 200.0f*0.717f));
		}
		else if(OutDirection.Equals(7)){
			Ba.transform.position = Exit.transform.position + new Vector3(K*0.717f, K*0.717f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time = Mathf.Infinity;
			rb.AddForce(V*new Vector2(-200.0f*0.717f, -200.0f*0.717f));
		}
		else if(OutDirection.Equals(8)){
			Ba.transform.position = Exit.transform.position - new Vector3(K*0.717f, -K*0.717f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time = Mathf.Infinity;
			rb.AddForce(V*new Vector2(200.0f*0.717f, -200.0f*0.717f));
		}
		else if(OutDirection.Equals(9)){
			Ba.transform.position = Exit.transform.position - new Vector3(K*0.866f, K*0.5f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time = Mathf.Infinity;
			rb.AddForce(V*new Vector2(178.9869f, 89.24f));
		}
		else if(OutDirection.Equals(10)){
			Ba.transform.position = Exit.transform.position + new Vector3(K*0.866f, -K*0.5f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time = Mathf.Infinity;
			rb.AddForce(V*new Vector2(-178.9869f, 89.24f));
		}
		else if(OutDirection.Equals(11)){
			Ba.transform.position = Exit.transform.position + new Vector3(K*0.866f, K*0.5f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time = Mathf.Infinity;
			rb.AddForce(V*new Vector2(-178.9869f, -89.24f));
		}
		else if(OutDirection.Equals(12)){
			Ba.transform.position = Exit.transform.position + new Vector3(-K*0.866f, K*0.5f, 0.0f);
			Tra.time = 0.0f;
			Ba.SetActive (true);
			yield return new WaitForSeconds(0.05f);
			Tra.time = Mathf.Infinity;
			rb.AddForce(V*new Vector2(178.9869f, -89.24f));
		}
	}

	void ChangeColor(int C, SpriteRenderer S){
		if (C.Equals (0)) {
			S.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
		}
		else if (C.Equals (1)) {
			S.color = new Color(230/255f, 0.0f, 18/255f, 1.0f);
		}
		else if (C.Equals (2)) {
			S.color = new Color(0.0f, 153/255f, 68/255f, 1.0f);
		}
		else if (C.Equals (3)) {
			S.color = new Color(249/255f, 230/255f, 47/255f, 1.0f);
		}
		else if (C.Equals (4)) {
			S.color = new Color(0.0f, 71/255f, 157/255f, 1.0f);
		}
		else if (C.Equals (5)) {
			S.color = new Color(228/255f, 0.0f, 180/255f, 1.0f);
		}
		else if (C.Equals (6)) {
			S.color = new Color(0.0f, 160/255f, 233/255f, 1.0f);
		}
		else if (C.Equals (7)) {
			S.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	}

	/*void ChangeColorz(int C, SpriteRenderer S){
		if (C.Equals (0)) {
			S.color -= new Color(1.0f, 1.0f, 1.0f, 1.0f);
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
	}*/

}
	/*IEnumerator Updat(){
		while (true) {


			yield return new WaitForSeconds(0.1f);
		}
	}*/
	
