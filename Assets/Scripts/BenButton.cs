using UnityEngine;
using System.Collections;

public class BenButton : MonoBehaviour {

	public SpriteRenderer bigOne;
	public SpriteRenderer smallOne;

	public SpriteRenderer benDiagram;

	private int CountNum = 0;

	private bool isButton = true;
	private bool onChange = false;

	public float x = 1.2f;
	public GameObject Pointer;
	public bool Tuto = false;
	public AudioSource SoundPlayer2;
	private AudioSource Au;
	public AudioClip Sound1, Sound2;
	private Transform Tr;
	public Transform Focus;
	public GameObject Clone;

	public SpriteRenderer blind;

	// Use this for initialization

	// Update is called once per frame
	/*void Update () {
		if (Input.GetMouseButtonDown (1)) {
			PlayerPrefs.SetInt ("ClearedStage", 60);
		}
	}*/

	void OnLevelWasLoaded(){
		if (Application.loadedLevelName.Equals ("new stage1") || Application.loadedLevelName.Equals ("Intermid")) {
			if (Tuto) {
				Pointer.SetActive (true);
				Focus.gameObject.SetActive (true);
	
			}
		} else {
			Tuto = false;
			Pointer.SetActive (false);
			Focus.gameObject.SetActive (false);
			Clone.SetActive (false);
		}
	}

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
		Tr = transform;
		Au = GetComponent<AudioSource> ();
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
			Tr.position = new Vector3(-33.0f, 19.0f, -3.0f);
		} else if ((((float)Screen.width / Screen.height)>1.3f)&&(((float)Screen.width/Screen.height)<1.35f)) { //4/3
			Tr.position = new Vector3(-33f, 24.0f, -3.0f);
		} else if ((((float)Screen.width / Screen.height)>1.65f)&&(((float)Screen.width/Screen.height)<1.7f)) { //5/3
			Tr.position = new Vector3(-34.0f, 19.0f,-3.0f);
		} else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			Tr.position = new Vector3 (-30.5f, 19.0f, -3.0f);
		}
		if (Tuto) {
			Pointer.transform.position = Tr.position + new Vector3 (0.81f, -0.83f, 0.0f);
		}
	}

	void OnMouseDown () {

	}

	void OnMouseUp () {
		if (Tuto) {
			Tuto = false;
			Focus.gameObject.SetActive (false);
			Pointer.SendMessage ("Fade");
		}
		StartCoroutine (Fade ());
	}

	/*
	void OnMouseDown () {
		if (isButton && !onChange) {
			Au.clip = Sound1;
			Au.Play ();
			//bigOne.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			//smallOne.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			bigOne.gameObject.transform.localScale = new Vector3 (0.2f * x,0.2f * x,1.0f);
			smallOne.gameObject.transform.localScale = new Vector3 (0.4f * x,0.4f * x,1.0f);

		}
	}

	void OnMouseUp () {

		if (isButton && !onChange) {
			SoundPlayer2.clip = Sound2;
			SoundPlayer2.Play ();
			if (Tuto) {
				Tuto = false;
				Focus.gameObject.SetActive (false);
				Pointer.SendMessage ("Fade");
			}
			//bigOne.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
			//smallOne.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);

			bigOne.gameObject.transform.localScale = new Vector3 (0.2f,0.2f,1.0f);
			smallOne.gameObject.transform.localScale = new Vector3 (0.4f,0.4f,1.0f);

			//Debug.Log ("AAAA");

			//Vector2 pos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
			//Vector2 pos2 = Camera.main.ScreenToWorldPoint (pos);

			//Debug.Log (pos2);

			//if (pos2.x < transform.position.x + 2 && pos2.x > transform.position.x - 2)
			//if (pos2.y < transform.position.y + 2 && pos2.y > transform.position.y - 2)
				StartCoroutine ("changeBen");
		}

		if (!isButton && !onChange) {
			//Debug.Log ("Yes");

			//Vector2 pos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
			//Vector2 pos2 = Camera.main.ScreenToWorldPoint (pos);

			//if (pos2.x < transform.position.x + 4 && pos2.x > transform.position.x - 4)
			//if (pos2.y < transform.position.y + 4 && pos2.y > transform.position.y - 4)
				StartCoroutine ("changeBut");
		}
	}
	*/

	IEnumerator changeBen () {
		onChange = true;

		benDiagram.transform.position = transform.position;

		//GetComponent <BoxCollider2D> ().size = new Vector2 (4.0f, 4.0f);

		while (CountNum < 100) {
			//Debug.Log ("start");

			CountNum++;

			bigOne.color -= new Color (0.0f,0.0f,0.0f,0.01f);
			smallOne.color -= new Color (0.0f,0.0f,0.0f,0.01f);

			benDiagram.color += new Color (0.0f,0.0f,0.0f,0.01f);

			yield return new WaitForSeconds (0.02f);
		}

		isButton = false;
		onChange = false;
	}

	IEnumerator changeBut () {
		//Debug.Log ("Good");

		onChange = true;

		//GetComponent <BoxCollider2D> ().size = new Vector2 (2.0f, 2.0f);

		while (CountNum > 0) {
			//Debug.Log ("start");

			CountNum--;

			bigOne.color += new Color (0.0f,0.0f,0.0f,0.01f);
			smallOne.color += new Color (0.0f,0.0f,0.0f,0.01f);

			benDiagram.color -= new Color (0.0f,0.0f,0.0f,0.01f);

			yield return new WaitForSeconds (0.02f);
		}

		isButton = true;
		onChange = false;
	}

	IEnumerator Fade () {
		blind.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		for (int i = 0; i < 20; i++) {
			blind.GetComponent<SpriteRenderer> ().color += new Color (0.0f, 0.0f, 0.0f, 0.05f);
			yield return new WaitForSeconds (0.075f);
		}

		blind.transform.position = new Vector3 (-101.0f, 0.1f, 0.0f);
		GameObject.FindWithTag ("MainCamera").transform.position = new Vector3 (-101.0f, 0.1f, -10.0f);
		for (int i = 0; i < 20; i++) {
			blind.GetComponent<SpriteRenderer> ().color -= new Color (0.0f, 0.0f, 0.0f, 0.05f);
			yield return new WaitForSeconds (0.075f);
		}
	}
}
