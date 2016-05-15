using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class budget : MonoBehaviour {
    public GUIText budget;
    public int money;

	// Use this for initialization
	void Start () {
        money = 0;
        budget.text = "Budget: " + money.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
