using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour {
	public SpriteRenderer Clone;
	public int MAX;
	public float ScaleV;
	public float AlphaV;
	private Transform T;
	public bool BenTuto;

	void Awake(){
		if (BenTuto) {
			DontDestroyOnLoad (this.gameObject);
			DontDestroyOnLoad (Clone.gameObject);
		}
		T = Clone.transform;
	}

	// Use this for initialization
	void Start(){
		StartCoroutine ("WaveRepeat");
	}

	IEnumerator WaveRepeat(){
		T.position = transform.position + new Vector3 (-0.81f, 0.83f, 0.0f); 
		while (true) {
			StartCoroutine ("CoreWave");
			yield return new WaitForSeconds (2.0f);
		}
	}

	void Fade(){
		Clone.gameObject.SetActive (false);
		this.gameObject.SetActive (false);
	}

	// Update is called once per frame
	IEnumerator CoreWave(){
		
		//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		Clone.gameObject.SetActive (true);
		Clone.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		for (float i=0; i<MAX; i++) {
			T.localScale = new Vector3(0.5f+ScaleV*i,0.5f+ScaleV*i, 0.0f); 
			Clone.color -= new Color(0.0f, 0.0f, 0.0f, AlphaV); 
			yield return new WaitForSeconds(0.06f);
		}
		T.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		T.gameObject.SetActive (false);
		Clone.color += new Color(0.0f, 0.0f, 0.0f, 1.0f);
	}
}
