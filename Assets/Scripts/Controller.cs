using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public GameObject Ba;

	public bool isPlaying = false;
	private Rigidbody2D Rb;
	public bool S = true;
	public Transform[] Folders;
	private Transform[] T;
	private Ball B;
	private TrailRenderer Tra;
	private Transform BT;
	private Vector3 Pos;
	public Rigidbody2D[] Rbs;
	public GameObject WholeButton;
	public float V = 10.0f;

	//public Transform[] Balls;

	//public GameObject folder;
	void Awake(){
		//Debug.Log (Screen.width + "*" + Screen.height);
		//Camera.main.orthographicSize = Screen.height / 18;
		//Camera.main.orthographicSize = (Screen.height / 22.3256f);
		//Screen.SetResolution (Screen.width, Screen.width / 16 * 9, true);
		T = new Transform [Folders.Length];
		
		for (int i = 0; i<Folders.Length ; i++) {
			T[i] = Folders[i];
		}

		isPlaying = false;
		Pos = transform.position;
	}

	// Use this for initialization
	void Start () {
		Rb = Ba.GetComponent<Rigidbody2D> ();
		B = Ba.GetComponent<Ball> ();
		Tra = Ba.GetComponent<TrailRenderer> ();
		BT = Ba.transform;
		Reset ();
		StartCoroutine ("Playing");
	}


	IEnumerator Playing(){
		//Debug.Log ("Playing");
		for(int j = 0; j<Rbs.Length; j++){
			Rbs[j].mass = 1.0f;
			Rbs[j].velocity *=0.5f;
		}
		if (CompareTag ("FF")) {
			tag = "Playing";
		}

		if (CompareTag ("Reset")) {
			for(int j = 0; j<T.Length; j++){
				for(int k =0; k<T[j].childCount; k++){
					T[j].GetChild(k).SendMessage("Playing");
				}
			}
			isPlaying = true;
			tag = "Playing";
			Ba.SetActive (true);
			yield return new WaitForSeconds (0.1f);
			B.Direction = 1;
			Rb.Sleep ();
			Rb.AddForce (V*new Vector2 (200.0f, 0.0f));
			//Ba.GetComponent<Ball>().isStarted = true;
	
			yield return new WaitForSeconds (0.1f);
			Tra.time = Mathf.Infinity;
		}

		//Ba.GetComponent<Ball>().S = true;
	}

	void Reset(){
		tag = "Reset";
		for(int j = 0; j<T.Length; j++){
			for(int k =0; k<T[j].childCount; k++){
				T[j].GetChild(k).SendMessage("Reset");
			}
		}


		Ba.layer = 8;
		BT.position = Pos;
		B.Dead = false;
		B.Checked = false;

		Ba.SetActive(false);
		Tra.time = 0.1f;
		Rb.Sleep ();
		if (isPlaying) {
			isPlaying = false;
			WholeButton.SendMessage("ChangetoReset");
		}
	}

	IEnumerator FF(){
	
		for(int j = 0; j<Rbs.Length; j++){

			Rbs[j].mass = 0.5f;
			Rbs[j].velocity *=2.0f;
		}
		if (CompareTag ("Playing")) {
			tag = "FF";
		}

		if (CompareTag ("Reset")) {
			tag = "FF";
			for (int j = 0; j<T.Length; j++) {
				for (int k =0; k<T[j].childCount; k++) {
					T [j].GetChild (k).SendMessage ("Playing");
				}
			}

		
				isPlaying = true;
				Ba.SetActive (true);
				yield return new WaitForSeconds (0.1f);
				B.Direction = 1;
				Rb.Sleep ();
				Rb.AddForce (V*new Vector2 (200.0f, 0.0f));
				//Ba.GetComponent<Ball>().isStarted = true;
			
				yield return new WaitForSeconds (0.1f);
				Tra.time = Mathf.Infinity;
			
		}
	}
}
	




