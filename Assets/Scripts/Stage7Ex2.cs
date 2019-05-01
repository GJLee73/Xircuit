using UnityEngine;
using System.Collections;

public class Stage7Ex2 : MonoBehaviour {
	
	public GameObject G21;
	public GameObject B21;
	public GameObject plus21;
	public GameObject R22;
	public GameObject G22;
	public GameObject B22;
	public GameObject eq21;
	public GameObject eq22;
	public GameObject R23;
	public GameObject G23;
	public GameObject B23;
	public GameObject Not21;
	public GameObject Not22;
	public GameObject Not23;

	public GameObject G11;
	public GameObject B11;
	public GameObject plus11;
	public GameObject R12;
	public GameObject G12;
	public GameObject B12;
	public GameObject eq11;
	public GameObject eq12;
	public GameObject R13;
	public GameObject Not11;
	public GameObject Not12;

	public GameObject line1;
	public GameObject line2;
	public GameObject line3;
	public GameObject line4;
	public GameObject corner1;
	public GameObject corner2;
	public GameObject corner3;
	public GameObject corner4;
	public GameObject plus;
	public GameObject equals1;
	public GameObject equals2;
	public GameObject background;

	private Color backcolor;

	public GameObject circle11;
	public GameObject circle12;
	public GameObject circle13;

	private Color color11;
	private Color color12;
	private Color color13;

	public GameObject circle21;
	public GameObject circle22;
	public GameObject circle23;

	private Color color21;
	private Color color22;
	private Color color23;

	public GameObject circle31;
	public GameObject circle32;
	public GameObject circle33;

	private Color color31;
	private Color color32;
	private Color color33;

	public GameObject circle41;
	public GameObject circle42;
	public GameObject circle43;

	private Color color41;
	private Color color42;
	private Color color43;

	private int num = 0;
	private bool alive = false;
	private Collider2D col2d;

	public GameObject Test;


	// Use this for initialization
	void Start () {
		background.SetActive (false);
		backcolor = background.GetComponent<SpriteRenderer> ().color;

		color11 = circle11.GetComponent<SpriteRenderer> ().color;
		color12 = circle12.GetComponent<SpriteRenderer> ().color;
		color13 = circle13.GetComponent<SpriteRenderer> ().color;
		
		color21 = circle21.GetComponent<SpriteRenderer> ().color;
		color22 = circle22.GetComponent<SpriteRenderer> ().color;
		color23 = circle23.GetComponent<SpriteRenderer> ().color;
		
		color31 = circle31.GetComponent<SpriteRenderer> ().color;
		color32 = circle32.GetComponent<SpriteRenderer> ().color;
		color33 = circle33.GetComponent<SpriteRenderer> ().color;

		color41 = circle41.GetComponent<SpriteRenderer> ().color;
		color42 = circle42.GetComponent<SpriteRenderer> ().color;
		color43 = circle43.GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Ball")) {
			col.gameObject.GetComponent <Rigidbody2D> ().Sleep();
			StartCoroutine("Explaining", col);
		}
	}
	
	IEnumerator Explaining (Collider2D col) {
		background.SetActive (true);
		if (Test.GetComponent<Stage7Test> ().num.Equals (14)) {

			if (col.gameObject.layer.Equals(13)) {
				while (num != 510) {
					num++;
					line1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					plus.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					equals1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					equals2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					background.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,35/130050f);

					circle11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					circle12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					circle13.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

					G21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					B21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					R22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					plus21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					G22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
					
				}

				while (Not21.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					Not21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					Not23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}
				
				yield return new WaitForSeconds (0.5f);
				
				while (eq21.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					eq21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					eq22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}
				
				yield return new WaitForSeconds (0.5f);
				
				while (R23.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					R23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					B23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}

				background.GetComponent<BackG> ().canCancel = true;
			}

			else if (col.gameObject.layer.Equals(11)) {
				while (num != 510) {
					num++;
					line1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					plus.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					equals1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					equals2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					background.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,35/130050f);
					
					circle21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					circle22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					circle23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

					G21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					B21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					R22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					plus21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					B22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
					
				}

				while (Not22.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					Not22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					Not23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}
				
				yield return new WaitForSeconds (0.5f);
				
				while (eq21.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					eq21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					eq22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}
				
				yield return new WaitForSeconds (0.5f);
				
				while (R23.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					R23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					G23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}

				background.GetComponent<BackG> ().canCancel = true;
			}
		}

		else if (Test.GetComponent<Stage7Test> ().num.Equals (12)) {
			if (col.gameObject.layer.Equals(9)) {
				while (num != 510) {
					num++;
					line1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					plus.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					equals1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					equals2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					background.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,35/130050f);
					
					circle31.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					circle32.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					circle33.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

					B11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					R12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					B12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					plus11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
					
				}

				while (Not12.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					Not12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					Not11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}
				
				yield return new WaitForSeconds (0.5f);
				
				while (eq11.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					eq11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					eq12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}
				
				yield return new WaitForSeconds (0.5f);
				
				while (R13.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					R13.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}

				background.GetComponent<BackG> ().canCancel = true;
			}

			else col.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
		}

		else if (Test.GetComponent<Stage7Test> ().num.Equals (10)) {
			if (col.gameObject.layer.Equals(9)) {
				while (num != 510) {
					num++;
					line1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					line4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner3.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					corner4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					plus.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					equals1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					equals2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					background.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,35/130050f);
					
					circle41.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					circle42.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					circle43.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

					G11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					R12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					G12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
					plus11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
					
				}

				while (Not12.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					Not12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					Not11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}
				
				yield return new WaitForSeconds (0.5f);
				
				while (eq11.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					eq11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					eq12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}
				
				yield return new WaitForSeconds (0.5f);
				
				while (R13.GetComponent<SpriteRenderer>().color.a != 1.0f) {
					R13.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
					
					yield return new WaitForFixedUpdate ();
				}

				background.GetComponent<BackG> ().canCancel = true;
			}

			else col.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
		}

		//yield return new WaitForSeconds (2.0f);
		
		alive = true;
		col2d = col;
		
	}
	
	IEnumerator Cancel () {
		if (alive) {

			if (Test.GetComponent<Stage7Test> ().num.Equals (14)) {
				
				if (col2d.gameObject.layer.Equals(13)) {
					background.GetComponent<BackG> ().canCancel = false;
					while (num != 0) {
						num--;
						line1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						plus.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						equals1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						equals2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						background.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,35/130050f);
						
						circle11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						circle12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						circle13.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

						G21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						B21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						R22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						plus21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						G22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						eq21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						eq22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						R23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						B23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						Not21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						Not23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

						yield return new WaitForFixedUpdate ();
						//yield return new WaitForSeconds (0.005f);
						
					}
					col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
				}
				
				else if (col2d.gameObject.layer.Equals(11)) {
					background.GetComponent<BackG> ().canCancel = false;
					while (num != 0) {
						num--;
						line1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						plus.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						equals1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						equals2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						background.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,35/130050f);
						
						circle21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						circle22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						circle23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

						G21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						B21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						R22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						plus21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						B22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						eq21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						eq22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						R23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						G23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						Not22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						Not23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

						yield return new WaitForFixedUpdate ();
						//yield return new WaitForSeconds (0.005f);
						
					}
					col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
				}
			}
			
			if (Test.GetComponent<Stage7Test> ().num.Equals (12)) {
				if (col2d.gameObject.layer.Equals(9)) {
					background.GetComponent<BackG> ().canCancel = false;
					while (num != 0) {
						num--;
						line1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						plus.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						equals1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						equals2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						background.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,35/130050f);
						
						circle31.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						circle32.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						circle33.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

						B11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						B12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						R12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						plus11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						eq11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						eq12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						R13.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						Not11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						Not12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

						yield return new WaitForFixedUpdate ();
						//yield return new WaitForSeconds (0.005f);
						
					}
					col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
				}
			}
			
			if (Test.GetComponent<Stage7Test> ().num.Equals (10)) {
				if (col2d.gameObject.layer.Equals(9)) {
					background.GetComponent<BackG> ().canCancel = false;
					while (num != 0) {
						num--;
						line1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						line4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner3.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						corner4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						plus.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						equals1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						equals2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						background.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,35/130050f);
						
						circle41.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						circle42.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						circle43.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

						G11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						G12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						R12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						plus11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						eq11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						eq12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						R13.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						Not11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
						Not12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

						yield return new WaitForFixedUpdate ();
						//yield return new WaitForSeconds (0.005f);
						
					}
					col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
				}
			}
			background.SetActive (false);
			alive = false;
		}
	}
	
	IEnumerator Reset () {
		
		StopCoroutine ("Explaining");
		StopCoroutine ("Cancel");
		
		yield return new WaitForSeconds (0.1f);
		
		num = 0;
		alive = false;
		background.GetComponent<BackG> ().canCancel = false;
		Test.GetComponent<Stage7Test> ().num = 0;
		
		line1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line3.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line4.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner3.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner4.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);   // 원래부터 검은색 
		equals1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		equals2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		background.GetComponent<SpriteRenderer> ().color = backcolor;

		circle11.GetComponent<SpriteRenderer> ().color = color11;
		circle12.GetComponent<SpriteRenderer> ().color = color12;
		circle13.GetComponent<SpriteRenderer> ().color = color13;

		circle21.GetComponent<SpriteRenderer> ().color = color21;
		circle22.GetComponent<SpriteRenderer> ().color = color22;
		circle23.GetComponent<SpriteRenderer> ().color = color23;

		circle31.GetComponent<SpriteRenderer> ().color = color31;
		circle32.GetComponent<SpriteRenderer> ().color = color32;
		circle33.GetComponent<SpriteRenderer> ().color = color33;

		circle41.GetComponent<SpriteRenderer> ().color = color41;
		circle42.GetComponent<SpriteRenderer> ().color = color42;
		circle43.GetComponent<SpriteRenderer> ().color = color43;

		G21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		R22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not23.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		R23.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B23.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G23.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq21.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq22.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		G11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		R12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Not12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		R13.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq11.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eq12.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		background.SetActive (false);
	}
	
	void Playing () {
		
	}
}
