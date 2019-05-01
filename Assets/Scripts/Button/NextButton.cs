using UnityEngine;
using System.Collections;

public class NextButton : MonoBehaviour {
	public Transform[] Folders;
	public SpriteRenderer[] S;
	public SpriteRenderer Number1;
	public SpriteRenderer Number2;
	public string NStage;
	private int a = 0;
	// Use this for initialization
	void Awake () {
	

		//SpriteRenderer[] S = new SpriteRenderer[300];
		/*for(int j = 0; j<Folders.Length; j++){
			for(int k =0; k<Folders[j].childCount; k++){
				S[a] = Folders[j].GetChild(k).GetComponent<SpriteRenderer>();
				a++;
			}
		}
		for (int t =0; t<a; t++) {
			S[t].color -= new Color(0.0f, 0.0f, 0.0f, 1.0f);
		}*/

		/*for(int j = 0; j<Folders.Length; j++){
			for(int k =0; k<Folders[j].childCount; k++){
				Folders[j].GetChild(k).GetComponent<SpriteRenderer>().color -= new Color(0.0f, 0.0f, 0.0f, 1.0f);
			}
		}*/
	}
	
	// Update is called once per frame
	void Start(){
		a = 0;
		//SpriteRenderer[] S = new SpriteRenderer[300];
		for(int j = 0; j<Folders.Length; j++){
			for(int k =0; k<Folders[j].childCount; k++){
				S[a] = Folders[j].GetChild(k).GetComponent<SpriteRenderer>();
				a++;
			}
		}
		for (int t =0; t<a; t++) {
			S[t].color -= new Color(0.0f, 0.0f, 0.0f, 1.0f);
		}
		StartCoroutine ("MapStart");
	}

	void OnMouseDown(){

		//FadeOut ();
		Application.LoadLevel (NStage);
		//StartCoroutine ("In");
	}

	IEnumerator MapStart(){
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (Out(Number1));
		StartCoroutine (Out (Number2));
		for (int j=0; j<a; j++) {
			StartCoroutine(In(S[j]));
		}
		//StartCoroutine ("Out", Number);
	}

	IEnumerator In(SpriteRenderer X){
		while (!X.color.a.Equals(1.0f)) {
			/*if(S.color.a.Equals(1.0f)){
				break;
			}*/

			X.color +=new Color(0.0f, 0.0f, 0.0f, 0.1f);
			yield return new WaitForSeconds(0.1f);
			}
			
		}



	/*void FadeOut(){
		for(int j = 0; j<Folders.Length; j++){
			for(int k =0; k<Folders[j].childCount; k++){
				//Folders[j].GetChild(k).GetComponent<SpriteRenderer>().color -= new Color(0.0f, 0.0f, 0.0f, 10.0f);
					//T[j].GetChild(k).SendMessage("Playing");
				//yield return new WaitForSeconds(0.1f);
				StartCoroutine("Out", Folders[j].GetChild(k).GetComponent<SpriteRenderer>());
			}
		}
	}*/

	IEnumerator Out(SpriteRenderer S){
		while (!S.color.a.Equals(0.0f)) {
			S.color -= new Color (0.0f, 0.0f, 0.0f, 0.1f);
			yield return new WaitForSeconds (0.05f);
		}
	}
}
