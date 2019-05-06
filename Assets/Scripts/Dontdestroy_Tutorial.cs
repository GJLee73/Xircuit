using UnityEngine;
using System.Collections;

public class Dontdestroy_Tutorial : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}
}
