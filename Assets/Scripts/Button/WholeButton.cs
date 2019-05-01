using UnityEngine;
using System.Collections;

public class WholeButton : MonoBehaviour {
	public GameObject Starts;
	public GameObject Reset;
	public GameObject FF;

	public int direction = 1;

	public Sprite[] Sprites;
	public GameObject CClone1;
	public GameObject CClone2;
	private Transform StartT;
	private Transform ResetT;
	private Transform FFT;
	private Vector3 Pos;
	public float X;
	private bool isClicked;
	private int Count;
	private int CurrentNumber;
	private SpriteRenderer S;
	private SpriteRenderer SS;
	private SpriteRenderer SR;
	private SpriteRenderer SF;
	private StartButton StartScript;
	private ResetButton ResetScript;
	private FFButton FFScript;
	private float Scale;
	private bool isOpening, isClosing;




	void Awake(){
		isOpening = false;
		isClosing = false;


		CurrentNumber = 1;
		isClicked = false;
		Pos = transform.position;
		StartT = Starts.transform;
		ResetT = Reset.transform;
		FFT = FF.transform;
		StartT.position = Pos+ new Vector3 (0.0f, 0.0f, 4.0f);
		ResetT.position = Pos+ new Vector3 (0.0f, 0.0f, 4.0f);
		FFT.position = Pos + new Vector3 (0.0f, 0.0f, 4.0f);
		Scale = transform.localScale.x;


		S = GetComponent<SpriteRenderer> ();
		StartScript = Starts.GetComponent<StartButton> ();
		ResetScript = Reset.GetComponent<ResetButton> ();
		FFScript = FF.GetComponent<FFButton> ();

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ball")) {
			//other.GetComponent<SpriteRenderer>().sortingLayerName ="Default";
		}
	}

	// Use this for initialization
	void OnMouseDown(){
		/*if (!PlayerPrefs.GetInt ("State").Equals (10)) {
			PlayerPrefs.SetInt ("State", 10);
		}*/

		if (!isClicked&&!isClosing) {
			isOpening = true;
			StartCoroutine("Open");
			isClicked = true;

			GetComponent<AudioSource> ().Play ();   // audio
		}
		else if (isClicked&&!isOpening) {
			isClosing = true;
			isClicked = false;
			StartCoroutine("Close", CurrentNumber );

			GetComponent<AudioSource> ().Play ();   // audio
		}
	}

	IEnumerator Open(){
		StopCoroutine ("Close");

		StartT.position = Pos;
		ResetT.position = Pos;
		FFT.position = Pos;

		while (!Count.Equals(100)) {

			Count++;

			StartT.rotation = Quaternion.Euler (0.0f,0.0f,3.6f * Count);
			FFT.rotation = Quaternion.Euler (0.0f,0.0f,3.6f * Count);
			ResetT.rotation = Quaternion.Euler (0.0f,0.0f,3.6f * Count);

			if (direction.Equals (1)) {
				StartT.position +=new Vector3 (0.0395f,0.0f,0.0f);
				FFT.position += new Vector3 (0.076f,0.0f,0.0f);
				ResetT.position += new Vector3 (0.1125f,0.0f,0.0f);
			}

			if (direction.Equals (2)) {
				StartT.position += new Vector3 (0.0f,0.0395f,0.0f);
				FFT.position += new Vector3 (0.0f,0.076f,0.0f);
				ResetT.position += new Vector3 (0.0f,0.1125f,0.0f);
			}

			if (direction.Equals (3)) {
				StartT.position -= new Vector3 (0.0395f,0.0f,0.0f);
				FFT.position -= new Vector3 (0.076f,0.0f,0.0f);
				ResetT.position -= new Vector3 (0.1125f,0.0f,0.0f);
			}

			if (direction.Equals (4)) {
				StartT.position -= new Vector3 (0.0f,0.0395f,0.0f);
				FFT.position -= new Vector3 (0.0f,0.076f,0.0f);
				ResetT.position -= new Vector3 (0.0f,0.1125f,0.0f);
			}

			yield return new WaitForFixedUpdate ();
		}



		StartScript.Enabled = true;
		ResetScript.Enabled = true;
		FFScript.Enabled = true;
		isOpening = false;


	}

	IEnumerator Close(int Number){
		StartScript.Enabled = false;
		ResetScript.Enabled = false;
		FFScript.Enabled = false;
		S.sprite = Sprites[Number];
		CurrentNumber = Number;
		isClicked = false;
		StopCoroutine ("Open");

		while (!Count.Equals(0)) {

			Count--;

			StartT.rotation = Quaternion.Euler (0.0f,0.0f,3.6f * Count);
			FFT.rotation = Quaternion.Euler (0.0f,0.0f,3.6f * Count);
			ResetT.rotation = Quaternion.Euler (0.0f,0.0f,3.6f * Count);

			if (direction.Equals (1)) {
				StartT.position -= new Vector3 (0.0395f,0.0f,0.0f);
				FFT.position -= new Vector3 (0.076f,0.0f,0.0f);
				ResetT.position -= new Vector3 (0.1125f,0.0f,0.0f);
			}

			if (direction.Equals (2)) {
				StartT.position -= new Vector3 (0.0f,0.0395f,0.0f);
				FFT.position -=new Vector3 (0.0f,0.076f,0.0f);
				ResetT.position -= new Vector3 (0.0f,0.1125f,0.0f);
			}

			if (direction.Equals (3)) {
				StartT.position += new Vector3 (0.0395f,0.0f,0.0f);
				FFT.position += new Vector3 (0.076f,0.0f,0.0f);
				ResetT.position += new Vector3 (0.1125f,0.0f,0.0f);
			}

			if (direction.Equals (4)) {
				StartT.position += new Vector3 (0.0f,0.0395f,0.0f);
				FFT.position += new Vector3 (0.0f,0.076f,0.0f);
				ResetT.position += new Vector3 (0.0f,0.1125f,0.0f);
			}

			yield return new WaitForFixedUpdate ();
		}

		StartT.position = Pos+ new Vector3 (0.0f, 0.0f, 4.0f);
		ResetT.position = Pos+ new Vector3 (0.0f, 0.0f, 4.0f);
		FFT.position = Pos + new Vector3 (0.0f, 0.0f, 4.0f);
		CClone1.SetActive (false);
		CClone2.SetActive (false);
		isClosing = false;


	}


void ChangetoReset(){
	S.sprite = Sprites [2];
}
// Update is called once per frame

}
