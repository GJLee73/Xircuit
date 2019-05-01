using UnityEngine;
using System.Collections;

public class StartBgm : MonoBehaviour {
	public Transform BackGround, Circuit7;

	void Awake(){
		//Debug.Log ((float)Screen.width / Screen.height);
		if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
			BackGround.localScale = new Vector3 (4.0f, 4.5f, 1.0f);
			Camera.main.orthographicSize = 23.0f;
			Circuit7.localScale = new Vector3 (7.0f, 7.0f, 1.0f);
		} else if ((((float)Screen.width / Screen.height)>1.3f)&&(((float)Screen.width/Screen.height)<1.35f)) { //4/3
			BackGround.localScale = new Vector3(4.0f, 5.5f, 1.0f);
			Camera.main.orthographicSize = 28.0f;
			Circuit7.localScale = new Vector3(7.0f, 7.0f, 1.0f);
			Circuit7.position = new Vector3 (0.0f, -2.0f, 0.0f);
		} else if ((((float)Screen.width / Screen.height)>1.65f)&&(((float)Screen.width/Screen.height)<1.7f)) { //5/37
			BackGround.localScale = new Vector3(4.0f, 4.5f, 1.0f);
			Circuit7.localScale = new Vector3(7.0f, 7.0f, 1.0f);
			Camera.main.orthographicSize = 23.0f;
		} else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
			BackGround.localScale = new Vector3(4.3f, 4.6f, 1.0f);
			Circuit7.localScale = new Vector3(6.5f, 7.0f, 1.0f);
			Camera.main.orthographicSize = 23.0f;
		}
		DontDestroyOnLoad (this);
	}

	void OnLevelWasLoaded(){
		if (Application.loadedLevelName.Equals ("start2")) {
			BackGround = GameObject.Find ("BackGround").transform;
			Circuit7 = GameObject.Find ("circuit7").transform;
			if (((float)Screen.width / Screen.height)>1.59f&&((float)Screen.width / Screen.height)<1.61f) {  //16/10
				BackGround.localScale = new Vector3 (4.0f, 4.5f, 1.0f);
				Camera.main.orthographicSize = 23.0f;
				Circuit7.localScale = new Vector3 (7.0f, 7.0f, 1.0f);
			} else if ((((float)Screen.width / Screen.height) > 1.3f) && (((float)Screen.width / Screen.height) < 1.35f)) { //4/3
				BackGround.localScale = new Vector3 (4.0f, 5.5f, 1.0f);
				Camera.main.orthographicSize = 28.0f;
				Circuit7.localScale = new Vector3 (7.0f, 7.0f, 1.0f);
				Circuit7.position = new Vector3 (0.0f, -2.0f, 0.0f);
			} else if ((((float)Screen.width / Screen.height) > 1.65f) && (((float)Screen.width / Screen.height) < 1.7f)) { //5/37
				BackGround.localScale = new Vector3 (4.0f, 4.5f, 1.0f);
				Circuit7.localScale = new Vector3 (7.0f, 7.0f, 1.0f);
				Camera.main.orthographicSize = 23.0f;
			}  else if ((((float)Screen.width / Screen.height) > 1.49f) && (((float)Screen.width / Screen.height) < 1.51f)) { //3/2
				BackGround.localScale = new Vector3(4.3f, 4.6f, 1.0f);
				Circuit7.localScale = new Vector3(6.5f, 7.0f, 1.0f);
				Camera.main.orthographicSize = 23.0f;
			}
		}
	}
}
		
