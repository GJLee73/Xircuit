using UnityEngine;
using System.Collections;

public class NeoBlockNeo : MonoBehaviour {

	private bool isPlaying = false;

	public int BlockColor;

	public GameObject Ba;
	private TrailRenderer Tra;
	private Rigidbody2D rb;
	public int OutDirection;
	private Transform Btr;
	private Transform Tr;
	private Ball BaSc;
	private int Order;
	public int ConvergeNumber;
	private int Tag;
	private bool L;
	private int OD;
	private int a;
	public GameObject Clone;
	private int Length;
	Vector3 Scale;
	private float q,w,e;
	private bool A;

	private SpriteRenderer S;
	private AudioSource Au;
	public GameObject Out;
	public GameObject[] In;
	private Vector3 OutPos;
	private bool isEquipped;
	private bool ispenetrated;
	private bool isClicked;
	private Vector3 Pos;
	//private int Count;
	//private int CurrentNumber;
	public bool Choosable;
	public Transform[] C;
	private ChoosingBlock[] CC = new ChoosingBlock[8];
	private float X;
	private SpriteRenderer WaveS;
	private Transform WaveT;
	public float V = 1.0f;
	private bool isOpening;
	private bool isClosing;
	public Sprite WhiteCircle, BlackDonut;
	public int[] BlockNumber;
	private static int[] BN = new int[8];
	//private static int SortofBlock;
	public int[] Degree;
	private float[] Cosine = new float[8];
	private float[] Sine = new float[8];


	public float qwe = 1.0f;
	public float asd = 1.0f;

	public SpriteRenderer Blk;
	public GameObject bigOne;

	private int removeNum = 0;

	public float CoreScaleV = 0.02f;
	public float CoreAlphaV = 0.1f;
	public int CoreMAX = 10;
	private bool MPosCheck;
	public float radius;

	public AudioClip Opening, Closing, Pene;


	void Awake () {

		if (Choosable) {
			bigOne.SetActive (false);
			for (int i=0; i<8; i++) {
				Cosine [i] = Mathf.Cos (Mathf.Deg2Rad * Degree [i]);
				Sine [i] = Mathf.Sin (Mathf.Deg2Rad * Degree [i]);
				if(C[i]!=null){
					//Debug.Log (Degree[i]);
					CC[i] = C[i].GetComponent<ChoosingBlock> ();
					C[i].rotation = Quaternion.Euler(0.0f, 0.0f,Degree[i]);
				}


			}
		}



		WaveS = Clone.GetComponent<SpriteRenderer> ();
		WaveT = Clone.transform;
	
		isClicked = false;
		X = 1.5f;

		//tag = "Blocking";
		Pos = transform.position;
		isEquipped = false;
		OutPos = Out.transform.position;
	
		Au = GetComponent<AudioSource> ();
		S = GetComponent<SpriteRenderer> ();
		A = true;
		Scale = 0.625f*transform.localScale;
	
		isPlaying = false;

		Tra = Ba.GetComponent<TrailRenderer> ();
		rb = Ba.GetComponent<Rigidbody2D> ();
		Btr = Ba.transform;
		Tr = transform;
		BaSc = Ba.GetComponent<Ball> ();
		//StartCoroutine ("Updat");
		Tra.time = 0.1f;
		Order = 0;

		Tag = 0;
		if (!Choosable) {
			isEquipped = true;
			S.sprite = WhiteCircle;
			ChangeColor(BlockColor);
		}
		ChangeWaveColor ();
		MPosCheck = (Input.mousePosition.x > Pos.x + radius|| Input.mousePosition.x < Pos.x - radius);
	}

	// Update is called once per frame



	void OnTriggerEnter2D(Collider2D other){
		//Ba.GetComponent<TrailRenderer>().
		//Debug.Log ("Enter");
		if (isPlaying && other.CompareTag ("Ball") && !other.Equals (Ba)) {
			//other.GetComponent<SpriteRenderer>().enabled = false;
			OD = other.GetComponent<Ball> ().Direction;
			ispenetrated = true;
			if (A) {
				if (isEquipped) {
					//StartCoroutine("WaveRepeat");
					Au.clip = Pene;
					Au.Play ();
					A = false;

				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		//Debug.Log ("VV");
		if (Order < ConvergeNumber && isPlaying &&other.CompareTag ("Ball")&& !other.gameObject.Equals (Ba)) {
			other.GetComponent<Ball> ().Dead = true;
			other.GetComponent<Rigidbody2D> ().Sleep ();

			if(!other.GetComponent<Ball>().Checked){

				Order++;
				other.GetComponent<Ball>().Checked = true;
				Tag = (other.gameObject.layer - 8) ^ Tag;
				other.GetComponent<Rigidbody2D> ().Sleep ();
				if (Order.Equals (ConvergeNumber)) {
					if(L&&isEquipped){
						for(int i =0; i<In.Length; i++){
							In[i].SendMessage("StopWave");
						}
						StartCoroutine(CoreWave(WaveS, WaveT, Pos, 1.25f*Scale.x, new Color(q,w,e,1.0f)));
						L = false;
						StartCoroutine("ChangeCoreColor");
						StartCoroutine ("Bal", Tag);
					}
				}

			}

		}

	}

	IEnumerator ChangeCoreColor(){
		while (S.color.a<255.0f) {
			S.color += new Color(0.0f, 0.0f, 0.0f, 15/255f); 
			yield return new WaitForSeconds(0.1f);
		}
	}

	void Playing(){
		isPlaying = true;
		BaSc.isPlaying = true;

	}

	void Reset(){

		ispenetrated = false;
		StopCoroutine ("WaveRepeat");
		StopCoroutine ("ChangeCoreColor");
		A = true;
		L = true;
		isPlaying = false;
		if (isEquipped) {
			ChangeColor(BlockColor);
			//S.color -= new Color(0.0f, 0.0f, 0.0f, 150/255f);
		}
		//E = true;
		//K = true;
		//First = true;
		//isPenetrated = false;
		//A = false;
		//B = true;
		Btr.position = OutPos;
		Ba.SetActive(false);
		Tra.time = 0.1f;
		Order = 0;
		Tag = 0;
	}

	IEnumerator CoreWave(SpriteRenderer S, Transform T, Vector3 Po, float SC, Color Co){
		T.position = Po;
		//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		T.gameObject.SetActive (true);
		S.color = Co;
		for (float i=0; i<CoreMAX; i++) {
			T.localScale = SC*new Vector3(1.0f+CoreScaleV*i,1.0f+CoreScaleV*i, 0.0f); 
			S.color -= new Color(0.0f, 0.0f, 0.0f, CoreAlphaV); 
			yield return new WaitForSeconds(0.06f);
		}
		T.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		T.gameObject.SetActive (false);
		S.color += new Color(0.0f, 0.0f, 0.0f, 1.0f);
	}


	void OnMouseDown(){
		if (Choosable&&!(isEquipped&&ispenetrated)) {
			if (!isClicked&&!isClosing) {
				isClicked = true;
				Au.clip = Opening;
				Au.Play();
				for(int k = 0; k<8; k++){
					if(C[k]!=null){
						StartCoroutine(Open (C[k], Cosine[k], Sine[k]));
					}
				}
			} else if (isClicked&&!isOpening) {
				isClicked = false;
				Au.clip = Closing;
				Au.Play();
				for(int k = 0; k<8; k++){
					if(C[k]!=null){
						StartCoroutine (Close(8,C[k],Cosine[k], Sine[k]));
					}
				}
			}
		}
	}

	void Cloose(int BC){
		//if (isClicked) {
		Au.clip = Closing;
		Au.Play();
		StartCoroutine ("removeBlk");
		if(!BC.Equals(8)){
			StartCoroutine (Close (BC, C [BC], Cosine [BC], Sine [BC]));
		}
		for (int k = 0; k<8; k++) {
			if (C [k] != null && k != BC) {
				StartCoroutine (Close (8, C [k], Cosine [k], Sine [k]));
			}
		}
		//}
	}

	IEnumerator TouchPositionCheck(){
		while (isClicked) {

			Vector2 MPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//Debug.Log (Pos.x + radius +" "+ MPos.x);

			if(Input.GetMouseButton(0)&&((MPos.x>Pos.x + radius)||(MPos.x<Pos.x - radius)||(MPos.y> Pos.y + radius)||(MPos.y<Pos.y-radius))){
				isClicked = false;
				StartCoroutine("Cloose", 8);
			}
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator Close(int BC, Transform Ob, float Co, float Si){
		isClosing = true;
		isClicked = false;
		if (isEquipped&&!BC.Equals(8)) {
			BlockNumber[BlockColor]++;
			C[BlockColor].SendMessage("Plus");
		}

		if (!BC.Equals (8)) {
			BlockColor = BC;
			BlockNumber[BC]--;
			isEquipped = true;
			ChangeWaveColor();
			S.sprite = WhiteCircle;
			ChangeColor(BC);
			if(ispenetrated){
				StartCoroutine("ChangeCoreColor");
				StartCoroutine(CoreWave(WaveS, WaveT, Pos,1.6f*Scale.x, new Color(q,w,e,1.0f)));
			}
		}
		for(int i=0; i<8; i++){
			if(CC[i]!=null){
				CC[i].Enabled = false;
			}
		}
		//CurrentNumber = Number;
		//isClicked = false;
		StopCoroutine ("Open");
		int Count = 120;
		while(Count>110){
			Count--;
			Ob.position -= Scale.x*new Vector3 (Co*(0.0f*X + 0.001f*X*(Count-110)), Si*(0.0f*X + 0.001f*X*(Count-110)), 0.0f);

			Ob.localScale -= Scale.x*10/7f* new Vector3 (0,0.0117f,0);

			yield return new WaitForFixedUpdate();
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count>100){
			Count--;

			Ob.localScale += Scale.x*10/7f*new Vector3 (0,0.0117f,0);

			yield return new WaitForFixedUpdate();
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count>80){
			Count--;
			Ob.position += Scale.x*new Vector3 (Co*(0.0f*X + 0.001f*X*(Count-80)), Si*(0.0f*X + 0.001f*X*(Count-80)), 0.0f);


			Ob.localScale += Scale.x*10/7f*new Vector3 (0,0.0117f,0);


			yield return new WaitForFixedUpdate();
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count>40){
			Count--;

			Ob.localScale -= Scale.x*10/7f*new Vector3 (0,0.0117f,0);


			yield return new WaitForFixedUpdate();
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count>(0)){
			Count--;
			Ob.position -= Scale.x*new Vector3 (Co*(0.2f*X - 0.005f*X*Count), Si*(0.2f*X - 0.005f*X*Count), 0.0f);

			Ob.localScale -= Scale.x*10/7f*new Vector3 (0,0.0117f,0);

			yield return new WaitForFixedUpdate();

			//yield return new WaitForSeconds (0.003f);
		}

		bigOne.SetActive (false);

		/*while (!Count.Equals(0)) {
			Count--;
			StartT.position -= Scale*new Vector3 (0.1f*X, 0.0f, 0.0f);
			ResetT.position -= Scale*new Vector3 (0.05f*X, 0.0866f*X, 0.0f);
			FFT.position -= Scale*new Vector3 (0.05f*X, -0.0866f*X, 0.0f);
			yield return new WaitForFixedUpdate();
		}*/



		if (Order.Equals (ConvergeNumber) && L&&isEquipped) {
			for(int i =0; i<In.Length; i++){
				In[i].SendMessage("StopWave");
			}
			L = false;
			StartCoroutine ("Bal", Tag);
		}


		//Ob.gameObject.SetActive (false);
		Ob.SendMessage ("Hide");
		isClosing = false;
	}

	IEnumerator Open(Transform Ob, float Co, float Si){
		removeNum = 0;
		Blk.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		S.sprite = BlackDonut;
		S.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		bigOne.SetActive (true);
		Ob.SendMessage ("Show");
		Ob.SendMessage ("ResetNumber");
		if (isEquipped) {
			isEquipped = false;
			C[BlockColor].gameObject.SetActive(true);
			C[BlockColor].SendMessage("Plus");
			BlockColor = 8;
		}
		isOpening = true;
		StopCoroutine ("Close");
		Ob.position = Pos;
		Ob.localScale = asd* new Vector3 (0.25f,0.0f,1.0f);
		int Count = 0;
		while(Count<40){
			Count++;
			Ob.position += qwe*Scale.x*new Vector3 (Co*(0.2f*X - 0.005f*X*Count),Si*(0.2f*X - 0.005f*X*Count), 0.0f);
			Ob.localScale += asd*Scale.x*10/7f* new Vector3 (0,0.0117f,0);


			yield return new WaitForFixedUpdate();
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count<80&&Count>39){
			Count++;

			Ob.localScale += asd*Scale.x*10/7f*new Vector3 (0,0.0117f,0);

			yield return new WaitForFixedUpdate();
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count<100&&Count>79){
			Count++;
			Ob.position -= qwe*Scale.x*new Vector3 (Co*(0.0f*X + 0.001f*X*(Count-80)), Si* (0.0f*X + 0.001f*X*(Count-80)), 0.0f);


			Ob.localScale -= asd*Scale.x*10/7f*new Vector3 (0,0.0117f,0);


			yield return new WaitForFixedUpdate();
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count<110&&Count>99){
			Count++;

			Ob.localScale -= asd*Scale.x*10/7f*new Vector3 (0,0.0117f,0);


			yield return new WaitForFixedUpdate();
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count<120&&Count>109){
			Count++;
			Ob.position += qwe*Scale.x*new Vector3 (Co*(0.0f*X + 0.001f*X*(Count-110)),Si*(0.0f*X + 0.001f*X*(Count-110)), 0.0f);


			Ob.localScale += asd*Scale.x*10/7f*new Vector3 (0,0.0117f,0);


			yield return new WaitForFixedUpdate();

			//yield return new WaitForSeconds (0.003f);
		}
		Ob.position -= new Vector3 (0.0f, 0.0f, 2.0f);
		for (int i = 0; i<8; i++) {
			if(CC[i]!=null){
				CC[i].Enabled = true;
			}
		}
		//firstClk = true;
		isOpening = false;
		StartCoroutine ("TouchPositionCheck");
	}

	void ChangeColor(int C){
		if (C.Equals (0)) {
			S.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
		}
		if (C.Equals (1)) {
			S.color = new Color(230/255f, 0.0f, 18/255f, 1.0f);
		}
		if (C.Equals (2)) {
			S.color = new Color(0.0f, 153/255f, 68/255f, 1.0f);
		}
		if (C.Equals (3)) {
			S.color = new Color(249/255f, 230/255f, 47/255f, 1.0f);
		}
		if (C.Equals (4)) {
			S.color = new Color(0.0f, 71/255f, 157/255f, 1.0f);
		}
		if (C.Equals (5)) {
			S.color = new Color(228/255f, 0.0f, 180/255f, 1.0f);
		}
		if (C.Equals (6)) {
			S.color = new Color(0.0f, 160/255f, 233/255f, 1.0f);
		}
		if (C.Equals (7)) {
			S.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
		S.color -= new Color (0.0f, 0.0f, 0.0f, 80 / 255f);
	}

	void ChangeWaveColor(){
		if (BlockColor.Equals (0)) {
			q = 0;
			w = 0;
			e = 0;
		}

		if (BlockColor.Equals (1)) {
			q = 230/255f;
			w = 0;
			e = 18/255f;	
		}
		if (BlockColor.Equals (2)) {
			q = 0;
			w = 153/255f;
			e = 68/255f;
		}
		if (BlockColor.Equals (3)) {
			q = 249/255f;
			w = 230/255f;
			e = 47/255f;
		}

		if (BlockColor.Equals (4)) {
			q = 0;
			w = 71/255f;
			e = 157/255f;
		}

		if (BlockColor.Equals (5)) {
			q = 228/255f;
			w = 0;
			e = 180/255f;
		}
		if (BlockColor.Equals (6)) {
			q = 0;
			w =	160/255f;
			e = 233/255f;
		}
		if (BlockColor.Equals (7)) {
			q = 1;
			w = 1;
			e = 1;
		}
	}

	IEnumerator Bal(int T){

		Ba.layer =  Tag^ BlockColor + 8;

		Ba.SetActive (true);
		if (OutDirection.Equals (0)) {

			BaSc.Direction = OD;
			OutDirection = OD;
		}
		Tra.time = 0.0f;
		Btr.position = OutPos;
		yield return new WaitForSeconds (0.1f);

		Tra.time = Mathf.Infinity;
		rb.Sleep ();

		if (OutDirection.Equals (1)) {
			Btr.position = OutPos;
			rb.AddForce (V * new Vector2 (200.0f, 0.0f));
			//Btr.position = Tr.position;
		} else if (OutDirection.Equals (2)) {
			Btr.position = OutPos;
			rb.AddForce (V * new Vector2 (0.0f, 200.0f));
			//Btr.position = Tr.position;
		} else if (OutDirection.Equals (3)) {
			rb.AddForce (V * new Vector2 (-200.0f, 0.0f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (4)) {
			rb.AddForce (V * new Vector2 (0.0f, -200.0f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (5)) {
			rb.AddForce (V * new Vector2 (141.42f, 141.42f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (6)) {
			rb.AddForce (V * new Vector2 (-141.42f, 141.42f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (7)) {
			rb.AddForce (V * new Vector2 (-141.42f, -141.42f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (8)) {
			rb.AddForce (V * new Vector2 (141.42f, -141.42f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (9)) {
			rb.AddForce(V*new Vector2(178.9869f, 89.24f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (10)) {
			rb.AddForce(V*new Vector2(-178.9869f, 89.24f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (11)) {
			rb.AddForce(V*new Vector2(-178.9869f, -89.24f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (12)) {
			rb.AddForce(V*new Vector2(178.9869f, -89.24f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (13)) {
			rb.AddForce(V*new Vector2(89.24f, 178.9869f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (14)) {
			rb.AddForce(V*new Vector2(-89.24f, 178.9869f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (15)) {
			rb.AddForce(V*new Vector2(-89.24f, -178.9869f));
			Btr.position = OutPos;
		} else if (OutDirection.Equals (16)) {
			rb.AddForce(V*new Vector2(89.24f, -178.9869f));
			Btr.position = OutPos;
		}
		if (!OutDirection.Equals (0)) {
			//Ba.transform.position = transform.position;
			BaSc.Direction = OutDirection;
		}
	}

	IEnumerator removeBlk () {
		//Debug.Log ("Start");

		//if (firstClk) {
		//firstClk = false;
		while(removeNum<100) {
			removeNum++;
			Blk.color -= new Color (0.0f,0.0f,0.0f,0.01f);
			yield return new WaitForFixedUpdate ();
		}
		//}
	}

}
