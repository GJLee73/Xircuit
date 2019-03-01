using UnityEngine;
using System.Collections;

public class VerySmallBulb : MonoBehaviour {
	public GameObject Clone;
	private Transform CT;
	private SpriteRenderer CS;
	public int MAX = 20;
	public float WaveScaleV = 0.02f;
	public float WaveAlphaV = 0.1f;
	public float WaveStartScale = 0.1f;
	private AudioSource Au;
	public AudioClip A1;
	// Use this for initialization
	void Awake () {
		CT = Clone.transform;
		CS = Clone.GetComponent<SpriteRenderer> ();
		Au = GetComponent<AudioSource> ();
		//Scale = Clone.transform.localScale.x;
	}
	
	// Update is called once per frame
	IEnumerator Wave(){
		//Debug.Log ("AA");
		CT.position = transform.position + new Vector3 (0.0f, 0.0f, 0.0f);
		//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		CT.gameObject.SetActive (true);
		CS.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		Au.clip = A1;
		Au.Play ();
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
