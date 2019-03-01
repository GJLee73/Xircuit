using UnityEngine;
using System.Collections;

public class EndBulb : MonoBehaviour {
	
	//public GameObject Starter;
	
	public GameObject Ba;
	private TrailRenderer Tra;
	private Rigidbody2D Rb;
	private Transform Btr;
	private Vector3 Pos;
	private float Scale;
	public int OutDirection = 1;
	public float V = 10.0f;
	public SpriteRenderer S1, S2;
	private SpriteRenderer S3;
	public float Interval = 0.5f;
	public AudioClip A1, A2, A3, A4;
	private AudioSource Au;
	public float FinalInterval = 0.5f;
	public int StageNumber;
	private GameObject NeoButton;
	public float FadeSpeed = 0.1f;
	public GameObject Clone;
	private Transform CT;
	private SpriteRenderer CS;
	public int MAX = 20;
	public float WaveScaleV = 0.02f;
	public float WaveAlphaV = 0.1f;
	public float WaveStartScale = 0.1f;
	public AudioSource Au2, Au3;
	private bool Z = true;
	//bool A = true;p
	//bool C = true;
	
	// Use this for initialization
	void Awake(){
		CT = Clone.transform;
		CS = Clone.GetComponent<SpriteRenderer> ();
		NeoButton = GameObject.Find ("NextButton");
		Au = GetComponent<AudioSource> ();
		S3 = GetComponent<SpriteRenderer> ();
		Rb = Ba.GetComponent<Rigidbody2D> ();
		Btr = Ba.transform;
		Pos = transform.position;
		Scale = transform.localScale.x;
		Ba.SetActive (false);
		Tra = Ba.GetComponent<TrailRenderer> ();
	}
	

	
	IEnumerator Playing(){
		while (S3.color.a > 0.0f) {
			S3.color -= new Color (0.0f, 0.0f, 0.0f, FadeSpeed);
			yield return new WaitForSeconds (0.1f);
		}
		while (S2.color.a > 0.0f) {
			S2.color -= new Color (0.0f, 0.0f, 0.0f, FadeSpeed);
			yield return new WaitForSeconds (0.1f);
		}
		while (S1.color.a > 0.0f) {
			S1.color -= new Color (0.0f, 0.0f, 0.0f, FadeSpeed);
			yield return new WaitForSeconds (0.1f);
		}
		S1.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		S2.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		S3.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	}
	
	IEnumerator Reset(){
		Z = true;
		StopCoroutine ("Playing");
		StopCoroutine ("Effect");
		S1.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		S2.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		S3.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		Ba.layer = 15;
		Btr.position = Pos - Scale * new Vector3 (2.2f, 0.0f, 0.0f);
		
		if(OutDirection.Equals(1)){
			Btr.position = Pos + Scale*new Vector3 (2.2f, 0.0f, 0.0f);
			
			//Rb.AddForce (new Vector3 (200.0f, 0, 0));
		}
		else if(OutDirection.Equals(2)){
			Btr.position = Pos + Scale*new Vector3 (0.0f, 2.2f, 0.0f);
			
			///Rb.AddForce (new Vector2 (0.0f, 200.0f));
		}
		else if(OutDirection.Equals(4)){
			Btr.position = Pos + Scale*new Vector3 (0.0f, -2.2f, 0.0f);
			
			//Rb.AddForce (new Vector2 (0.0f, -200.0f));
		}
		//if (bulbOn) {
		Tra.time = 0.0f;
		Rb.Sleep ();
		yield return new WaitForSeconds (0.1f);
		Ba.SetActive(false);

		//}
	}
	
	
	void OnTriggerEnter2D (Collider2D col) {
		if(col.CompareTag("Ball")&&!col.gameObject.Equals(Ba)){
			col.GetComponent<Rigidbody2D>().Sleep();
			if(col.gameObject.layer.Equals(15)){
				if (Z) {
					//Debug.Log ("AAA");
					NeoButton.SendMessage("StageCleared");
					Z = false;
					StartCoroutine ("Effect");
				}
			}
		}
	}

	

	IEnumerator Effect(){
		Ba.layer = 15;
		Au.clip = A1;
		Au.Play ();
		S1.color = new Color (1.0f, 1.0f, 1.0f,1.0f);
		S1.SendMessage ("Wave");
		yield return new WaitForSeconds(Interval);
		Au.clip = A2;
		Au.Play ();
		S2.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		S2.SendMessage ("Wave");
		yield return new WaitForSeconds(Interval);
		Au.clip = A3;
		Au.Play ();
		S3.color = new Color (1.0f, 1.0f, 1.0f, 1.0f); 
		StartCoroutine ("Wave");
		Ba.SetActive(true);
		Tra.time = Mathf.Infinity;
		if(OutDirection.Equals(1)){
			Btr.position = Pos + Scale*new Vector3(2.2f, 0.0f, 0.0f);
			Rb.AddForce(V*new Vector2(200.0f, 0.0f)); 
		}
		else if(OutDirection.Equals(2)){
			Btr.position = Pos + Scale*new Vector3(0.0f, 2.2f, 0.0f);
			Rb.AddForce(V*new Vector2(0.0f, 200.0f));
		}
		else if(OutDirection.Equals(4)){
			Btr.position = Pos + Scale*new Vector3(0.0f, -2.2f, 0.0f);
			Rb.AddForce(V*new Vector2(0.0f, -200.0f));
		}
		yield return new WaitForSeconds(FinalInterval);
		Au.clip = A4;
		Au.Play ();
		if (PlayerPrefs.GetInt ("ClearedStage") < StageNumber) {

			PlayerPrefs.SetInt ("ClearedStage", StageNumber);
		}
	}

	IEnumerator Wave(){
		//Debug.Log ("AA");
		CT.position = transform.position + new Vector3 (0.0f, 0.0f, 0.0f);
		//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		CT.gameObject.SetActive (true);
		CS.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		Au.clip = A1;
		Au2.clip = A2;
		Au3.clip = A3;
		Au.Play ();
		Au2.Play ();
		Au3.Play ();
		for (float i=0; i<MAX; i++) {
			CT.localScale = WaveStartScale*new Vector3(1.0f+WaveScaleV*i,1.0f+WaveScaleV*i, 0.0f); 
			CS.color -= new Color(0.0f, 0.0f, 0.0f, WaveAlphaV); 
			yield return new WaitForSeconds(0.06f);
		}
		CT.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		CT.gameObject.SetActive (false);
		CS.color += new Color(0.0f, 0.0f, 0.0f, 1.0f);
	}

}
