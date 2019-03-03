using UnityEngine;
using System.Collections;

public class NeoBlock : MonoBehaviour {

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
	private static int[] _BlockNumber = new int[8];
	//private static int SortofBlock;
	public int[] Degree;
	private float[] Cosine = new float[8];
	private float[] Sine = new float[8];


	//public float qwe = 1.0f;
	//public float asd = 1.0f;

	public SpriteRenderer Blk;
	public GameObject bigOne;

	private int removeNum = 0;

	//public float WaveScaleV = 0.02f;
	//public float WaveAlphaV = 0.1f;
	public int CoreMAX = 10;
	private bool MPosCheck;
	public float radius;

	public AudioClip[] Pene = new AudioClip[3];
	public bool Tuto = false;
	public GameObject Finger;
	//public float FirstAlpha = 80/255f;
	public float AlphaV = 15 / 255f;
	//public float WaveStartSize = 1.6f;
	public float OpeningScale = 0.25f;
	public bool CustomScale = false;
	public float Speed = 4.0f;
	public bool isTesting = false;
	private bool isRemoved;
	private bool isWaved;

	void Awake () {
		_BlockNumber = BlockNumber;
		if (!CustomScale) {
			GetComponent<CircleCollider2D> ().radius = 4.0f;
		}
		if (Choosable) {
			bigOne.GetComponent<SpriteRenderer> ().sortingLayerName = "Ball";
		}
		//qwe = 2.4f;
		//asd = 1.6f;
		Tr = transform;
		//WaveStartSize = 2.0f;
		//FirstAlpha = 0.3137255f;
		//WaveScaleV = 0.03f;
		//WaveAlphaV = 0.05f;
		CoreMAX = 18;
		Tr.localScale= new Vector3 (0.5f, 0.5f, 1.0f);
		//bigOne.transform.localScale = new Vector3 (4.1f, 4.1f, 1.0f);
		OpeningScale = 0.3f;
		if (Choosable) {
			bigOne.transform.localScale = new Vector3 (4.1f, 4.1f, 1.0f);
			bigOne.SetActive (false);
			/*for (int i=0; i<8; i++) {
				Cosine [i] = Mathf.Cos (Mathf.Deg2Rad * Degree [i]);
				Sine [i] = Mathf.Sin (Mathf.Deg2Rad * Degree [i]);
				if(C[i]!=null){
					//Debug.Log (Degree[i]);
					CC[i] = C[i].GetComponent<ChoosingBlock> ();
					//C[i].rotation = Quaternion.Euler(0.0f, 0.0f,Degree[i]);
				}
		
				
			}*/
		}



		WaveS = Clone.GetComponent<SpriteRenderer> ();
		WaveT = Clone.transform;
		//WaveS2 = Clone2.GetComponent<SpriteRenderer> ();
		//WaveT2 = Clone2.transform;

		//CurrentNumber = 1;
		isClicked = false;
		X = 1.5f;

		//tag = "Blocking";
		Pos = transform.position;
		isEquipped = false;
		OutPos = Out.transform.position;
		//A = true;
		//B = true;
		Au = GetComponent<AudioSource> ();
		S = GetComponent<SpriteRenderer> ();
		S.sortingOrder = -1;
		A = true;
		Scale = 0.625f*Tr.localScale;
		//Length = Clones.Length;
		//E = true;
		//K = true;
		//isEquipped = false;
		isPlaying = false;
		//First = true;
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

	void MakeBigOne(){
		bigOne.SetActive (true);
	}


	void OnTriggerEnter2D(Collider2D other){
		//Ba.GetComponent<TrailRenderer>().

		if (isPlaying && other.CompareTag ("Ball") && !other.Equals (Ba)) {
			//other.GetComponent<SpriteRenderer>().enabled = false;
			OD = other.GetComponent<Ball> ().Direction;
			//ispenetrated = true;
			/*if (A) {
				if (isEquipped) {
					//StartCoroutine("WaveRepeat");
					Au.clip = Pene;
					Au.Play ();
					A = false;
		
				}
			}*/
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (Order < ConvergeNumber && isPlaying &&other.CompareTag ("Ball")&& !other.gameObject.Equals (Ba)) {
			other.GetComponent<Ball> ().Dead = true;
			other.GetComponent<Rigidbody2D> ().Sleep ();

			if(!other.GetComponent<Ball>().Checked){
				
				Order++;
				other.GetComponent<Ball>().Checked = true;
				Tag = (other.gameObject.layer - 8) ^ Tag;
				other.GetComponent<Rigidbody2D> ().Sleep ();
				if (Order.Equals (ConvergeNumber)) {
					ispenetrated = true;
					if(L&&isEquipped){

						for(int i =0; i<In.Length; i++){
							In[i].SendMessage("StopWave");
						}
						Au.clip = Pene[Random.Range(0,3)];
						Au.Play ();
						StartCoroutine(CoreWave(WaveS, WaveT, Pos, 2.0f*Scale.x, new Color(q,w,e,1.0f)));
						L = false;
						StartCoroutine("ChangeCoreColor");
						StartCoroutine ("Bal", Tag);
					}
				}

			}

		}

	}

	void RemoveBigone(){
		if (!isRemoved) {
			isRemoved = true;
			bigOne.SetActive (false);
		}
	}

	IEnumerator ChangeCoreColor(){
		while (S.color.a<255.0f) {
			S.color += new Color(0.0f, 0.0f, 0.0f, AlphaV); 
			yield return new WaitForSeconds(0.1f);
		}
	}

	void Playing(){
		isPlaying = true;
		BaSc.isPlaying = true;
		isWaved = false;
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
		if (!isWaved) {
			isWaved = true;
			T.position = Po;
			//T.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			T.gameObject.SetActive (true);
			S.color = Co;
			for (float i = 0; i < CoreMAX; i++) {
				T.localScale = SC * new Vector3 (1.0f + 0.03f * i, 1.0f + 0.03f * i, 0.0f); 
				S.color -= new Color (0.0f, 0.0f, 0.0f, 0.05f); 
				yield return new WaitForSeconds (0.06f);
			}
			T.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
			T.gameObject.SetActive (false);
			S.color += new Color (0.0f, 0.0f, 0.0f, 1.0f);
		}
	}
		

	void OnMouseDown(){
		if (Tuto) {
			Tuto = false;
			Finger.SendMessage ("Fade");
		}

		if (Choosable&&!(isEquipped&&ispenetrated)) {
			if (!isClicked) {
				isRemoved = false;
				isClicked = true;
				Open ();
				for(int k = 0; k<8; k++){
					//if(C[k]!=null){
						C [k].SendMessage ("Open");
						//Open (C[k], Cosine[k], Sine[k]);
					//}
				}
			} else if (isClicked) {
				isClicked = false;
				//bigOne.SetActive (false);
				for(int k = 0; k<8; k++){
					//if(C[k]!=null){
						C [k].SendMessage ("Close");
						//StartCoroutine (Close(8,C[k],Cosine[k], Sine[k]));
					//}
				}
			}
		}
	}

	void Cloose(int BC){
		//if (isClicked) {
		//Au.clip = Closing;
		//Au.Play();
		if (Order.Equals (ConvergeNumber)) {
			if (!BC.Equals (8)) {
				Au.clip = Pene[Random.Range(0,3)];
				Au.Play ();
			} 
		} 

		StartCoroutine ("removeBlk");
		if(!BC.Equals(8)){
			Close (BC, C [BC], Cosine [BC], Sine [BC]);
			C [BC].SendMessage ("Close");
		}
		for (int k = 0; k<8; k++) {
			if (C [k] != null && k != BC) {
				//StartCoroutine (Close (8, C [k], Cosine [k], Sine [k]));
				C[k].SendMessage("Close");
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

	void Close(int BC, Transform Ob, float Co, float Si){
		isClosing = true;
		isClicked = false;
		if (isEquipped&&!BC.Equals(8)) {
			BlockNumber[BlockColor]++;
			//C[BlockColor].SendMessage("Plus");
			C[BlockColor].SendMessage("ResetNumber");
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
				StartCoroutine(CoreWave(WaveS, WaveT, Pos, 2.0f*Scale.x, new Color(q,w,e,1.0f)));
			}
		}
		for(int i=0; i<8; i++){
			if(CC[i]!=null){
				CC[i].Enabled = false;
			}
		}
		//CurrentNumber = Number;
		//isClicked = false;
		/*StopCoroutine ("Open");
		int Count = 120/(int)Speed;
		while(Count>110/Speed){
			if (isTesting&&Co.Equals(Cosine[2])) {
				Debug.Log (C [2].transform.position.y);
				//Debug.Log(C[2].transform.localScale.y);
			}
			Count--;
			Ob.position -= OpeningScale*new Vector3 (Co*(0.0f*X + 0.001f*X*(Speed*Speed*(Count-120/Speed+1)+ (39-Speed)*Speed/2)), Si*(0.0f*X + 0.001f*X*(Speed*Speed*(Count-120/Speed+1)+ (39-Speed)*Speed/2)), 0.0f);

			Ob.localScale -= Speed*OpeningScale*10/7f* new Vector3 (0,0.0117f,0);

			yield return new WaitForSeconds (0.01f);
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count>100/Speed){
			if (isTesting&&Co.Equals(Cosine[2])) {
				Debug.Log (C [2].transform.position.y);
				//Debug.Log(C[2].transform.position.y);
			}
			Count--;

			Ob.localScale += Speed*OpeningScale*10/7f*new Vector3 (0,0.0117f,0);

			yield return new WaitForSeconds (0.01f);
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count>80/Speed){
			if (isTesting&&Co.Equals(Cosine[2])) {
				Debug.Log (C [2].transform.position.y);
				//Debug.Log(C[2].transform.localScale.y);
			}
			Count--;
			Ob.position += OpeningScale*new Vector3 (Co*(0.0f + 0.001f*X*(Speed*Speed*(Count-100/Speed+1)+(39-Speed)*Speed/2)), Si*(0.0f + 0.001f*X*(Speed*Speed*(Count-100/Speed+1)+(39-Speed)*Speed/2)), 0.0f);


			Ob.localScale += Speed*OpeningScale*10/7f*new Vector3 (0,0.0117f,0);


			yield return new WaitForSeconds (0.01f);
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count>40/Speed){
			if (isTesting&&Co.Equals(Cosine[2])) {
				Debug.Log (C [2].transform.position.y);
				//Debug.Log(C[2].transform.localScale.y);
			}
			Count--;

			Ob.localScale -= Speed*OpeningScale*10/7f*new Vector3 (0,0.0117f,0);


			yield return new WaitForSeconds (0.01f);
			//yield return new WaitForSeconds (0.003f);
		}

		while(Count>(0)){
			if (isTesting&&Co.Equals(Cosine[2])) {
				Debug.Log (C [2].transform.position.y);
				//Debug.Log(C[2].transform.localScale.y);
			}
			Count--;
			Ob.position -= OpeningScale*new Vector3 (Co*(Speed*0.2f*X - 0.005f*X*(Speed*Speed*(Count-40/Speed+1) + (79-Speed)*Speed/2)), Si*(Speed*0.2f*X - 0.005f*X*(Speed*Speed*(Count-40/Speed+1) + (79-Speed)*Speed/2)), 0.0f);

			Ob.localScale -= Speed*OpeningScale*10/7f*new Vector3 (0,0.0117f,0);

			yield return new WaitForSeconds (0.01f);

			//yield return new WaitForSeconds (0.003f);
		}
		if (isTesting&&Co.Equals(Cosine[2])) {
			Debug.Log (C [2].transform.position.y);
			//Debug.Log(C[2].transform.localScale.y);
		}

		bigOne.SetActive (false);*/
		

		if (Order.Equals (ConvergeNumber) && L&&isEquipped) {
			for(int i =0; i<In.Length; i++){
				In[i].SendMessage("StopWave");
			}
			L = false;
			StartCoroutine ("Bal", Tag);
		}
	
	
		//Ob.gameObject.SetActive (false);
		//Ob.SendMessage ("Hide");
		//isClosing = false;
	}

	//void Open(Transform Ob, float Co, float Si){
	void Open(){
		//Debug.Log ("Open");
		removeNum = 0;
		Blk.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		S.sprite = BlackDonut;
		S.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		//bigOne.SetActive (true);
		//Ob.SendMessage ("Show");
		//Ob.SendMessage ("ResetNumber");
		if (isEquipped) {
			isEquipped = false;
			AddBlock (BlockColor);
			//C[BlockColor].gameObject.SetActive(true);
			//C[BlockColor].SendMessage("Plus");
			C[BlockColor].SendMessage("ResetNumber");
			BlockColor = 8;
		}
		//isOpening = true;
		//StopCoroutine ("Close");
		//Ob.position = Pos;

		for (int i = 0; i<8; i++) {
			if(CC[i]!=null){
				CC[i].Enabled = true;
			}
		}
		bigOne.SetActive (true);
		//firstClk = true;
		//isOpening = false;
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
		S.color -= new Color (0.0f, 0.0f, 0.0f, 0.3137255f);
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

	public void AddBlock(int color){
		Debug.Log ("block Num increased");
		_BlockNumber [color]++;
		C [color].GetComponent<ChoosingBlock> ().ResetNumber ();
	}

	public void ReduceBlock(int color){
		Debug.Log ("block Num decreased");
		_BlockNumber [color]--;
		C [color].GetComponent<ChoosingBlock> ().ResetNumber ();
	}

	public static int GetBlockNum(int color){
		if (color < 0 || color > 7) {
			throw new UnityException ("invalid color number");
		}
		return _BlockNumber [color];
	}

	public static class CoroutineUtilities {
		public static IEnumerator WaitForRealTime(float delay){
			while(true){
				float pauseEndTime = Time.realtimeSinceStartup + delay;
				while (Time.realtimeSinceStartup < pauseEndTime){
					yield return 0;
				}
				break;
			}
		}
	}


}
