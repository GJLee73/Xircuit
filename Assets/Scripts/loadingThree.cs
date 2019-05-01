using UnityEngine;
using System.Collections;

public class loadingThree : MonoBehaviour {

	public SpriteRenderer S;

	private bool touched = false;

	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (!touched) {
			touched = true;
			S.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		}
	}
}
