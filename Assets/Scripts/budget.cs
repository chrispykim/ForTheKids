using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Budget : MonoBehaviour {
	public Text moneyLeft;
	public Text fruitCounter;
	public Text veggieCounter;
	public Text breadCounter;
	public float budget, initial;
	public int fc, vc, bc, fp, vp, bp;

	// Use this for initialization
	void Start () {
		fc = Random.Range (2, 11);//2,11
		vc = Random.Range (3, 9);//3,9
		bc = Random.Range (2, 6);//2,6
		budget = (fc * fp) + (vc * vp) + (bc * bp);
		initial = budget;
		moneyLeft.text = "Remaining Budget: $" + budget.ToString ("F2");
		fruitCounter.text = "# fruits needed: " + fc.ToString ();
		veggieCounter.text = "# veggies needed: " + vc.ToString ();
		breadCounter.text = "# bread needed: " + bc.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		moneyLeft.text = "Remaining Budget: $" + budget.ToString ("F2");
		fruitCounter.text = "# fruits needed: " + fc.ToString ();
		veggieCounter.text = "# veggies needed: " + vc.ToString ();
		breadCounter.text = "# bread needed: " + bc.ToString ();
	}
}
