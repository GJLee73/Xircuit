using UnityEngine;
using System.Collections;

public class Stage5Ex : MonoBehaviour {

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

	public GameObject R1;
	public GameObject G1;
	public GameObject B1;
	public GameObject plus11;
	public GameObject R11;
	public GameObject eq1;
	public GameObject eq2;
	public GameObject G12;
	public GameObject B12;
	public GameObject Not11;
	public GameObject Not12;
	
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
	
	private int num = 0;
	private bool alive = false;
	
	private Collider2D col2d;
	
	// Use this for initialization
	void Start () {
		background1.SetActive (false);
		background2.SetActive (false);
		color11 = circle11.GetComponent<SpriteRenderer> ().color;
		color12 = circle12.GetComponent<SpriteRenderer> ().color;
		color13 = circle13.GetComponent<SpriteRenderer> ().color;
		backcolor1 = background1.GetComponent<SpriteRenderer> ().color;
		
		color21 = circle21.GetComponent<SpriteRenderer> ().color;
		color22 = circle22.GetComponent<SpriteRenderer> ().color;
		color23 = circle23.GetComponent<SpriteRenderer> ().color;
		backcolor2 = background2.GetComponent<SpriteRenderer> ().color;
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
		if (col.gameObject.layer.Equals (10)) {
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

				R1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				G1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plus11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				R11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				yield return new WaitForFixedUpdate ();
				//yield return new WaitForSeconds (0.005f);
				
			}

			while (Not11.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				Not11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				Not12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (eq1.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				eq1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				eq2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (G12.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				G12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
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

				R1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				B1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plus11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				R11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				yield return new WaitForFixedUpdate ();
				//yield return new WaitForSeconds (0.005f);
				
			}

			while (Not12.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				Not12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				Not11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (eq1.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				eq1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				eq2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}
			
			yield return new WaitForSeconds (0.5f);
			
			while (B12.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				B12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				
				yield return new WaitForFixedUpdate ();
			}

			background2.GetComponent<BackG> ().canCancel = true;
		}
		
		//yield return new WaitForSeconds (2.0f);
		
		alive = true;
		col2d = col;
		
	}
	
	IEnumerator Cancel () {
		if (alive) {
			if (col2d.gameObject.layer.Equals (10)) {
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

					R1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plus11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					R11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
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

					R1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plus11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					R11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eq2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					Not12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
				}
				col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
			}
			background1.SetActive (false);
			background2.SetActive (false);
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

		R1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		R11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		background1.SetActive (false);
		background2.SetActive (false);
	}
	
	void Playing () {
		
	}
}
