using UnityEngine;
using System.Collections;

public class Circle_Tutorial : MonoBehaviour {

	Vector2 pos_init;
	Color color_init;
	// (tag) Black: 0, Red: 1, White: 7
	int tag_init;

	int tag;
	// Circle Overlapped By 'this'
	GameObject target;
	bool is_clicked = false;

	GameObject wave;
	Color color_wave;
	bool is_waving = false;
	IEnumerator coroutine_wave;
	public GameObject[] circles_other;

	public GameObject[] alphabets;
	public GameObject[] bars;

	public GameObject MousePointer;

	public Color GetColor () {
		return new Color (color_init.r, color_init.g, color_init.b, 1.0f);
	}

	public int GetTag () {
		return this.tag;
	}

	void Start () {
		// Initiate Variables
		this.pos_init = transform.position;
		this.color_init = GetComponent<SpriteRenderer>().color;

		this.tag = int.Parse (gameObject.tag);

		this.wave = transform.GetChild (0).gameObject;
		color_wave = wave.GetComponent<SpriteRenderer> ().color;
	}

	void OnMouseDrag () {
		this.is_clicked = true;

		if (MousePointer.activeSelf) {
			MousePointer.GetComponent<MousePointer> ().Destroy ();
		}

		GetComponent<SpriteRenderer> ().color = new Color (color_init.r, color_init.g, color_init.b, 1.0f);

		if (!is_waving) {
			coroutine_wave = MakeWave ();
			StartCoroutine (coroutine_wave);
		}

		// Move Position
		Vector2 pos = Input.mousePosition;
		Vector2 pos_real = Camera.main.ScreenToWorldPoint (pos);
		transform.position = new Vector3 (pos_real.x, this.pos_init.y, -3);
	}

	void OnMouseUp () {
		this.is_clicked = false;

		GetComponent<SpriteRenderer> ().color = color_init;

		if (is_waving) {
			StopCoroutine (coroutine_wave);
			is_waving = false;
			wave.SetActive (false);
			wave.GetComponent<SpriteRenderer> ().color = color_wave;
		}

		// Initialize Position
		transform.position = new Vector3 (this.pos_init.x, this.pos_init.y, 0);

		if (this.target != null) {
			this.target.GetComponent<Circle_Tutorial> ().ChangeColor (this.tag);
			this.target = null;
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (this.is_clicked) {
			this.target = other.gameObject;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (this.target == other.gameObject) {
			this.target = null;
		}
	}

	public void ChangeColor (int tag) {
		GameObject circle_new_x = NewCircle (tag, -1.0f);
		GameObject circle_new_y = NewCircle (this.tag, -2.0f);
		GameObject circle_new_z = NewCircle (this.tag ^ tag, -3.0f);

		circle_new_x.GetComponent<Circle_Tutorial> ().Move (new Vector3 (-113.0f, 0.1f, -1.0f));
		circle_new_y.GetComponent<Circle_Tutorial> ().Move (new Vector3 (-101.0f, 0.1f, -2.0f));
		circle_new_z.GetComponent<Circle_Tutorial> ().Move_Trigger (new Vector3 (-89.0f, 0.1f, -3.0f), circle_new_x, circle_new_y);

		for (int i = 0; i < this.circles_other.Length; i++) {
			this.circles_other [i].GetComponent<Circle_Tutorial> ().Remove ();
		}
	}

	GameObject NewCircle (int tag, float order) {
		// Instantiate Circle with Blended Color
		Vector3 position = new Vector3 (transform.position.x, transform.position.y, order);
		GameObject circle_new = (GameObject) Instantiate (circles_other[tag], position, Quaternion.identity);

		// Serring New Circle
		Color color = circle_new.GetComponent<SpriteRenderer> ().color;
		circle_new.GetComponent<SpriteRenderer> ().color = new Color (color.r, color.g, color.b, 1.0f);
		circle_new.GetComponent<CircleCollider2D> ().enabled = false;

		return circle_new;
	}

	IEnumerator MakeWave () {
		is_waving = true;

		wave.SetActive (true);

		while (true) {
			float period;
			for (period = 0.0f; period < 20.0f; period++) {
				wave.transform.localScale = 1.3f * new Vector3 (1.0f + 0.01f * period, 1.0f + 0.01f * period, 0.0f);
				wave.GetComponent<SpriteRenderer> ().color -= new Color (0.0f, 0.0f, 0.0f, 0.03725f);
				yield return new WaitForSeconds(0.075f);
			}
			wave.transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
			wave.GetComponent<SpriteRenderer> ().color += new Color(0.0f, 0.0f, 0.0f, 0.745f);
			yield return new WaitForSeconds (1.5f);
		}
	}

	public void Remove () {
		StartCoroutine (FadeOut ());
	}

	IEnumerator FadeOut () {
		for (int i = 0; i < this.alphabets.Length; i++) {
			this.alphabets [i].SetActive (false);
		}

		Color color = GetComponent<SpriteRenderer> ().color;
		float a = color.a;
		while (a >= 0.0f) {
			a -= 0.05f;
			GetComponent<SpriteRenderer> ().color = new Color (color.r, color.g, color.b, a);
			yield return new WaitForSeconds (0.025f);
		}

		gameObject.SetActive (false);
	}

	public void Move (Vector3 pos) {
		StartCoroutine (Slide (pos));
	}

	IEnumerator Slide (Vector3 pos) {
		yield return new WaitForSeconds (0.25f);

		float t = 0.0f;
		while (t <= 1.0f) {
			t += 0.05f;
			transform.position = Vector3.Lerp (pos_init, pos, t);
			yield return new WaitForSeconds (0.025f);
		}
	}

	public void Move_Trigger (Vector3 pos, GameObject circle_x, GameObject circle_y) {
		StartCoroutine (Slide_Trigger (pos, circle_x, circle_y));
	}

	IEnumerator Slide_Trigger (Vector3 pos, GameObject circle_x, GameObject circle_y) {
		yield return new WaitForSeconds (0.25f);

		float t = 0.0f;
		while (t <= 1.0f) {
			t += 0.05f;
			transform.position = Vector3.Lerp (pos_init, pos, t);
			yield return new WaitForSeconds (0.025f);
		}

		yield return new WaitForSeconds (0.25f);
		GameObject.Find ("Tutorial").GetComponent<Tutorial> ().Animate (circle_x, circle_y, gameObject);
	}

	public void Initialize () {
		for (int i = 0; i < this.alphabets.Length; i++) {
			this.alphabets [i].SetActive (true);
		}

		Color color = GetComponent<SpriteRenderer> ().color;
		GetComponent<SpriteRenderer> ().color = new Color (color.r, color.g, color.b, 1.0f);

		gameObject.SetActive (true);
	}
}
