using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Budget : MonoBehaviour {
    public GUIText budgetText;
    public int money;

	// Use this for initialization
	void Start () {
        money = 0;
        budgetText.text = "Budget: " + money.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
