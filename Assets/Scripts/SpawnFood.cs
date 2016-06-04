using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFood : MonoBehaviour {
	private static int NUM_OF_FOOD_TYPES = 19;
	private float time = 2.5f;
	private static int NUM_FRUITS = 6;
	private static int NUM_VEGGIES = 4;
	private static int NUM_BREAD = 3;
	public float scaleWidth, scaleHeight;
	public int type;
	public Dictionary<string, float> prices;
	public GUIText scoreText;
	public GUIText exitText;
	private bool gameOver;
	public Transform bread1, bread2, bread3, 
		fruit1, fruit2, fruit3, fruit4, fruit5, fruit6, 
		milk, snack1, snack2, snack3, snack4, snack5, 
		veggie1, veggie2, veggie3, veggie4;

	// Use this for initialization
	void Start () {
		gameOver = false;
		scoreText.text = "";
		exitText.text = "";
		// some bullshit to make ui text movement work
		RectTransform canvas = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<RectTransform> ();
		float canvasHeight = canvas.rect.height;
		float canvasWidth = canvas.rect.width;
		float camHeight = 2f * GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().orthographicSize;
		float camWidth = camHeight * GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().aspect;
		scaleWidth = canvasWidth / camWidth;
		scaleHeight = canvasHeight / camHeight;

		setPrice ();
		Instantiate (chooseFood());
	}

	public void GameOver(float rem, bool won) {
		foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
			if (o.tag != "Finish" && o.tag != "MainCamera" && o.tag != "GameController")
				Destroy(o);
		}

		if (rem < 60)
			rem += 40;
		else
			rem = 100;
			
		string temp = "";
		if (won)
			temp += "You did it!\n";
		else
			temp += "You did not succeed\n";
		scoreText.text = temp + "SCORE: " + rem.ToString();
		exitText.text = "EXIT";

		GameObject.Find ("ExitText").GetComponent<Exit> ().score = (int)rem;
		gameOver = true;
	}

	// Update is called once per frame
	void Update () {
		// uncomment these if screen changes size during gameplay
		/*RectTransform canvas = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<RectTransform> ();
		float canvasHeight = canvas.rect.height;
		float canvasWidth = canvas.rect.width;
		float camHeight = 2f * GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().orthographicSize;
		float camWidth = camHeight * GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().aspect;
		scaleWidth = canvasWidth / camWidth;
		scaleHeight = canvasHeight / camHeight;*/

		//print (gameOver);
		time -= Time.deltaTime;

		if (time <= 0 && !gameOver) {
			float remaining = GameObject.FindWithTag ("GameController").GetComponent<Budget> ().budget;
			int f = GameObject.FindWithTag ("GameController").GetComponent<Budget> ().fc;
			int v = GameObject.FindWithTag ("GameController").GetComponent<Budget> ().vc;
			int b = GameObject.FindWithTag ("GameController").GetComponent<Budget> ().bc;
			//print ("f = " + f + ", v = " + v + ", b = " + b);
			if (remaining < 0f)
				GameOver (remaining, false);
			else if (f == 0 && v == 0 && b == 0)
				GameOver (remaining, true);
			else if (remaining == 0f)
				GameOver (remaining, false);
			
			time = 2.5f;
			if (!gameOver)
				Instantiate (chooseFood());
		}
	}

	public void setPrice() {
		// bread $2-4 fruits $1-4 veggies $3-5 milk $2 cake $15 chocolate $2 donut $1 ice cream $3 soda $1
		prices = new Dictionary<string, float>();

		List<float> fruitPrices = new List<float> ();
		for (int i = 1; i <= NUM_FRUITS; i++)
			fruitPrices.Add (i);
		List<float> veggiePrices = new List<float> ();
		for (int i = 1; i <= NUM_VEGGIES; i++)
			veggiePrices.Add (i);
		List<float> breadPrices = new List<float> ();
		for (int i = 1; i <= NUM_BREAD; i++)
			breadPrices.Add (i);

		GameObject.FindWithTag ("GameController").GetComponent<Budget> ().fp = (fruitPrices.Count / 2) + 1;
		GameObject.FindWithTag ("GameController").GetComponent<Budget> ().vp = (veggiePrices.Count / 2) + 1;
		GameObject.FindWithTag ("GameController").GetComponent<Budget> ().bp = (breadPrices.Count / 2) + 1;

		int index;
		for (int i = 1; i <= NUM_FRUITS; i++) {
			index = Random.Range (0, fruitPrices.Count);
			string name = "Fruit" + i.ToString() + "(Clone)";
			prices.Add (name, fruitPrices [index]);
			fruitPrices.RemoveAt (index);
		}
		for (int j = 1; j <= NUM_VEGGIES; j++) {
			index = Random.Range (0, veggiePrices.Count);
			string name = "Veggie" + j.ToString() + "(Clone)";
			prices.Add (name, veggiePrices [index]);
			veggiePrices.RemoveAt (index);
		}
		for (int k = 1; k <= NUM_BREAD; k++) {
			index = Random.Range (0, breadPrices.Count);
			string name = "Bread" + k.ToString() + "(Clone)";
			prices.Add (name, breadPrices [index]);
			breadPrices.RemoveAt (index);
		}

		prices.Add("Milk(Clone)", 2f);
		prices.Add("Snack1(Clone)", 15f);
		prices.Add("Snack2(Clone)",	2f);
		prices.Add("Snack3(Clone)", 1f);
		prices.Add("Snack4(Clone)", 3f);
		prices.Add("Snack5(Clone)", 1f);
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
