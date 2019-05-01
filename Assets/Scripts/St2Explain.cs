using UnityEngine;
using System.Collections;

public class St2Explain : MonoBehaviour {

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

	public GameObject R;
	public GameObject G;
	public GameObject B;
	public GameObject R2;
	public GameObject G2;
	public GameObject B2;
	public GameObject plusA1;
	public GameObject eqA1;
	public GameObject eqA2;

	private int num = 0;
	private bool alive = false;

	private Collider2D col2d;

	// Use this for initialization
	void Start () {
		background.SetActive (false);

		color11 = circle11.GetComponent<SpriteRenderer> ().color;
		color12 = circle12.GetComponent<SpriteRenderer> ().color;
		color13 = circle13.GetComponent<SpriteRenderer> ().color;
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Ball")) {
			col.gameObject.GetComponent <Rigidbody2D> ().Sleep();
			StartCoroutine("Explaining", col);
		}
	}

	IEnumerator Explaining (Collider2D col) {
		background.SetActive (true);

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

			R.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
			plusA1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
			G.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);
			B.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,1/510f);

			yield return new WaitForFixedUpdate ();
			//yield return new WaitForSeconds (0.005f);

		}

		while (eqA1.GetComponent<SpriteRenderer>().color.a != 1.0f) {
			eqA1.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
			eqA2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);

			yield return new WaitForFixedUpdate ();
		}

		yield return new WaitForSeconds (0.5f);

		while (R2.GetComponent<SpriteRenderer>().color.a != 1.0f) {
			R2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
			G2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);
			B2.GetComponent<SpriteRenderer>().color += new Color (0.0f,0.0f,0.0f,5/255f);

			yield return new WaitForFixedUpdate ();
		}

		background.GetComponent<BackG> ().canCancel = true;

		alive = true;
		col2d = col;
	}

	IEnumerator Cancel () {
		if (alive) {
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

				R.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
				plusA1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
				G.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
				B.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
				eqA1.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
				eqA2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
				R2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
				G2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);
				B2.GetComponent<SpriteRenderer>().color -= new Color (0.0f,0.0f,0.0f,1/510f);

				yield return new WaitForFixedUpdate ();
				//yield return new WaitForSeconds (0.005f);
			}

			col2d.gameObject.GetComponent <Rigidbody2D> ().AddForce (new Vector2 (2000.0f,0.0f));

			alive = false;
			background.SetActive (false);
		}
	}

	void Playing () {

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

		R.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		plusA1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eqA1.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		eqA2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		R2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		G2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		B2.GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);

		background.SetActive (false);
	}

}
