using UnityEngine;
using System.Collections;

public class Stage7Ex : MonoBehaviour {

	public GameObject R11;
	public GameObject G11;
	public GameObject B11;
	public GameObject plus11;
	public GameObject R12;
	public GameObject eq11;
	public GameObject eq12;
	public GameObject G13;
	public GameObject B13;
	public GameObject Not11;
	public GameObject Not12;

	public GameObject R21;
	public GameObject G21;
	public GameObject B21;
	public GameObject plus21;
	public GameObject R22;
	public GameObject G22;
	public GameObject B22;
	public GameObject eq21;
	public GameObject eq22;
	public GameObject G23;
	public GameObject B23;
	public GameObject Not21;
	public GameObject Not22;
	public GameObject Not23;
	public GameObject Not24;
	public GameObject Not25;

	public GameObject line11;
	public GameObject line12;
	public GameObject line13;
	public GameObject line14;
	public GameObject corner11;
	public GameObject corner12;
	public GameObject corner13;
	public GameObject corner14;
	public GameObject plus1;
	public GameObject equals11;
	public GameObject equals12;
	public GameObject circle11;
	public GameObject circle12;
	public GameObject circle13;
	public GameObject background1;
	
	private Color color11;
	private Color color12;
	private Color color13;
	private Color backcolor1;
	
	public GameObject line21;
	public GameObject line22;
	public GameObject line23;
	public GameObject line24;
	public GameObject corner21;
	public GameObject corner22;
	public GameObject corner23;
	public GameObject corner24;
	public GameObject plus2;
	public GameObject equals21;
	public GameObject equals22;
	public GameObject circle21;
	public GameObject circle22;
	public GameObject circle23;
	public GameObject background2;
	
	private Color color21;
	private Color color22;
	private Color color23;
	private Color backcolor2;

	public GameObject line31;
	public GameObject line32;
	public GameObject line33;
	public GameObject line34;
	public GameObject corner31;
	public GameObject corner32;
	public GameObject corner33;
	public GameObject corner34;
	public GameObject plus3;
	public GameObject equals31;
	public GameObject equals32;
	public GameObject circle31;
	public GameObject circle32;
	public GameObject circle33;
	public GameObject background3;
	
	private Color color31;
	private Color color32;
	private Color color33;
	private Color backcolor3;
	
	private int num = 0;
	private bool alive = false;
	
	private Collider2D col2d;
	
	// Use this for initialization
	void Start () {
		background1.SetActive (false);
		background2.SetActive (false);
		background3.SetActive (false);
		color11 = circle11.GetComponent<SpriteRenderer> ().color;
		color12 = circle12.GetComponent<SpriteRenderer> ().color;
		color13 = circle13.GetComponent<SpriteRenderer> ().color;
		backcolor1 = background1.GetComponent<SpriteRenderer> ().color;
		
		color21 = circle21.GetComponent<SpriteRenderer> ().color;
		color22 = circle22.GetComponent<SpriteRenderer> ().color;
		color23 = circle23.GetComponent<SpriteRenderer> ().color;
		backcolor2 = background2.GetComponent<SpriteRenderer> ().color;

		color31 = circle31.GetComponent<SpriteRenderer> ().color;
		color32 = circle32.GetComponent<SpriteRenderer> ().color;
		color33 = circle33.GetComponent<SpriteRenderer> ().color;
		backcolor3 = background3.GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Ball")) {
			col.gameObject.GetComponent <Rigidbody2D> ().Sleep();
			StartCoroutine("Explaining", col);
		}
	}
	
	IEnumerator Explaining (Collider2D col) {
		background1.SetActive (true);
		background2.SetActive (true);
		background3.SetActive (true);
		if (col.gameObject.layer.Equals (14)) {
			while (num != 510) {
				num++;
				line11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				line12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				line13.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				line14.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner13.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner14.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plus1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				equals11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				equals12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle13.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				background1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,35/130050f);

				R11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				G11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				B11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plus11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				R12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				yield return new WaitForFixedUpdate ();
				//yield return new WaitForSeconds (0.005f);
				
			}

			while (Not11.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				Not11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				Not12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (eq11.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				eq11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				eq12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (G13.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				G13.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				B13.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}

			background1.GetComponent<BackG> ().canCancel = true;
		}
		
		else if (col.gameObject.layer.Equals (12)) {
			while (num != 510) {
				num++;
				line21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				line22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				line23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				line24.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner24.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plus2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				equals21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				equals22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				background2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,35/130050f);

				R21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				G21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				B21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plus21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				R22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				G22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				yield return new WaitForFixedUpdate ();
				//yield return new WaitForSeconds (0.005f);
				
			}

			while (Not21.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				Not21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				Not22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				Not24.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				Not25.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (eq21.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				eq21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				eq22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (B23.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				B23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}

			background2.GetComponent<BackG> ().canCancel = true;
		}

		else if (col.gameObject.layer.Equals (10)) {
			while (num != 510) {
				num++;
				line31.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				line32.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				line33.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				line34.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner31.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner32.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner33.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				corner34.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plus3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				equals31.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				equals32.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle31.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle32.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle33.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				background3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,35/130050f);

				R21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				G21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				B21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plus21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				R22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				B22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				yield return new WaitForFixedUpdate ();
				//yield return new WaitForSeconds (0.005f);
				
			}

			while (Not21.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				Not21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				Not23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				Not24.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				Not25.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (eq21.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				eq21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				eq22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (G23.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				G23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}

			background3.GetComponent<BackG> ().canCancel = true;
		}
		
		//yield return new WaitForSeconds (2.0f);
		
		alive = true;
		col2d = col;
		
	}
	
	IEnumerator Cancel () {
		if (alive) {
			if (col2d.gameObject.layer.Equals (14)) {
				background1.GetComponent<BackG> ().canCancel = false;
				while (num != 0) {
					num--;
					line11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					line12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					line13.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					line14.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner13.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner14.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plus1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					equals11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					equals12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle13.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					background1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,35/130050f);

					R11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plus11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					R12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G13.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B13.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
				}
				col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
			}
			
			else if (col2d.gameObject.layer.Equals (12)) {
				background2.GetComponent<BackG> ().canCancel = false;
				while (num != 0) {
					num--;
					line21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					line22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					line23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					line24.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner24.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plus2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					equals21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					equals22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					background2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,35/130050f);

					R21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plus21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					R22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not24.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not25.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
				}
				col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
			}

			else if (col2d.gameObject.layer.Equals (10)) {
				background3.GetComponent<BackG> ().canCancel = false;
				while (num != 0) {
					num--;
					line31.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					line32.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					line33.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					line34.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner31.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner32.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner33.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					corner34.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plus3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					equals31.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					equals32.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle31.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle32.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle33.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					background3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,35/130050f);

					R21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plus21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					R22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not24.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not25.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
				}
				col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
			}
			background1.SetActive (false);
			background2.SetActive (false);
			background3.SetActive (false);
			alive = false;
		}
	}
	
	IEnumerator Reset () {
		
		StopCoroutine ("Explaining");
		StopCoroutine ("Cancel");
		
		yield return new WaitForSeconds (0.1f);
		
		num = 0;
		alive = false;
		background1.GetComponent<BackG> ().canCancel = false;
		background2.GetComponent<BackG> ().canCancel = false;
		
		line11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line13.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line14.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner13.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner14.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus1.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);   // 원래부터 검은색 
		equals11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		equals12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		circle11.GetComponent<SpriteRenderer> ().color = color11;
		circle12.GetComponent<SpriteRenderer> ().color = color12;
		circle13.GetComponent<SpriteRenderer> ().color = color13;
		background1.GetComponent<SpriteRenderer> ().color = backcolor1;
		
		line21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line23.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line24.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner23.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner24.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus2.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);   // 원래부터 검은색 
		equals21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		equals22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		circle21.GetComponent<SpriteRenderer> ().color = color21;
		circle22.GetComponent<SpriteRenderer> ().color = color22;
		circle23.GetComponent<SpriteRenderer> ().color = color23;
		background2.GetComponent<SpriteRenderer> ().color = backcolor2;

		line31.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line32.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line33.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line34.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner31.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner32.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner33.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner34.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus3.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);   // 원래부터 검은색 
		equals31.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		equals32.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		circle31.GetComponent<SpriteRenderer> ().color = color31;
		circle32.GetComponent<SpriteRenderer> ().color = color32;
		circle33.GetComponent<SpriteRenderer> ().color = color33;
		background3.GetComponent<SpriteRenderer> ().color = backcolor3;

		R11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		R12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B13.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G13.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		R21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		R22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not23.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not24.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not25.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B23.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G23.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		background1.SetActive (false);
		background2.SetActive (false);
		background3.SetActive (false);
		
	}
	
	void Playing () {
		
	}
}
