using UnityEngine;
using System.Collections;

public class ST1Explain1 : MonoBehaviour {

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

	public GameObject R1;
	public GameObject G1;
	public GameObject plusA1;
	public GameObject G2;
	public GameObject B2;
	public GameObject eqA1;
	public GameObject eqA2;
	public GameObject R4;
	public GameObject G4;
	public GameObject G5;
	public GameObject B5;

	private int num = 0;
	private bool alive = false;

	private Collider2D col2d;

	public GameObject explain2;

	// Use this for initialization
	void Start () {
		background.SetActive (false);

		color11 = circle11.GetComponent<SpriteRenderer> ().color;
		color12 = circle12.GetComponent<SpriteRenderer> ().color;
		color13 = circle13.GetComponent<SpriteRenderer> ().color;

		color21 = circle21.GetComponent<SpriteRenderer> ().color;
		color22 = circle22.GetComponent<SpriteRenderer> ().color;
		color23 = circle23.GetComponent<SpriteRenderer> ().color;

		color31 = circle31.GetComponent<SpriteRenderer> ().color;
		color32 = circle32.GetComponent<SpriteRenderer> ().color;
		color33 = circle33.GetComponent<SpriteRenderer> ().color;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Ball")) {
			col.gameObject.GetComponent <Rigidbody2D> ().Sleep();
			StartCoroutine("Explaining", col);
		}
	}

	IEnumerator Explaining (Collider2D col) {
		background.SetActive (true);

		if (col.gameObject.layer.Equals (11)) {
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

				circle11.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle12.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle13.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				R1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plusA1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				G2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				yield return new WaitForFixedUpdate ();
				//yield return new WaitForSeconds (0.005f);

			}

			while (eqA1.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				eqA1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				eqA2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);

				yield return new WaitForFixedUpdate ();
			}

			yield return new WaitForSeconds (0.5f);

			while (R4.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				R4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				G5.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);

				yield return new WaitForFixedUpdate ();
			}

			background.GetComponent<BackG> ().canCancel = true;
			explain2.GetComponent<ST2Explain2> ().prevNum = 11;
		}

		else if (col.gameObject.layer.Equals (13)) {
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

				circle21.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle22.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle23.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				R1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plusA1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				B2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				yield return new WaitForFixedUpdate ();
				//yield return new WaitForSeconds (0.005f);

			}

			while (eqA1.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				eqA1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				eqA2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);

				yield return new WaitForFixedUpdate ();
			}

			yield return new WaitForSeconds (0.5f);

			while (R4.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				R4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				B5.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);

				yield return new WaitForFixedUpdate ();
			}

			background.GetComponent<BackG> ().canCancel = true;
			explain2.GetComponent<ST2Explain2> ().prevNum = 13;
		}

		else if (col.gameObject.layer.Equals (14)) {
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

				circle31.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle32.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				circle33.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				G1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				plusA1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
				B2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

				yield return new WaitForFixedUpdate ();
				//yield return new WaitForSeconds (0.005f);

			}

			while (eqA1.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				eqA1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				eqA2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);

				yield return new WaitForFixedUpdate ();
			}

			yield return new WaitForSeconds (0.5f);

			while (G4.GetComponent<SpriteRenderer>().color.a != 1.0f) {
				G4.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
				B5.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);

				yield return new WaitForFixedUpdate ();
			}

			background.GetComponent<BackG> ().canCancel = true;
			explain2.GetComponent<ST2Explain2> ().prevNum = 14;
		}

		alive = true;
		col2d = col;
	}

	IEnumerator Cancel () {
		if (alive) {
			if (col2d.gameObject.layer.Equals (11)) {
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

					circle11.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle12.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle13.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					R1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plusA1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eqA1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eqA2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					R4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G5.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
				}
				col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
			}

			else if (col2d.gameObject.layer.Equals (13)) {
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

					circle21.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle22.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle23.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					R1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plusA1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eqA1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eqA2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					R4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B5.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
				}
				col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
			}

			else if (col2d.gameObject.layer.Equals (14)) {
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

					circle31.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle32.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					circle33.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					G1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					plusA1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eqA1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					eqA2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					G4.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
					B5.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

					yield return new WaitForFixedUpdate ();
					//yield return new WaitForSeconds (0.005f);
				}
				col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));
			}

			alive = false;
			background.SetActive (false);
		}
	}

	IEnumerator Reset () {

		StopCoroutine ("Explaining");
		StopCoroutine ("Cancel");

		yield return new WaitForSeconds (0.1f);

		num = 0;
		alive = false;
		background.GetComponent<BackG> ().canCancel = false;

		line1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line3.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		line4.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner3.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		corner4.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plus.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);   // 원래부터 검은색 
		equals1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		equals2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		circle11.GetComponent<SpriteRenderer> ().color = color11;
		circle12.GetComponent<SpriteRenderer> ().color = color12;
		circle13.GetComponent<SpriteRenderer> ().color = color13;

		circle21.GetComponent<SpriteRenderer> ().color = color21;
		circle22.GetComponent<SpriteRenderer> ().color = color22;
		circle23.GetComponent<SpriteRenderer> ().color = color23;

		circle31.GetComponent<SpriteRenderer> ().color = color31;
		circle32.GetComponent<SpriteRenderer> ().color = color32;
		circle33.GetComponent<SpriteRenderer> ().color = color33;

		R1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plusA1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eqA1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eqA2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		R4.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G4.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G5.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B5.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		background.SetActive (false);
	}

	void Playing () {

	}

}
