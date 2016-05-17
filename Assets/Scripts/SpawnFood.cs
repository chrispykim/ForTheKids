using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
	private static int NUM_OF_FOOD_TYPES = 2;
	private float time = 3f;

	public Transform foodTemp;

	// Use this for initialization
	void Start () {
		Instantiate (foodTemp);
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if (time <= 0) {
			time = 3f;
			Instantiate (foodTemp);
		}
	}
}
