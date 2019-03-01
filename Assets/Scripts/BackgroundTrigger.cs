using UnityEngine;
using System.Collections;

public class BackgroundTrigger : MonoBehaviour {
	// Use this for initialization
	public Transform NeoBlockS;
	void Awake(){

	}

	void OnMouseDown(){
		for (int i=0; i<NeoBlockS.childCount; i++) {
			NeoBlockS.GetChild(i).SendMessage("Cloose", 8);
		}
	}

}
