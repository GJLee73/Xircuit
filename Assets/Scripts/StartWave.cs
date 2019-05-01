using UnityEngine;
using System.Collections;

public class StartWave : MonoBehaviour {

	public GameObject wave;

	public float CoreScaleV = 0.02f;
	public float CoreAlphaV = 0.1f;
	public int CoreMAX = 10;

	public float StartSize = 1.3f;

	public float interval = 1.5f;

	private Vector3 position;

	// Use this for initialization
	void Start () {
		position = transform.position;
		StartCoroutine ("WaveStart");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown () {
		// sound 추가 
		Application.LoadLevel("start2");
	}

	IEnumerator CoreWave(SpriteRenderer S, Transform T, Vector3 Po){
		T.position = Po;
		//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		T.gameObject.SetActive (true);
		for (float i=0; i<CoreMAX; i++) {
			T.localScale = StartSize * new Vector3(1.0f+CoreScaleV*i,1.0f+CoreScaleV*i, 0.0f); 
			S.color -= new Color(0.0f, 0.0f, 0.0f, CoreAlphaV); 
			yield return new WaitForSeconds(0.06f);
		}
		T.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		T.gameObject.SetActive (false);
		S.color += new Color(0.0f, 0.0f, 0.0f, 1.0f);
	}

	IEnumerator WaveStart () {
		while (true) {
			StartCoroutine(CoreWave(wave.GetComponent<SpriteRenderer>(),wave.transform,position));
			yield return new WaitForSeconds (interval);
		}
	}
}
