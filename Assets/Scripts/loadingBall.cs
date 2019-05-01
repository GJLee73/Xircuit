using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadingBall : MonoBehaviour {
	public float ChangeSpeed;
	// Use this for initialization

	void Awake () {
		transform.position = new Vector3 (-12.0f, 25.0f, 0.0f); 
	}

	void OnCollisionEnter2D(Collision2D col){
		StartCoroutine ("SceneChange");
	}

	IEnumerator SceneChange(){
		yield return new WaitForSeconds (ChangeSpeed);
		SceneManager.LoadScene (1);
	}
}
