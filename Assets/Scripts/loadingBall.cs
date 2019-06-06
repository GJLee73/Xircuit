using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadingBall : MonoBehaviour {
	public float ChangeSpeed;
	// Use this for initialization

	void Awake () {
		transform.position = new Vector3 (-12.0f, 25.0f, 0.0f);

		/*if ((((float)Screen.width / Screen.height) > 1.7f) && (((float)Screen.width / Screen.height) < 1.8f)) {
			Screen.SetResolution (800,500,true);
		}*/
	}

	void OnCollisionEnter2D(Collision2D col){
		StartCoroutine ("SceneChange");
	}

	IEnumerator SceneChange(){
		yield return new WaitForSeconds (ChangeSpeed);
		SceneManager.LoadScene (1);
	}
}
