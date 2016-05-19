using UnityEngine;
using System.Collections;

public class MoveFood : MonoBehaviour {
	private float moveSpeed = 0.07f;
	private Vector2 first, second, swipe;
	private bool wasPressed, isAlive;
	private float price;
	private int type;

	// Use this for initialization
	void Start () {
		wasPressed = false;
		isAlive = true;
		type = 3;
		price = setPrice ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive)
			transform.position = new Vector3 (transform.position.x - moveSpeed, transform.position.y, transform.position.z);

		// kill it once off screen
		if (transform.position.x < -10f)
			Destroy (this.gameObject);
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
			if (swipe.y < 0 && swipe.x > -.5f && swipe.x < .5f) {
				GameObject.FindWithTag ("GameController").GetComponent<Budget> ().budget -= price;
				decrementCounters ();
				transform.position = new Vector3 (-4.5f, -1.5f, transform.position.z);
				isAlive = false;
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

	float setPrice() {
		string currName = this.transform.name;

		switch (currName) {
		case "Bread1(Clone)":
			type = 2;
			return 1f;
		case "Bread2(Clone)":
			type = 2;
			return 2f;
		case "Bread3(Clone)":
			type = 2;
			return 3f;
		case "Fruit1(Clone)":
			type = 0;
			return 4f;
		case "Fruit2(Clone)":
			type = 0;
			return 5f;
		case "Fruit3(Clone)":
			type = 0;
			return 6f;
		case "Fruit4(Clone)":
			type = 0;
			return 7f;
		case "Fruit5(Clone)":
			type = 0;
			return 8f;
		case "Fruit6(Clone)":
			type = 0;
			return 9f;
		case "Milk(Clone)":
			return 10f;
		case "Snack1(Clone)":
			return 11f;
		case "Snack2(Clone)":
			return 12f;
		case "Snack3(Clone)":
			return 13f;
		case "Snack4(Clone)":
			return 14f;
		case "Snack5(Clone)":
			return 15f;
		case "Veggie1(Clone)":
			type = 1;
			return 16f;
		case "Veggie2(Clone)":
			type = 1;
			return 17f;
		case "Veggie3(Clone)":
			type = 1;
			return 18f;
		case "Veggie4(Clone)":
			type = 1;
			return 19f;
		default:
			return 20f;
		}
	}
}
