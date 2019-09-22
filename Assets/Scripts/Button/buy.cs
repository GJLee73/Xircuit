using UnityEngine;
using System.Collections;

public class buy : MonoBehaviour {

	public GameObject buyWindow;

	void OnMouseDown () {
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.TheDash.Game&hl=en_US");
		buyWindow.SetActive (false);
	}

}
