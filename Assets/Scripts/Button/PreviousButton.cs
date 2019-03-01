using UnityEngine;
using System.Collections;

public class PreviousButton : MonoBehaviour {

	// Use this for initialization
	public string PStage;
	
	// Update is called once per frame
	void OnMouseDown(){
		Application.LoadLevel (PStage);
	}

}
