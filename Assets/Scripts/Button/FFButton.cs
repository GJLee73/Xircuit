using UnityEngine;
using System.Collections;

public class FFButton : MonoBehaviour {
	public GameObject Starter;
	public GameObject Clone1;
	public GameObject Clone2;
	private bool A = true;
	private bool B = false;
	private Transform T1;
	private Transform T2;
	private Transform T;
	private SpriteRenderer S1;
	private SpriteRenderer S2;
	public GameObject WholeButton;
	public bool Enabled;
	private float Scale;

	// Use this for initialization
	void Awake(){
		Scale = transform.localScale.x;
		Enabled = false;
		T1 = Clone1.transform;
		T2 = Clone2.transform;
		S1 = Clone1.GetComponent<SpriteRenderer> ();
		S2 = Clone2.GetComponent<SpriteRenderer> ();
		T = transform;
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		if (Enabled) {
			Enabled = false;
			WholeButton.SendMessage ("Close", 3);
			if (Starter.CompareTag ("Playing")||Starter.CompareTag("Reset")) {
				//Starter.GetComponent<Controller> ().isPlaying = false;
				//Starter.tag = "Reset";
				Starter.SendMessage ("FF");
			}
			StartCoroutine ("Clone");
		}	
	}


	IEnumerator Clone(){
		if(A){
			yield return new WaitForSeconds(0.1f);
			Clone1.SetActive(true);
			T1.position = T.position;
			for(int i =0; i<20; i++){
				yield return new WaitForSeconds(0.0005f);
				T1.localScale = Scale*new Vector3(0.7f + i*(0.05f),0.7f+i*(0.05f) , 0);
				S1.color = new Color(1.0f, 1.0f, 1.0f ,0.3f - i*0.015f);
				
			}
			yield return new WaitForSeconds(0.1f);
			A = false;
			B = true;
			Clone1.SetActive(false);
		}
		else if(B){
			yield return new WaitForSeconds(0.1f);
			Clone2.SetActive(true);
			T2.position = T.position;
			for(int i =0; i<20; i++){
				yield return new WaitForSeconds(0.0005f);
				T2.localScale = Scale*new Vector3(0.7f + i*(0.05f),0.7f+i*(0.05f) , 0);
				S2.color = new Color(1.0f, 1.0f, 1.0f ,0.3f - i*0.015f);
				
			}
			yield return new WaitForSeconds(0.1f);
			A = true;
			B = false;
			Clone2.SetActive(false);
		}
		
	}
}
