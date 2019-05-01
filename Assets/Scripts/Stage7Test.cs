using UnityEngine;
using System.Collections;

public class Stage7Test : MonoBehaviour {

	public int num = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Ball")) {
			num = col.gameObject.layer;
		}
	}
}
