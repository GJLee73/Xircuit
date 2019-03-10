using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TheDashLogo : MonoBehaviour {
	public float ChangeSpeed = 2.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine ("SceneChange");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SceneChange(){
		yield return new WaitForSeconds (ChangeSpeed);
		SceneManager.LoadScene (1);
	}
}
