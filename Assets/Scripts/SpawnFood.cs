using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
	private static int NUM_OF_FOOD_TYPES = 19;
	private float time = 2f;
	public float scaleWidth, scaleHeight;

	public Transform bread1, bread2, bread3, 
		fruit1, fruit2, fruit3, fruit4, fruit5, fruit6, 
		milk, snack1, snack2, snack3, snack4, snack5, 
		veggie1, veggie2, veggie3, veggie4;

	// Use this for initialization
	void Start () {
		// some bullshit to make ui text movement work
		RectTransform canvas = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<RectTransform> ();
		//canvas.rect.height = 594;
		float canvasHeight = canvas.rect.height;
		//canvas.rect.width = 1258;
		float canvasWidth = canvas.rect.width;
		float camHeight = 2f * GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().orthographicSize;
		float camWidth = camHeight * GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().aspect;
		scaleWidth = canvasWidth / camWidth;
		scaleHeight = canvasHeight / camHeight;
		print ("scale width: " + scaleWidth + ", scale height: " + scaleHeight);
		print ("screen width: " + camWidth);

		Instantiate (chooseFood());
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if (time <= 0) {
			time = 2f;
			Instantiate (chooseFood());
		}
	}

	Transform chooseFood() {
		int random = Random.Range(0,NUM_OF_FOOD_TYPES);
		switch (random) {
			case 0:
				return bread1;
			case 1:
				return bread2;
			case 2:
				return bread3;
			case 3:
				return fruit1;
			case 4:
				return fruit2;
			case 5:
				return fruit3;
			case 6:
				return fruit4;
			case 7:
				return fruit5;
			case 8:
				return fruit6;
			case 9:
				return milk;
			case 10:
				return snack1;
			case 11:
				return snack2;
			case 12:
				return snack3;
			case 13:
				return snack4;
			case 14:
				return snack5;
			case 15:
				return veggie1;
			case 16:
				return veggie2;
			case 17:
				return veggie3;
			case 18:
				return veggie4;
			// to make compiler shut up
			default:
				return milk;
		}
	}
}
