using UnityEngine;
using System.Collections;

public class MoveFood : MonoBehaviour {
	private float moveSpeed = 0.08f;
	private Vector2 first;
	private Vector2 second;
	private Vector2 swipe;
	private bool wasPressed;

	// Use this for initialization
	void Start () {
		wasPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x - moveSpeed, transform.position.y, transform.position.z);

		// kill it once off screen
		if (transform.position.x < -10f)
			Destroy (this.gameObject);
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
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
			if (swipe.y < 0 && swipe.x > -.4f && swipe.x < .4f)
				Destroy (this.gameObject);
		}
	}
}
