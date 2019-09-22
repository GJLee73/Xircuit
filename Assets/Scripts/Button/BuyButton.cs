using UnityEngine;
using System.Collections;

public class BuyButton : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad (gameObject);
		gameObject.SetActive (false);
	}

}
