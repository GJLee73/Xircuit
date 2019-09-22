using UnityEngine;
using System.Collections;

public class no : MonoBehaviour {

	public GameObject noWindow;

	void OnMouseDown () {
		noWindow.SetActive (false);
	}

}
