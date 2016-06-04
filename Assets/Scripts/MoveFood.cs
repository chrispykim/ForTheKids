using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MoveFood : MonoBehaviour {
	private float moveSpeed = 0.035f;
	private Vector2 first, second, swipe;
	private bool wasPressed, isAlive;
	private float price;
	private int type;
	private Transform t;
	private RectTransform r;
	private float scaleWidth; // fucking canvas
	private float scaleHeight;

	// Use this for initialization
	void Start () {
		Dictionary<string, float> d = GameObject.FindWithTag ("GameController").GetComponent<SpawnFood> ().prices;
		/*string path = "/Users/chrisKim/Desktop/My Stuff/College/ENG 100D/ForTheKids/test.txt";
		foreach (KeyValuePair<string, float> kvp in d) {
			using (StreamWriter sw = File.AppendText (path)) {
				sw.WriteLine ("name: " + kvp.Key + ", price: " + kvp.Value + "\n");
			}
		}*/
		price = d[this.transform.name];
		scaleWidth = GameObject.FindWithTag ("GameController").GetComponent<SpawnFood> ().scaleWidth;
		scaleHeight = GameObject.FindWithTag ("GameController").GetComponent<SpawnFood> ().scaleHeight;
		setType ();
		wasPressed = false;
		isAlive = true; 

		GameObject temp = ((GameObject)Resources.Load("pt"));
		t = Instantiate (temp.transform);
		t.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform);
		Text p = t.gameObject.GetComponent<Text> ();
		p.text = "$" + price.ToString("F2");
		p.font = (Font)Resources.Load ("arial_narrow_7"); // idk why default arial doesn't load
		p.fontSize = 30;
		//p.color = Color.black;

		r = t.gameObject.GetComponent<RectTransform> ();
		r.localPosition = new Vector3 (transform.position.x*scaleWidth, transform.position.y*scaleHeight+60, transform.position.z);
	}

	void setType() {
		type = 3; // so counters don't decrement if they're not supposed to
		string bread = "Bread"; string fruit = "Fruit"; string veggie = "Veggie";
		if (this.transform.name.Contains (fruit))
			type = 0;
		else if (this.transform.name.Contains (veggie))
			type = 1;
		else if (this.transform.name.Contains (bread))
			type = 2;
	}

	// Update is called once per frame
	void Update () {
		// uncomment these if screen changes size during gameplay
		//scaleWidth = GameObject.FindWithTag ("GameController").GetComponent<SpawnFood> ().scaleWidth;
		//scaleHeight = GameObject.FindWithTag ("GameController").GetComponent<SpawnFood> ().scaleHeight;

		if (isAlive) {
			transform.position = new Vector3 (transform.position.x - moveSpeed, transform.position.y, transform.position.z);
			r.localPosition = new Vector2 (r.localPosition.x - moveSpeed*scaleHeight, r.localPosition.y);
		}

		// kill it once off screen
		if (transform.position.x < -10f) {
			Destroy (this.gameObject);
			Destroy (t.gameObject);
		}
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0) && Input.mousePosition.x < Screen.width/2) {
			first = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			wasPressed = true;
		} 
	}

	void OnMouseExit() {
		if (wasPressed) {
			wasPressed = false;
			second = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			swipe = new Vector2 (second.x - first.x, second.y - first.y);
			swipe.Normalize ();
			// swipe was down and over cart
			if (swipe.y < 0 && swipe.x > -.6f && swipe.x < .5f) {
				GameObject.FindWithTag ("GameController").GetComponent<Budget> ().budget -= price;
				decrementCounters ();
				transform.position = new Vector3 (-4.5f, -1.5f, transform.position.z);
				isAlive = false;
				Destroy (t.gameObject);
			}
		}
	}

	void decrementCounters() {
		switch (type) {
		case 0:
			int temp = GameObject.FindWithTag ("GameController").GetComponent<Budget> ().fc;
			GameObject.FindWithTag ("GameController").GetComponent<Budget> ().fc = (temp > 0) ? (temp - 1) : 0;
			return;
		case 1:
			temp = GameObject.FindWithTag ("GameController").GetComponent<Budget> ().vc;
			GameObject.FindWithTag ("GameController").GetComponent<Budget> ().vc = (temp > 0) ? (temp - 1) : 0;
			return;
		case 2:
			temp = GameObject.FindWithTag ("GameController").GetComponent<Budget> ().bc;
			GameObject.FindWithTag ("GameController").GetComponent<Budget> ().bc = (temp > 0) ? (temp - 1) : 0;
			return;
		}
	}
}