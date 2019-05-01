using UnityEngine;
using System.Collections;

public class BackG : MonoBehaviour {

	public GameObject Explain;
	public bool canCancel = false;

	// Use this for initialization

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			if (canCancel) {
				Explain.SendMessage("Cancel");
			}
		}
	}
}
