using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
	private static int NUM_OF_FOOD_TYPES = 19;
	private float time = 2f;

	public Transform bread1;
	public Transform bread2;
	public Transform bread3;
	public Transform fruit1;
	public Transform fruit2;
	public Transform fruit3;
	public Transform fruit4;
	public Transform fruit5;
	public Transform fruit6;
	public Transform milk;
	public Transform snack1;
	public Transform snack2;
	public Transform snack3;
	public Transform snack4;
	public Transform snack5;
	public Transform veggie1;
	public Transform veggie2;
	public Transform veggie3;
	public Transform veggie4;

	// Use this for initialization
	void Start () {
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
