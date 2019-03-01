using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {
	public SpriteRenderer[] Clones;
	public Transform[] Transforms;
	public int Maxsize;
	public float SizeSpeed;
	public float Colorspeed;
	public float Interval = 0.5f;
	private int L;
	private int Order;
	public Material Default;
	public Material Glowing;
	private SpriteRenderer S;
	// Use this for initialization
	void Awake(){
		Maxsize = 10;
		SizeSpeed = 0.05f;
		Colorspeed = 0.07f;
		Interval = 1.3f;
	}

	void Start () {
		//StartCoroutine ("Test");
		L = Clones.Length;
		//Debug.Log (L);
		StartCoroutine ("Test");
		S = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	IEnumerator Test(){
		while (true){
			Order = (Order + 1)%L;
			StartCoroutine(Wave(Clones[Order], Transforms[Order]));
			yield return new WaitForSeconds(Interval);
		}
	}

	IEnumerator Wave(SpriteRenderer S, Transform T){
		T.position = transform.position + new Vector3 (0.0f, 0.0f, 0.0f);
		//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		T.gameObject.SetActive (true);
		for (float i=0; i<Maxsize; i++) {
			T.localScale = new Vector3(1.0f+SizeSpeed*i,1.0f+SizeSpeed*i, 0.0f); 
			S.color -= new Color(0.0f, 0.0f, 0.0f, 0.1f); 
			yield return new WaitForSeconds(Colorspeed);
		}
		T.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		T.gameObject.SetActive (false);
		S.color += new Color(0.0f, 0.0f, 0.0f, 1.0f);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {

				S.material = Default;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
				S.material = Glowing;
		}
	}
}
