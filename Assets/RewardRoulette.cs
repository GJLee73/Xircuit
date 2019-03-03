using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewardRoulette : MonoBehaviour {
	public static RewardRoulette rouletteCircle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator RouletteAnim(List<Transform> arg){
		while (true) {
			foreach (Transform tr in arg) {
				transform.eulerAngles = tr.eulerAngles; 
				transform.position = tr.position;
				yield return new WaitForSeconds (1.0f);
			}
		}
	}
}
