using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Budget : MonoBehaviour {
	public Text moneyLeft;
	public Text fruitCounter;
	public Text veggieCounter;
	public Text breadCounter;
	public float budget;
	public int fc, vc, bc;

	// Use this for initialization
	void Start () {
		budget = Random.Range (200f, 500f);
		fc = Random.Range (1, 10);
		vc = Random.Range (1, 8);
		bc = Random.Range (1, 5);
		moneyLeft.text = "Remaining Budget: " + budget.ToString ("F2");
		fruitCounter.text = "# fruits needed: " + fc.ToString ();
		veggieCounter.text = "# veggies needed: " + vc.ToString ();
		breadCounter.text = "# bread needed: " + bc.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		moneyLeft.text = "Remaining Budget: " + budget.ToString ("F2");
		fruitCounter.text = "# fruits needed: " + fc.ToString ();
		veggieCounter.text = "# veggies needed: " + vc.ToString ();
		breadCounter.text = "# bread needed: " + bc.ToString ();
	}
}
